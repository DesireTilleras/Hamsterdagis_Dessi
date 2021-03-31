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
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
