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

        public void StartSimulation(int days, int minutesOfSimulation)
        {
            while (AmountOfTicks >= CurrentAmountOfTicks)
            {
                AmountOfTicks = days * 100;
                TimeOfOneTick = ((minutesOfSimulation * 60) / AmountOfTicks) * 1000;
                SimulationStart = new DateTime(2021, 03, 26, 07, 00, 00);
                Tick = new Timer(new TimerCallback(OnTick), null, 1000, TimeOfOneTick);
                // Simulation ska pågå tills att CurrentTicks är lika mycket som AmountOfTicks. 

            }
           

        }


        //Gör en metod som checkar in hamstrar
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

        public void checkOut()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                //När 100 tick har gått, så skall alla hamstrar checkas ut. 
            }
        }

        public void moveToExercise()
        {

        }

        public void moveFromExercise()
        {

        }
    }
}
