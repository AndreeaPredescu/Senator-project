using Senator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Senator.Services
{
    public class SoldierService
    {
        private readonly SenatorContext _context;

        public SoldierService()
        {
            _context = new SenatorContext();
        }

        public SoldierService(SenatorContext context)
        {
            _context = context;
        }

        public List<Soldier> GetAllSoldiers()
        {
            
                return _context.Soldiers.Include(s => s.Rank)
                                       .Include(s => s.Country)
                                       .Include(s => s.Training)
                                       .ToList();
            
        }
    }
}
