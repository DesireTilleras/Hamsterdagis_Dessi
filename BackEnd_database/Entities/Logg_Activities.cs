using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ // Loggen ska skriva ut hur länge hamstern fick vänta innan motion
    // En hamster kan ha flera loggar
    // En logg kan bara ha en hamster
    // En logg kan ha flera aktiviteter 
    // En aktivitet kan ha flera hamstrar
    public class Logg_Activities
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public override string ToString()
        {
            return $"{Hamster.Hamster_Name}"; 
        }

    }
}
