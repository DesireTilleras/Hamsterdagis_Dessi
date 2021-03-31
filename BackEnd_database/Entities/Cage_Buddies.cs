using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ 
    class Cage_Buddies
    {
        public int Id { get; set; }

        public Cage Cage { get; set; }

        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
