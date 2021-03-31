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
        public virtual Activity Activity { get; set; }
        public virtual Hamster Hamster { get; set; }
    }
}
