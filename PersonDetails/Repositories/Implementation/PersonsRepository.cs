using PersonDetails.Database;
using PersonDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonDetails.Repositories.Implementation
{
    public class PersonsRepository : Repository <Persons>, IPersonsRepository
    {

        public PersonsRepository(DbContext context) : base(context) { }

        PersonDbContext db = new PersonDbContext();
        public IList<Persons> GetEmployees()
        {
            var data = db.Persons.ToList();

            return data;
        }







    }



}