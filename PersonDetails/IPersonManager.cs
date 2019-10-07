using PersonDetails.Models;
using System.Collections.Generic;

namespace PersonDetails
{
    public interface IPersonManager
    {
        List<Persons> GetAll();
    }
}