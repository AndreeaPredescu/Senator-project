using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Models
{
    public class Rank
    {
        public int RankId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
