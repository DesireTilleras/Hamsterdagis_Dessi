using System.Collections.Generic;

namespace BackEnd_database
{
    public class Gender
    {
        public int Id { get; set; }
        public string Gender_Type { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}