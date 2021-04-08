using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using BackEnd_database;
using System.IO;

namespace Hamsterdagis_Dessi
{
    public class Simulation
    {
        public Simulation()
        {
            hamster = new Hamster();
        }

        Hamster hamster;

        public DateTime SimulationStart { get; set; }

        static Timer Tick = null;
        public DateTime CurrentTime { get; set; }
                      
        public int AmountOfTicks { get; set; } 
        public int CurrentAmountOfTicks { get; set; }

        public int TimeOfOneTick { get; set; }

        public int CountingDaysTick { get; set; }

        public event EventHandler<ReportEventArgs> ReportEventHandler;
        ReportEventArgs allinfo = new ReportEventArgs();

        public event EventHandler<EndOfDayEventArgs> EndOfDayReport;
        EndOfDayEventArgs DayReport = new EndOfDayEventArgs();

        public event EventHandler<TimeEventArgs> TimeReport;
        TimeEventArgs Time = new TimeEventArgs();

        public event EventHandler<HamsterInfoEventArgs> HamsterInfo;
        HamsterInfoEventArgs hamsterInfo = new HamsterInfoEventArgs();


        public void OnTick(Object state)
        {
            if (AmountOfTicks > CurrentAmountOfTicks)
            {
                Time.CurrentTime = CurrentTime;
                TimeReport?.Invoke(this, Time);

                CurrentTime = CurrentTime.AddMinutes(6);

                Task task1 = new Task(moveToExercise);
                Task task2 = new Task(checkOutFromExArea);
                Task task4 = new Task(checkOutDay);
                Task task5 = new Task(checkIn);
                Task task6 = new Task(PutInCageFemales);
                Task task7 = new Task(PutInCageMales);
                Task task8 = new Task(NewDay);

                CurrentAmountOfTicks++;

                task5.Start();
                task5.Wait();
                task6.Start();
                task6.Wait();

                task7.Start();
                task7.Wait();

                task1.Start();
                task1.Wait();

                task2.Start();
                task2.Wait();

                task4.Start();
                task4.Wait();

                task8.Start();
                task8.Wait();


                if (CurrentAmountOfTicks > AmountOfTicks)
                {
                    checkOutFromExArea();
                    checkOutDay();
                    ClearLoggFile();

                }


            }
        }

        public void StartSimulation(int days, int minutesOfSimulation)
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
                Console.WriteLine("End");

            }
        }

        public void ClearLoggFile()
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
        public void NewDay()
        {
            if (CurrentTime.Hour == 17 && CurrentTime.Minute == 18)
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
                Console.WriteLine($"New day Day : {CurrentTime}");
            }

        }

        public void checkOutDay()
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
                        hamster.AmountOfExercises = 0;
                    };

                    hamsterContext.Cages.Select(cages => cages)
                       .ToList()
                       .ForEach(cage => cage.AmountInCage = 0);

                    hamsterContext.ExerciseAreas.Select(area => area).ToList().ForEach(area => area.AmountInArea = 0);
                    hamsterContext.SaveChanges();
                }
            }
        }

        public void PutInCageFemales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                lock (this)
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
        public void PutInCageMales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                lock (this)
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

        public void checkIn()
        {
            lock (this)
            {
                if (CurrentTime.Hour == 7)
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

        }

        public void checkOutFromExArea()
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

        public bool checkIfAreaIsFree()
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

        public void moveToExercise()
        {
            using (var hamsterContext = new HamsterAppContext())
            {

                if (checkIfAreaIsFree())
                {
                    if (CurrentTime.Minute == 18 && CurrentTime.Hour < 17 && CurrentTime.Hour > 7)
                    {
                         var area = hamsterContext.ExerciseAreas.Single(area => area.Id == 1);

                        var listOfHamsters = hamsterContext.Hamsters.Select(h=>h)
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


    }
}

