﻿using System.Collections.Generic;
using System.Linq;
using GraphQlBasicApi.Data;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Models;

namespace GraphQlBasicApi.Services
{
    public class PersonService : IPerson
    {
        private readonly PersonDbContext _dbContext;

        public PersonService(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person AddPerson(Person person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return person;
        }

        public void DeletePerson(int id)
        {
            var personObj = _dbContext.Persons.Find(id);
            _dbContext.Persons.Remove(personObj);
            _dbContext.SaveChanges();
        }

        public List<Person> GetAllPersons()
        {
            return _dbContext.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _dbContext.Persons.Find(id);
        }

        public Person UpdatePerson(int id, Person person)
        {
            var personObj = _dbContext.Persons.Find(id);
            personObj.Name = person.Name;
            personObj.Country = person.Country;
            personObj.Phone = person.Phone;
            personObj.Score = person.Score;
            _dbContext.SaveChanges();
            return person;
        }
    }
}