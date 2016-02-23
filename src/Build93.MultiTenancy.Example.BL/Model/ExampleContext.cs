using System.Data.Entity;

namespace Build93.MultiTenancy.Example.BL.Model
{
    public class ExampleContext :DbContext
    {
        public ExampleContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
