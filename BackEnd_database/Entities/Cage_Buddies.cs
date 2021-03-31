using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ 
    public class Cage_Buddies
    {
        public int Id { get; set; }
        public int AmountOfBuddies { get; set; }
        public virtual Cage Cage { get; set; }
        public virtual Gender GenderInCage { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }

    }
}
