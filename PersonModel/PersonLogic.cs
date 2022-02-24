using System.Collections.Generic;

using TimeSheet.DB;

namespace TimeSheet.BusinessLogic
{
    public class PersonLogic
    {
        private readonly IPersonRepository _repository;
        public PersonLogic(IPersonRepository repository)
        {
            _repository = repository;
        }
        
        public Person GetPerson(int personId)
        {
            var personById = _repository.Get(personId);

            return personById;
        }

        public IEnumerable<Person> GetPerson(string personName)
        {
            return _repository.Get(personName);
        }

        public IEnumerable<Person> GetPerson(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Person AddNewPerson(Person newPerson)
        {
            return _repository.Add(newPerson);
        }

        public Person UpdatePerson(Person newPersonData)
        {
            return newPersonData == null ? null : _repository.Update(newPersonData);
        }

        public bool DeletePerson(int id)
        {
            return _repository.Delete(id);
        }
    }
}
