using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ImdbWpfApp.DataAccess;

namespace ImdbWpfApp.Services
{
    public class PersonService
    {
        private readonly ImdbContext _context;

        public PersonService(ImdbContext context)
        {
            _context = context;
        }

        public List<Names> GetStarterPeople()
        {
            return _context.Names
                .AsNoTracking()
                .Where(n => n.PrimaryName != null)
                .Take(100)
                .ToList();
        }

        public List<Names> SearchPeople(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<Names>();
            }

            keyword = keyword.Trim();

            return _context.Names
                .AsNoTracking()
                .Where(n => n.PrimaryName != null &&
                            EF.Functions.Like(n.PrimaryName, $"%{keyword}%"))
                .Take(100)
                .ToList();
        }
    }
}