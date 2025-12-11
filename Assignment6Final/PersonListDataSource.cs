using System.Collections.Generic;
using System.Linq;

namespace Assignment6Final
{
    public class PersonListDataSource : IPersonDataSource
    {
        private readonly List<Person> _people;

        public PersonListDataSource()
        {
            _people = new()
            {
                new Person { Id = 1, Name = "Alice", Phone = "555-1000" },
                new Person { Id = 2, Name = "Bob", Phone = "555-2000" },
                new Person { Id = 3, Name = "Charlie", Phone = "555-3000" }
            };
        }

        public IEnumerable<Person> GetPeople() => _people.ToList();

        public IEnumerable<Person> GetPeople(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return GetPeople();

            return _people.Where(x =>
                x.Name.ToLower().Contains(filter.ToLower())).ToList();
        }

        public void Add(Person person) => _people.Add(person);
        public void Delete(Person person) => _people.Remove(person);

        public void SaveChanges() { }
        
    }
}
