using System.Collections.Generic;
using Build93.MultiTenancy.Example.BL.Model;

namespace Build93.MultiTenancy.Example.BL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Build93.MultiTenancy.Example.BL.Model.ExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Build93.MultiTenancy.Example.BL.Model.ExampleContext context)
        {
            var tenants = new List<Tenant>
            {
                new Tenant {Id = 1, Domain = "www.example.com"},
                new Tenant {Id = 2, Domain = "localhost"}

            };

            foreach (var t in tenants)
            {
                context.Tenants.Add(t);
            }


            var courses = new List<Course>
            {
                new Course {TenantId = 1, Name = "www.example.com Course 1"},
                new Course {TenantId = 2, Name = "localhost Course 1"},
                new Course {TenantId = 1, Name = "www.example.com Course 2"},
                new Course {TenantId = 2, Name = "localhost Course 2"},
                new Course {TenantId = 1, Name = "www.example.com Course 3"},
                new Course {TenantId = 2, Name = "localhost Course 3"},
                new Course {TenantId = 1, Name = "www.example.com Course 4"},
                new Course {TenantId = 2, Name = "localhost Course 4"},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}
