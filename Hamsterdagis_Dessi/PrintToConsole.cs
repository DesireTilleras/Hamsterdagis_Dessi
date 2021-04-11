using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamsterdagis_Dessi
{
    class PrintToConsole
    {
        internal  void PrintReport(object sender, ReportEventArgs args)
        {
            lock (this)
            {
                Console.WriteLine($"{args.Hamster.ToString()} moved to activity : {args.Hamster.Activity.Name}");
            }

        }
        internal void PrintEndOfDay(object sender, EndOfDayEventArgs args)
        {
            lock (this)
            {
                Console.WriteLine($"{args.Logg_Activities.ToString()} ");
            }

        }
        internal void PrintHamsterInfo(object sender, HamsterInfoEventArgs args)
        {
            lock (this)
            {
                Console.WriteLine($"{args.Hamster.Hamster_Name} has exercised {args.Hamster.AmountOfExercises} " +
                     $"times today and waited {args.Hamster.TimeWaited} before first exercise\n");
            }

        }

        internal void PrintTime(object sender, TimeEventArgs args)
        {
            lock (this)
            {
                Console.WriteLine($"{args.CurrentTime}");
            }
        }
    }
}
