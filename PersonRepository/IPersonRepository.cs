using System.Collections.Generic;

namespace TimeSheet.DB
{
    public interface IPersonRepository : IRepository<Person>
    {
        IReadOnlyCollection<Person> Get(string personName);
        IReadOnlyCollection<Person> Get(int skip, int take);
    }
}
