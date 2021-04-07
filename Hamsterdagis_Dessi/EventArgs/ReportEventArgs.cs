using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_database;

namespace Hamsterdagis_Dessi
{
    public class ReportEventArgs: EventArgs
    {
        public Hamster Hamster { get; set; }

    }
}
