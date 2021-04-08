using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ 
    public class Logg_Activities
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int? HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public int? ActivityId { get; set; }
        public virtual Activity Activity { get; set; }


        public override string ToString()
        {
            string activity = "";
            if (ActivityId == 1)
            {
               activity =  "Arrival";
            }
            if (ActivityId == 2)
            {
                activity = "DayCage";
            }
            if (ActivityId == 3)
            {
                activity = "Exercise";
            }
            if (ActivityId == 4)
            {
                activity = "Pick up";
            }

            return $"{Hamster.Hamster_Name}  at  {Timestamp}   {activity}  ";
        }
    }
}
