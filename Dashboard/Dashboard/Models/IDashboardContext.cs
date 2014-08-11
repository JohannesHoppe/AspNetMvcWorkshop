using System.Data.Entity;

namespace Dashboard.Models
{
    public interface IDashboardContext
    {
        IDbSet<Gutachter> Gutachter { get; set; }
        IDbSet<Gutachten> Gutachten { get; set; }
        int SaveChanges();
    }
}