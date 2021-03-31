using System;

namespace BackEnd_database
{
    public class Hamster
    {

        public int Id { get; set; }
        public string Hamster_Name { get; set; }
        public int Age { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? TimeForLastExercise { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
