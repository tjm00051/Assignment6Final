using System.Collections.Generic;

namespace Assignment6Final
{
    public interface IPersonDataSource
    {
        IEnumerable<Person> GetPeople();
        IEnumerable<Person> GetPeople(string filter);
        void Add(Person person);
        void Delete(Person person);
        void SaveChanges();
    }
}
