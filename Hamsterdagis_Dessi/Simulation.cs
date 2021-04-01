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
            CurrentAmountOfTicks++;
            CurrentTime = SimulationStart.AddMinutes(CurrentAmountOfTicks * 6);
            Task task1 = new Task(checkIn);
            task1.Start();
            //allinfo.TimeWaited = (TimeSpan)(hamster.TimeWaited);
        }
        public void OnEvery60Tick(Object state)
        {
            //Här ska metoden som checkar ut hamstrar från exercisearea vara. 
        }
        public void StartSimulation(int days, int minutesOfSimulation)
        {
            //checkIn();//Alla hamstrar checkas in och får Incheckningsdatum samt status "arrival"
            ////Sen ska hamstrarna läggas i sina burar, 3 i varje bur och de måste vara av samma kön. 
            //PutInCageFemales();
            //PutInCageMales();

            //moveToExerciseFemales();

            //checkOutFromExArea();

            moveToExerciseMale();


            //while (AmountOfTicks >= CurrentAmountOfTicks)
            //{
            //    AmountOfTicks = days * 100;
            //    TimeOfOneTick = ((minutesOfSimulation * 60) / AmountOfTicks) * 1000;
            //    SimulationStart = new DateTime(2021, 03, 26, 07, 00, 00);
            //    Tick = new Timer(new TimerCallback(OnTick), null, 1000, TimeOfOneTick);
            //    // Simulation ska pågå tills att CurrentTicks är lika mycket som AmountOfTicks. 

            //}


        }

        public void PutInCageFemales()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                // Den ska ta ut alla honor och lägga dme i en lista
                // Sedan ska honorna få status "DayCage och bli tilldelade en bur
                // Sedan ska honorna tas ut ur listan
                // Detta ska hållas på sålänge som listan inte är 0 i antal

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
                hamsterContext.Hamsters.Where(hamster => hamster.ActivityId == 3)
                     .ToList()
                     .ForEach(hamster => hamster.ActivityId = 2);

               var area = hamsterContext.ExerciseAreas.Where(area => area.AmountInArea > 0).First();
                area.AmountInArea = 0;

                hamsterContext.SaveChanges();

                Console.WriteLine("No hamsters in exercisearea");
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
                    CountingExerciseTick = 0;
                    var listOfFemalesNoExercise = hamsterContext.Hamsters.Where(hamster => hamster.TimeForLastExercise == null)
                        .Where(hamster => hamster.Gender.Id == 1)
                        .Take(6)
                        .ToList();

                    var area = hamsterContext.ExerciseAreas.Where(area => area.Id == 1).First();
                    area.AmountInArea = listOfFemalesNoExercise.Count();

                    foreach (var hamster in listOfFemalesNoExercise)
                    {
                        hamster.ActivityId = 3;
                        hamster.TimeForLastExercise = CurrentTime;
                        hamsterContext.SaveChanges();

                        Console.WriteLine($"{hamster.Hamster_Name} is in the exercisearea");

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
                    CountingExerciseTick = 0;
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

                        Console.WriteLine($"{hamster.Hamster_Name} is in the exercisearea");

                    }
                }
            }

        }

        public void moveFromExercise()
        {

        }
    }
}

