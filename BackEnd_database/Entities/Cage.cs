using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ //OBS! Max 3 hamstrar per bur
    // Finns endast 10 burar
    // En Cage kan ha flera hamstrar
    // En hamster kan bara ha en Cage
    public class Cage
    {
        public int Id { get; set; }
        public int AmountInCage { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }

    }
}
