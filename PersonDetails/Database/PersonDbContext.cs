using PersonDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonDetails.Database
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext() : base("name=DefaultConnection")
        {
           // Database.SetInitializer<PersonDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Persons> Persons { get; set; }

    }
}