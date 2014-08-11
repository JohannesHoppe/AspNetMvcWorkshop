using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace Dashboard.Models
{
    public class DashboardContext : DbContext
    {
        public DashboardContext()
            : base("DashboardContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Gutachter> Gutachter { get; set; }
        public DbSet<Gutachten> Gutachten { get; set; }
    }
}