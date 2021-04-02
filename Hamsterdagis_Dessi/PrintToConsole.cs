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
            Console.WriteLine($"{args.Hamster.ToString()} moved to activity : {args.Hamster.Activity.Name}");
        }

    }
}
