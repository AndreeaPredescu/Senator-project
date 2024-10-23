using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Models
{
    public class Soldier
    {
        public int SoldierId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CountryId { get; set; }
        public int RankId { get; set; }
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
        public virtual Country Country { get; set; }
        public virtual Rank Rank { get; set; }
    }
}
