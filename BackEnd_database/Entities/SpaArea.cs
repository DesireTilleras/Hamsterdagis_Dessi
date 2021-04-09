using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_database
{
    public class SpaArea
    {
        public int Id { get; set; }
        public int AmountInArea { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
