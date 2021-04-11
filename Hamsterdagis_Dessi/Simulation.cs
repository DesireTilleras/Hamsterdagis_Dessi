using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using BackEnd_database;


namespace Hamsterdagis_Dessi
{
    internal class Simulation
    {
        public Simulation()
        {
            hamster = new Hamster();
        }

        Hamster hamster;

        internal DateTime SimulationStart { get; set; }

        internal Timer Tick = null;
        internal DateTime CurrentTime { get; set; }
        internal int AmountOfTicks { get; set; }
        internal int CurrentAmountOfTicks { get; set; }
        internal int TimeOfOneTick { get; set; }
        internal bool IsRunning { get; set; }

        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public event EventHandler<ReportEventArgs> ReportEventHandler;
        ReportEventArgs allinfo = new ReportEventArgs();

        public event EventHandler<EndOfDayEventArgs> EndOfDayReport;
        EndOfDayEventArgs DayReport = new EndOfDayEventArgs();

        public event EventHandler<TimeEventArgs> TimeReport;
        TimeEventArgs Time = new TimeEventArgs();

        public event EventHandler<HamsterInfoEventArgs> HamsterInfo;
        HamsterInfoEventArgs hamsterInfo = new HamsterInfoEventArgs();

        /// <summary>
        /// This invokes the event of the print of currentTime on the console. 
        /// It also runs all the functions with await.
        /// </summary>
        /// <param name="state"></param>
        internal async void OnTick(Object state)
        {
            if (AmountOfTicks >= CurrentAmountOfTicks)
            {
                Time.CurrentTime = CurrentTime;
                TimeReport?.Invoke(this, Time);

                CurrentTime = CurrentTime.AddMinutes(6);
                await _semaphore.WaitAsync();
                try
                {
                    await Task.Run(() => MoveToExercise());
                    await Task.Run(() => MoveToSpa());
                    await Task.Run(() => CheckOutFromExArea());
                    await Task.Run(() => CheckOutFromSpaArea());
                    await Task.Run(() => CheckOutDay());
                    await Task.Run(() => CheckIn());
                    await Task.Run(() => PutInCageFemales());
                    await Task.Run(() => PutInCageMales());
                    await Task.Run(() => NewDay());
                }
                finally
                {
                    _semaphore.Release();
                }

                CurrentAmountOfTicks++;
            }
        }
        /// <summary>
        /// This function calculates how fast a tick is, depending on what the user choses. 
        /// </summary>
        /// <param name="days"></param>
        /// <param name="minutesOfSimulation"></param>
        internal void StartSimulation(int days, int minutesOfSimulation)
        {

            SimulationStart = new DateTime(2021, 03, 26, 07, 00, 00);
            CurrentTime = SimulationStart;

            AmountOfTicks = days * 100;
            float timeOfTick = (minutesOfSimulation * 60F / AmountOfTicks) * 1000F;
            TimeOfOneTick = (int)timeOfTick;

            Tick = new Timer(new TimerCallback(OnTick), null, 200, TimeOfOneTick);

            if (AmountOfTicks <= CurrentAmountOfTicks)
            {
                Tick.Dispose();

            }
        }
        /// <summary>
        /// This method cleares the loggfile when a new simulation starts.
        /// </summary>
        internal void ClearLoggFile()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                var rows = hamsterContext.Logg_Activities.Select(logg => logg).ToList();

                foreach (var row in rows)
                {
                    hamsterContext.Logg_Activities.Remove(row);
                }

                hamsterContext.SaveChanges();
            }
        }
        /// <summary>
        /// When the time for the currentTick is 17.24, a new day starts. 
        /// </summary>
        internal void NewDay()
        {
            if (CurrentTime.Hour == 17 && CurrentTime.Minute == 24)
            {
                SimulationStart = SimulationStart.AddDays(1);

                using (var hamsterContext = new HamsterAppContext())
                {
                    hamsterContext.Hamsters.Select(hamster => hamster)
                        .ToList()
                        .ForEach(hamster => hamster.CheckInTime = SimulationStart);
                    hamsterContext.SaveChanges();

                }
                CurrentTime = SimulationStart;
            }
        }
        /// <summary>
        /// This checks out all the hamsters when one day is finished.
        /// </summary>
        internal void CheckOutDay()
        {

            using (var hamsterContext = new HamsterAppContext())
            {
                var listOfHamsters = hamsterContext.Hamsters.Select(hamster => hamster)
                    .ToList();

                if (CurrentTime.Hour == 17 && CurrentTime.Minute == 12 || AmountOfTicks <= CurrentAmountOfTicks)
                {
                    foreach (var hamster in listOfHamsters)
                    {
                        hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 4 });
                        hamsterContext.SaveChanges();
                        hamsterInfo.Hamster = hamster;
                        HamsterInfo?.Invoke(this, hamsterInfo);

                    };

                    var listOfLoggs = hamsterContext.Logg_Activities.Where(logg => logg.Timestamp.Day == CurrentTime.Day)
                        .OrderBy(x => x.HamsterId)
                        .ThenBy(t => t.Timestamp)
                        .ToList();

                    foreach (var logg in listOfLoggs)
                    {
                        DayReport.Logg_Activities = logg;
                        EndOfDayReport?.Invoke(this, DayReport);
                    }
                    hamsterContext.SaveChanges();

                    foreach (var hamster in listOfHamsters)
                    {
                        hamster.ActivityId = null;
                        hamster.CageId = null;
                        hamster.StartTimeExercise = null;
                        hamster.EndTimeExercise = null;
                        hamster.CheckInTime = null;
                        hamster.StartTimeSpa = null;
                        hamster.AmountOfExercises = 0;
                        hamster.AmountOfSpaVisits = 0;
                    };

                    hamsterContext.Cages.Select(cages => cages)
                       .ToList()
                       .ForEach(cage => cage.AmountInCage = 0);

                    hamsterContext.ExerciseAreas.Select(area => area).ToList().ForEach(area => area.AmountInArea = 0);
                    hamsterContext.SpaAreas.Select(area => area).ToList().ForEach(area => area.AmountInArea = 0);

                    hamsterContext.SaveChanges();
                }
            }
        }
        /// <summary>
        /// This function puts all the female hamsters in their cages, 3 and 3. 
        /// </summary>
        internal void PutInCageFemales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {

                if (CurrentTime.Hour == 7 && CurrentTime.Minute == 24)
                {
                    var listOfHamsters = hamsterContext.Hamsters.Where(hamster => hamster.Gender.Id == 1)
                          .Where(hamster => hamster.ActivityId == 1)
                          .ToList();

                    while (listOfHamsters.Count != 0)
                    {
                        var topThree = listOfHamsters.OrderBy(hamster => hamster.Age).Take(3);
                        var cage = hamsterContext.Cages.Where(cage => cage.AmountInCage < 3).OrderBy(cage => cage.Id).First();

                        foreach (var hamster in topThree)
                        {
                            hamster.ActivityId = 2;
                            cage.AmountInCage++;
                            hamster.CageId = cage.Id;
                            listOfHamsters.Remove(hamster);
                            hamsterContext.SaveChanges();

                            hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 2 });
                            hamsterContext.SaveChanges();
                            allinfo.Hamster = hamster;
                            ReportEventHandler?.Invoke(this, allinfo);


                        }
                    }

                }


            }
        }
        /// <summary>
        /// This function puts all the males in their cages after they are checked in at the daycare
        /// </summary>
        internal void PutInCageMales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {

                if (CurrentTime.Hour == 7 && CurrentTime.Minute == 24)
                {
                    var listOfHamsters = hamsterContext.Hamsters.Where(hamster => hamster.Gender.Id == 2)
                           .Where(hamster => hamster.ActivityId == 1)
                           .ToList();



                    while (listOfHamsters.Count != 0)
                    {
                        var topThree = listOfHamsters.OrderBy(hamster => hamster.Age).Take(3);
                        var cage = hamsterContext.Cages.Where(cage => cage.AmountInCage < 3).OrderBy(cage => cage.Id).First();

                        foreach (var hamster in topThree)
                        {
                            hamster.ActivityId = 2;
                            cage.AmountInCage++;
                            hamster.CageId = cage.Id;
                            listOfHamsters.Remove(hamster);
                            hamsterContext.SaveChanges();
                            hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 2 });
                            hamsterContext.SaveChanges();

                            allinfo.Hamster = hamster;
                            ReportEventHandler?.Invoke(this, allinfo);
                        }
                    }
                }

            }
        }
        /// <summary>
        /// This function checks in all the hamsters and gives them the status "Arrival"
        /// </summary>
        internal void CheckIn()
        {

            if (CurrentTime.Hour == 7 && CurrentTime.Minute == 12)
            {
                using (var hamsterContext = new HamsterAppContext())
                {
                    var notCheckedIn = hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == null)
                        .ToList();

                    foreach (var hamster in notCheckedIn)
                    {
                        hamster.ActivityId = 1;
                        hamster.TimeWaited = new TimeSpan(00, 00, 00);
                        hamster.CheckInTime = CurrentTime;
                        hamsterContext.SaveChanges();
                        hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 1 });
                        hamsterContext.SaveChanges();

                    }

                }

            }

        }
        /// <summary>
        /// After the hamsters has exercised 50 minutes, this function checks out the hamsters from exercisearea
        /// </summary>
        internal void CheckOutFromExArea()
        {

            using (var hamsterContext = new HamsterAppContext())
            {

                var area = hamsterContext.ExerciseAreas.Single(area => area.AmountInArea >= 0);
                area.AmountInArea = 0;

                var listOfHamsters = hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == 3)
                      .ToList();

                if (listOfHamsters.Count() != 0)
                {

                    foreach (var hamster in listOfHamsters)
                    {
                        if (CurrentTime - hamster.StartTimeExercise >= new TimeSpan(00, 50, 00))
                        {
                            hamster.ActivityId = 2;
                            hamster.EndTimeExercise = CurrentTime;

                            allinfo.Hamster = hamster;
                            ReportEventHandler?.Invoke(this, allinfo);

                            hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 2 });
                            hamsterContext.SaveChanges();

                        }


                    }

                }

            }
        }
        /// <summary>
        /// When the hamsters has been at the spa for 50 minutes, they are checked out
        /// </summary>
        internal void CheckOutFromSpaArea()
        {

            using (var hamsterContext = new HamsterAppContext())
            {

                var area = hamsterContext.SpaAreas.Single(area => area.AmountInArea >= 0);
                area.AmountInArea = 0;

                var listOfHamsters = hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == 5)
                      .ToList();

                if (listOfHamsters.Count() != 0)
                {

                    foreach (var hamster in listOfHamsters)
                    {
                        if (CurrentTime - hamster.StartTimeSpa >= new TimeSpan(00, 50, 00))
                        {
                            hamster.ActivityId = 2;

                            allinfo.Hamster = hamster;
                            ReportEventHandler?.Invoke(this, allinfo);

                            hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 2 });
                            hamsterContext.SaveChanges();

                        }


                    }

                }

            }
        }
        /// <summary>
       /// This function checks if the exercisearea is free.
       /// </summary>
       /// <returns></returns>
        internal bool CheckIfAreaIsFree()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                var isFree = hamsterContext.ExerciseAreas.Where(area => area.AmountInArea == 0);
                if (isFree.Count().Equals(1))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// This function checks if the spaarea is free
        /// </summary>
        /// <returns></returns>
        internal bool CheckIfSpaAreaIsFree()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                var isFree = hamsterContext.SpaAreas.Where(area => area.AmountInArea == 0);
                if (isFree.Count().Equals(1))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// This function will move 6 hamsters to the exercise. It will choose females if the average amount of exercise for the males are higher. 
        /// The lists are ordered by the amount of exercise and also age of the hamsters
        /// </summary>
        internal void MoveToExercise()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                if (CheckIfAreaIsFree())
                {
                    if (CurrentTime.Minute == 18 && CurrentTime.Hour < 17 && CurrentTime.Hour > 7)
                    {
                        var area = hamsterContext.ExerciseAreas.Single(area => area.Id == 1);

                        var listOfHamsters = hamsterContext.Hamsters.Where(h => h.ActivityId == 2)
                            .OrderBy(hamster => hamster.AmountOfExercises)
                            .ThenBy(hamster => hamster.Age)
                            .ToList();

                        var listOfHamstersTop6 = listOfHamsters.Where(hamster => hamster.GenderId == 1).Take(6);
                        var listOfHamstersMalesTop6 = listOfHamsters.Where(hamster => hamster.GenderId == 2).Take(6);

                        var averageExercisesFemales = listOfHamstersTop6.Average(h => h.AmountOfExercises);
                        var averageExercisesMales = listOfHamstersMalesTop6.Average(h => h.AmountOfExercises);

                        if (averageExercisesFemales < averageExercisesMales)
                        {
                            foreach (var hamster in listOfHamstersTop6)
                            {
                                area.AmountInArea++;
                                hamster.StartTimeExercise = CurrentTime;
                                hamster.ActivityId = 3;
                                hamster.AmountOfExercises++;
                                if (hamster.AmountOfExercises <= 1)
                                {
                                    hamster.TimeWaited = hamster.StartTimeExercise - hamster.CheckInTime;
                                }
                                hamsterContext.SaveChanges();
                                allinfo.Hamster = hamster;
                                ReportEventHandler?.Invoke(this, allinfo);

                                hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 3 });
                                hamsterContext.SaveChanges();

                            }
                        }
                        else
                        {
                            foreach (var hamster in listOfHamstersMalesTop6)
                            {
                                area.AmountInArea++;
                                hamster.StartTimeExercise = CurrentTime;
                                hamster.ActivityId = 3;
                                hamster.AmountOfExercises++;
                                if (hamster.AmountOfExercises <= 1)
                                {
                                    hamster.TimeWaited = hamster.StartTimeExercise - hamster.CheckInTime;
                                }

                                hamsterContext.SaveChanges();
                                allinfo.Hamster = hamster;
                                ReportEventHandler?.Invoke(this, allinfo);

                                hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 3 });
                                hamsterContext.SaveChanges();

                            }
                        }

                    }

                }

            }
        }
        /// <summary>
        /// This function moves hamsters to the spa. it will choose females if the average amount of spa visits are higher for the males.
        /// It takes the top 4 hamsters ordered by amount of spavisits and age.
        /// </summary>
        internal void MoveToSpa()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                if (CheckIfSpaAreaIsFree())
                {
                    if (CurrentTime.Minute == 24 && CurrentTime.Hour < 17 && CurrentTime.Hour > 7)
                    {
                        var area = hamsterContext.SpaAreas.Single(area => area.Id == 1);

                        var listOfHamsters = hamsterContext.Hamsters.Where(h => h.ActivityId == 2)
                            .OrderBy(hamster => hamster.AmountOfSpaVisits)
                            .ThenBy(hamster => hamster.Age)
                            .ToList();

                        var listOfHamstersTop6 = listOfHamsters.Where(hamster => hamster.GenderId == 1).Take(4);
                        var listOfHamstersMalesTop6 = listOfHamsters.Where(hamster => hamster.GenderId == 2).Take(4);

                        var averageSpaFemales = listOfHamstersTop6.Average(h => h.AmountOfSpaVisits);
                        var averageSpaMales = listOfHamstersMalesTop6.Average(h => h.AmountOfSpaVisits);

                        if (averageSpaFemales < averageSpaMales)
                        {
                            foreach (var hamster in listOfHamstersTop6)
                            {
                                area.AmountInArea++;
                                hamster.ActivityId = 5;
                                hamster.AmountOfSpaVisits++;
                                hamster.StartTimeSpa = CurrentTime;
                                hamsterContext.SaveChanges();
                                allinfo.Hamster = hamster;
                                ReportEventHandler?.Invoke(this, allinfo);

                                hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 5 });
                                hamsterContext.SaveChanges();

                            }
                        }
                        else
                        {
                            foreach (var hamster in listOfHamstersMalesTop6)
                            {
                                area.AmountInArea++;
                                hamster.ActivityId = 5;
                                hamster.AmountOfSpaVisits++;
                                hamster.StartTimeSpa = CurrentTime;
                                hamsterContext.SaveChanges();
                                allinfo.Hamster = hamster;
                                ReportEventHandler?.Invoke(this, allinfo);

                                hamsterContext.Logg_Activities.Add(new Logg_Activities { Timestamp = CurrentTime, Hamster = hamster, ActivityId = 5 });
                                hamsterContext.SaveChanges();

                            }
                        }

                    }

                }

            }
        }
        /// <summary>
        /// This function makes it possible to pause the simulation
        /// </summary>
        internal void Pause()
        {
            if (AmountOfTicks > CurrentAmountOfTicks)
            {
                if (IsRunning)
                {
                    IsRunning = false;
                    Console.WriteLine("Paused, Press enter to continue");
                    Tick.Change(Timeout.Infinite, Timeout.Infinite);
                }
                else
                {
                    IsRunning = true;
                    Console.WriteLine("Resuming simulation");
                    Tick.Change(1000, TimeOfOneTick);
                }
            }
            else
            {
                ConsoleKey input = ConsoleKey.Enter;
                if (input == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
            }

        }

    }
}

