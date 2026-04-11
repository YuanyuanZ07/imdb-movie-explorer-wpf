// PersonService
using System.Collections.Generic;
using System.Linq;
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

        // Get all people
        public List<Names> GetAllPeople()
        {
            return _context.Names
                .OrderBy(n => n.PrimaryName)
                .Take(100)
                .ToList();
        }

        // Search people
        public List<Names> SearchPeople(string keyword)
        {
            return _context.Names
                .Where(n => n.PrimaryName != null && n.PrimaryName.Contains(keyword))
                .ToList();
        }

        // Get actors of a movie
        public List<object> GetCastByTitle(string titleId)
        {
            var query = from p in _context.Principals
                        join n in _context.Names on p.NameId equals n.NameId
                        where p.TitleId == titleId
                        select new
                        {
                            n.PrimaryName,
                            p.JobCategory,
                            p.Characters
                        };

            return query.Cast<object>().ToList();
        }
    }
}