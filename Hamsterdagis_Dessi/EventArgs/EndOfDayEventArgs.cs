using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_database;

namespace Hamsterdagis_Dessi
{
    public class EndOfDayEventArgs : EventArgs
    {
        public Logg_Activities Logg_Activities { get; set; }
    
    }
}
