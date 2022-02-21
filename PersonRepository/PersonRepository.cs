using System.Collections.Generic;
using System.Linq;

namespace TimeSheet.DB
{
    public class PersonRepository : IPersonRepository
    {
        public Person Get(int personId)
        {
            return Repository._personsList.Where(x => x.Id == personId)?.First();
        }

        public IReadOnlyCollection<Person> Get(string personName)
        {
            return Repository._personsList.Where(x => x.FirstName == personName).ToList();
        }

        public IReadOnlyCollection<Person> Get(int skip, int take)
        {
            if (skip >= Repository._personsList.Count)
            {
                return null;
            }

            var maxValue = Repository._personsList.Count > take + skip
                ? take + skip : Repository._personsList.Count;

            var result = new List<Person>();

            for (int i = skip; i < maxValue; i++)
            {
                result.Add(Repository._personsList[i]);
            }

            return result;
        }

        public Person Add(Person newPerson)
        {
            Repository._personsList.Add(newPerson);
            return newPerson;
        }

        public Person Update(Person newEntity)
        {
            if (!(Repository._personsList?.Count > 0)) return null;

            var personToUpdate = Get(newEntity.Id);

            if (personToUpdate == null) return null;

            personToUpdate.FirstName = newEntity.FirstName;
            personToUpdate.LastName = newEntity.LastName;
            personToUpdate.Age = newEntity.Age;
            personToUpdate.Company = newEntity.Company;
            personToUpdate.Email = newEntity.Email;

            return personToUpdate;
        }

        public bool Delete(int newPerson)
        {
            if (!(Repository._personsList?.Count > 0)) return false;

            var personToDelete = Get(newPerson);

            if (personToDelete == null) return false;

            Repository._personsList.Remove(personToDelete);

            return true;
        }
    }
}