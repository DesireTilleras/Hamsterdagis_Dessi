using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using BackEnd_database;

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

        public DateTime CurrentTime { get; set; } // CurrentTime är StartTime + antal ticks * 6 min. //Om användaren väljer 3 dagar, så skall
                                                  // det blir 300 ticks. Efter 100 ticks, så ökar datumet med en dag och klockan är 07.00 igen. 
                                                  //Om StartTime är 2021-03-26-07-00-00, efter 100 ticks, så blir StartTime = 2021-03-27-07-00-00 osv.
        public int AmountOfTicks { get; set; } // Ett tick är 6 min. Men efter 100 tick, så är dagen slut och StartTime blir samma fast + 1 dag. 
        //Ticken bestäms när användaren fyller i hur många dagar som den vill att simuleringen ska ske. 
        // 3 dagar = 300 ticks. 

        public int CurrentAmountOfTicks { get; set; }// Ticken börjar på 1 och går så långt som användaren väljer. Så om det gått 10 tick, så 
        // har det gått 6 min per tick, alltså 60 min. 

        public int TimeOfOneTick { get; set; }

        public int CountingExerciseTick { get; set; } // Den här börjar räkna när 6 nya hamstrar går in i motionsytan. 
        // När den nått till 60 ticks, så ska hamstrarna ut och 6 nya hamstrar in och då resetar den till 0 igen. 

        public event EventHandler<ReportEventArgs> ReportEventHandler;
        ReportEventArgs allinfo = new ReportEventArgs();


        public void OnTick(Object state)
        {
            if (CurrentAmountOfTicks <= AmountOfTicks)
            {
                CurrentAmountOfTicks++;
                CurrentTime = SimulationStart.AddMinutes(CurrentAmountOfTicks * 6);
                Task task1 = new Task(moveToExerciseFemales);
                Task task2 = new Task(checkOutFromExArea);
                Task task3 = new Task(moveToExerciseMale);
                task1.Start();
                task1.Wait();
                CountingExerciseTick++;
                task3.Start();
                task3.Wait();

                if (CountingExerciseTick == 10)
                {
                    task2.Start();
                    task2.Wait();
                    CountingExerciseTick = 0;
                }

                Console.WriteLine($"{CurrentAmountOfTicks}   {CountingExerciseTick} ");
            }
         }
        public void OnEvery60Tick(Object state)
        {
            //Här ska metoden som checkar ut hamstrar från exercisearea vara. 
        }
        public void StartSimulation(int days, int minutesOfSimulation)
        {
            SimulationStart = new DateTime(2021, 03, 26, 07, 00, 00);
            checkIn();//Alla hamstrar checkas in och får Incheckningsdatum samt status "arrival"
            //Sen ska hamstrarna läggas i sina burar, 3 i varje bur och de måste vara av samma kön. 
            PutInCageFemales();
            PutInCageMales();

            AmountOfTicks = days * 100;
            float timeOfTick = (minutesOfSimulation * 60F / AmountOfTicks) * 1000F;
            TimeOfOneTick = (int)timeOfTick;
            
            Tick = new Timer(new TimerCallback(OnTick), null, 1000, TimeOfOneTick);
            
            if (AmountOfTicks <= CurrentAmountOfTicks)
            {
                Tick.Dispose();
                Console.WriteLine("End");

            }
        }

        public void PutInCageFemales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                var listOfFemales = hamsterContext.Hamsters.Where(hamster => hamster.Gender.Id == 1).ToList();

                while (listOfFemales.Count != 0)
                {
                    var topThree = listOfFemales.OrderBy(hamster => hamster.Age).Take(3);

                    foreach (var hamster in topThree)
                    {
                        hamster.ActivityId = 2;
                        var cage = hamsterContext.Cages.Where(cage => cage.AmountInCage < 3).OrderBy(cage => cage.Id).First();
                        cage.AmountInCage++;
                        hamster.CageId = cage.Id;
                        listOfFemales.Remove(hamster);
                        hamsterContext.SaveChanges();

                    }

                }

            }
        }
        public void PutInCageMales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                var listOfMales = hamsterContext.Hamsters.Where(hamster => hamster.Gender.Id == 2).ToList();

                while (listOfMales.Count != 0)
                {
                    var topThree = listOfMales.OrderBy(hamster => hamster.Age).Take(3);

                    foreach (var hamster in topThree)
                    {
                        hamster.ActivityId = 2;
                        var cage = hamsterContext.Cages.Where(cage => cage.AmountInCage < 3).OrderBy(cage => cage.Id).First();
                        cage.AmountInCage++;
                        hamster.CageId = cage.Id;
                        listOfMales.Remove(hamster);
                        hamsterContext.SaveChanges();

                    }

                }

            }
        }

        public void checkIn()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                hamsterContext.Hamsters.Where(hamster => hamster.Activity == null)
                    .ToList()
                    .ForEach(hamster => hamster.ActivityId = 1);
                hamsterContext.SaveChanges();

                hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == 1)
                            .ToList()
                            .ForEach(hamster => hamster.CheckInTime = SimulationStart);


                hamsterContext.SaveChanges();
                Console.WriteLine("All hamsterns are now checked in");

                // Hamstrarna ska endast checkas in en gång??
            }
        }

        public void checkOutFromExArea()
        {
            // alla hamstrar som just nu är i exercisearea, ska checkas ut och amountInArea ska sättas till 0 igen. 

            using (var hamsterContext = new HamsterAppContext())
            {
                var area = hamsterContext.ExerciseAreas.Single(area => area.AmountInArea >= 0);
                area.AmountInArea = 0;

                var listOfHamsters = hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == 3)
                      .ToList();

                foreach (var hamster in listOfHamsters)
                {
                    hamster.ActivityId = 2;
                    if (hamster.TimeForFirstExercise == null)
                    {
                        hamster.TimeForFirstExercise = hamster.TimeForLastExercise;
                        hamster.TimeWaited = CurrentTime - SimulationStart;
                    }
                    else
                    {
                        hamster.TimeWaited = hamster.TimeForFirstExercise - SimulationStart;
                    }
                    hamster.TimeForLastExercise = CurrentTime;

                    hamsterContext.Logg_Activities.Add(new Logg_Activities { HamsterId = hamster.Id, Timestamp = CurrentTime, ActivityId = 2 });
                    allinfo.Hamster = hamster;
                    ReportEventHandler?.Invoke(this, allinfo);
                    
                }
                hamsterContext.SaveChanges();
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

        public void moveToExerciseFemales()
        {
            //Gör en lista på de hamstrar som ännu inte fått motion
            using (var hamsterContext = new HamsterAppContext())
            {
                if (checkIfAreaIsFree())
                {                    
                    var listOfFemalesNoExercise = hamsterContext.Hamsters.Where(hamster => hamster.TimeForLastExercise == null)
                        .Where(hamster => hamster.Gender.Id == 1)
                        .Take(6)
                        .ToList();
                    var listOfFemalesLastExercise = hamsterContext.Hamsters.OrderByDescending(hamster => hamster.TimeWaited)
                        .Where(hamster => hamster.Gender.Id == 1)
                        .Take(6 - listOfFemalesNoExercise.Count())
                        .ToList();

                    if (listOfFemalesLastExercise.Count() > 0 && listOfFemalesNoExercise.Count() < 6)
                    {
                        foreach (var hamster in listOfFemalesLastExercise)
                        {
                            listOfFemalesNoExercise.Add(hamster);
                        }
                    }

                    var area = hamsterContext.ExerciseAreas.Single(area => area.Id == 1);
                    area.AmountInArea = listOfFemalesNoExercise.Count();
                    hamsterContext.SaveChanges();

                    foreach (var hamster in listOfFemalesNoExercise)
                    {
                        hamster.ActivityId = 3;
                        hamster.TimeForLastExercise = CurrentTime;
                        hamsterContext.SaveChanges();

                        if (hamster.TimeForFirstExercise == null)
                        {
                            hamster.TimeForFirstExercise = hamster.TimeForLastExercise;
                            hamsterContext.SaveChanges();
                        }   
                        hamster.TimeWaited = hamster.TimeForFirstExercise- SimulationStart;
                        hamsterContext.SaveChanges();
                        allinfo.Hamster = hamster;
                        ReportEventHandler?.Invoke(this, allinfo);

                    }
                    
                }
            }
        }

        public void moveToExerciseMale()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                if (checkIfAreaIsFree())
                {
                    
                    var listOfFemalesNoExercise = hamsterContext.Hamsters.Where(hamster => hamster.TimeForLastExercise == null)
                        .Where(hamster => hamster.Gender.Id == 2)
                        .Take(6)
                        .ToList();

                    var area = hamsterContext.ExerciseAreas.Where(area => area.Id == 1).First();
                    area.AmountInArea = listOfFemalesNoExercise.Count();

                    foreach (var hamster in listOfFemalesNoExercise)
                    {
                        hamster.ActivityId = 3;
                        hamster.TimeForLastExercise = CurrentTime;
                        hamsterContext.SaveChanges();
                        allinfo.Hamster = hamster;
                        ReportEventHandler?.Invoke(this, allinfo);
                    }
                }
            }

        }


    }
}

