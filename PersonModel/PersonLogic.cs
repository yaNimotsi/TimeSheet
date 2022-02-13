using System;
using System.Collections.Generic;
using System.Linq;
using PersonRepository;


namespace PersonModel
{
    public class PersonLogic
    {
        private Repository GetRepository()
        {
            return new Repository();
        }
        public void AddNewPerson(Person newPerson)
        {
            var repository = GetRepository();
            repository.PersonList.Add(newPerson);
        }

        public Person GetPerson(int personId)
        {
            var repository = GetRepository();
            var personById = repository.PersonList.Where(x => x.Id == personId);

            return personById.FirstOrDefault();
        }

        public IEnumerable<Person> GetPerson(string nameToSearch)
        {
            var repository = GetRepository();
            return repository.PersonList.Where(x => x.FirstName == nameToSearch);
        }

        public IEnumerable<Person> GetPerson(int skip, int take)
        {
            var repository = GetRepository();

            if (skip >= repository.PersonList.Count)
            {
                return null;
            }

            var maxValue = repository.PersonList.Count > take 
                ? take : repository.PersonList.Count;

            var result = new List<Person>();

            for (int i = skip; i < maxValue; i++)
            {
                result.Add(repository.PersonList[i]);
            }

            return result;
        }

        public Person UpdatePerson(int id, Person newPersonData)
        {
            var repository = GetRepository();

            if (!(repository.PersonList?.Count > 0)) return null;

            var personToUpdate = GetPerson(id);

            personToUpdate.Id = newPersonData.Id;
            personToUpdate.FirstName = newPersonData.FirstName;
            personToUpdate.LastName = newPersonData.LastName;
            personToUpdate.Age = newPersonData.Age;
            personToUpdate.Company = newPersonData.Company;
            personToUpdate.Email = newPersonData.Email;

            return personToUpdate;
        }

        public bool DeletePerson(int id)
        {
            var repository = GetRepository();

            if (!(repository.PersonList?.Count > 0)) return false;

            var personToDelete = GetPerson(id);

            repository.PersonList.Remove(personToDelete);

            return true;
        }
    }
}
