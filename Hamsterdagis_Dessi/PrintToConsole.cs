using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamsterdagis_Dessi
{
    class PrintToConsole
    {
        public void PrintReport(object sender, ReportEventArgs args)
        {
            lock (this)
            {
                Console.WriteLine($"{args.Hamster.ToString()} moved to activity : {args.Hamster.Activity.Name}");
            }
            
        }
        public void PrintEndOfDay(object sender, EndOfDayEventArgs args)
        {
            
            lock (this)
            {
                Console.WriteLine($"{args.Logg_Activities.ToString()}");

            }
        }

        public void PrintTime(object sender, TimeEventArgs args)
        {
            Console.WriteLine($"{args.CurrentTime}");
        }

    }
}
