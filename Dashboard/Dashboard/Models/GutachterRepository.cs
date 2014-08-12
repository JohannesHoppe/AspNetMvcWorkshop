using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Models
{
    public class GutachterRepository : IGutachterRepository
    {

        public GutachterRepository(IDashboardContext context)
        {
            _context = context;
        }

        public int Create(string vorname, string nachname, string mail)
        {
            var newItem = new Gutachter {  EMail = mail, Nachname = nachname, Vorname = vorname };
            _context.Gutachter.Add(newItem);
            _context.SaveChanges();
            return newItem.Id;
        }

        public void Delete(int id)
        {
            var removableItem = Read(id);
            _context.Gutachter.Remove(removableItem);
            _context.SaveChanges();
        }

        public Gutachter Read(int id)
        {
            return _context.Gutachter.SingleOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Gutachter> ReadAll()
        {
            return _context.Gutachter.ToList();
        }

        public void Update(Gutachter gutachter)
        {
            var value = Read(gutachter.Id);



            if (value != null)
            {
                value.EMail = gutachter.EMail;
                value.Vorname = gutachter.Vorname;
                value.Nachname = gutachter.Nachname;
                _context.SaveChanges(); 
            }
        }
    }
}