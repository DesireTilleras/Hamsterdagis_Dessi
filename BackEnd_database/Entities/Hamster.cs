using System;
using System.Collections.Generic;

namespace BackEnd_database
{
    public class Hamster
    {
        public int Id { get; set; }
        public string Hamster_Name { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int? CageId { get; set; }
        public virtual Cage Cage { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? TimeForLastExercise { get; set; }

        //public TimeSpan? TimeWaited { get; set; }        

        public virtual ICollection<Logg_Activities> Logg_Activities { get; set; } 

        public Hamster()
        {
            
        }
    }
}
