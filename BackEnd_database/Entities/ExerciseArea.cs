using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{ // OBS!! Max 6 hamstrar i motionsområdet samtidigt
    public class ExerciseArea
    {
        public int Id { get; set; }
        public int AmountInArea { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
