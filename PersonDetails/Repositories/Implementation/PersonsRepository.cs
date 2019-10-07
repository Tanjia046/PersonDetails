using PersonDetails.Models;
using PersonDetails.Repositories.Interface;
using System.Data.Entity;

namespace PersonDetails.Repositories.Implementation
{
    public class PersonsRepository : Repository<Persons>, IPersonsRepository
    {
        public PersonsRepository(DbContext context) : base(context) { }
     
    }
}