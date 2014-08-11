using System.Collections.Generic;

namespace Dashboard.Models
{
    public class GutachterRepository : IGutachterRepository
    {
        public GutachterRepository(IDashboardContext context)
        {
            
        }

        public int Create(string vorname, string nachname, string mail)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string vorname, string nachname, string mail)
        {
            throw new System.NotImplementedException();
        }

        public Gutachter Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Gutachter> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}