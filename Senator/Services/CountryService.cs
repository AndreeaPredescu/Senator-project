using Senator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Services
{
    public class CountryService
    {
        private readonly SenatorContext _context;
        public CountryService()
        {
            _context = new SenatorContext();
        }
        public CountryService(SenatorContext context)
        {
            _context = context;
        }

        public List<Country> GetAllCountries()
        {
            
            return _context.Countries.ToList();
            
        }
    }
}
