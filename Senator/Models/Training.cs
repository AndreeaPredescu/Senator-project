using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
