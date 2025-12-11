using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment6Final
{
    public class PersonContextDataSource : IPersonDataSource
    {
        private readonly PersonContext _db;

        public PersonContextDataSource()
        {
            _db = new PersonContext();
            _db.Database.EnsureCreated();
            _db.People.Load();
        }

        public IEnumerable<Person> GetPeople() =>
            _db.People.Local.ToBindingList();

        public IEnumerable<Person> GetPeople(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return GetPeople();

            return _db.People.Local
                .Where(p => p.Name.ToLower().Contains(filter.ToLower()))
                .ToList();
        }

        public void Add(Person person) => _db.People.Add(person);
        public void Delete(Person person) => _db.People.Remove(person);
        public void SaveChanges() => _db.SaveChanges();
    }
}
