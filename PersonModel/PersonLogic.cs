using System;
using System.Collections.Generic;
using System.Linq;

using TimeSheet.DB;

namespace TimeSheet.BisnesLogic
{
    public class PersonLogic
    {
        public Person AddNewPerson(Repository repository, Person newPerson)
        {
            repository.PersonList.Add(newPerson);
            return newPerson;
        }

        public Person GetPerson(Repository repository, int personId)
        {
            var personById = repository.PersonList.Where(x => x.Id == personId);

            return personById.FirstOrDefault();
        }

        public IEnumerable<Person> GetPerson(Repository repository, string nameToSearch)
        {
            return repository.PersonList.Where(x => x.FirstName.ToLower() == nameToSearch.ToLower());
        }

        public IEnumerable<Person> GetPerson(Repository repository, int skip, int take)
        {
            if (skip >= repository.PersonList.Count)
            {
                return null;
            }

            var maxValue = repository.PersonList.Count > take + skip
                ? take + skip : repository.PersonList.Count;

            var result = new List<Person>();

            for (int i = skip; i < maxValue; i++)
            {
                result.Add(repository.PersonList[i]);
            }

            return result;
        }

        public Person UpdatePerson(Repository repository, Person newPersonData)
        {
            if (!(repository.PersonList?.Count > 0)) return null;

            var personToUpdate = GetPerson(repository, newPersonData.Id);

            personToUpdate.FirstName = newPersonData.FirstName;
            personToUpdate.LastName = newPersonData.LastName;
            personToUpdate.Age = newPersonData.Age;
            personToUpdate.Company = newPersonData.Company;
            personToUpdate.Email = newPersonData.Email;

            return personToUpdate;
        }

        public bool DeletePerson(Repository repository, int id)
        {
            if (!(repository.PersonList?.Count > 0)) return false;

            var personToDelete = GetPerson(repository, id);

            repository.PersonList.Remove(personToDelete);

            return true;
        }
    }
}
