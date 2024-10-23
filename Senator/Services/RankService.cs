using Senator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Services
{
    public class RankService
    {
        private readonly SenatorContext _context;
        public RankService()
        {
            _context = new SenatorContext();
        }

        public RankService(SenatorContext context)
        {
            _context = context;
        }

        public List<Rank> GetAllRanks()
        {
            return _context.Ranks.ToList();
            
        }
    }
}
