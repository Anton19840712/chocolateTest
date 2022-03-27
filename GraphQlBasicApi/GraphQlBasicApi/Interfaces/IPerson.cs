using System.Collections.Generic;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Interfaces
{
    public interface IPerson
    {
        List<Person> GetAllPersons();
        Person AddPerson(Person person);
        Person UpdatePerson(int id, Person person);
        void DeletePerson(int id);
        Person GetPersonById(int id);
    }
}