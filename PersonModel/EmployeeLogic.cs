using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeLogic(IEmployeeRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<Employee> AddNewEmployeeAsync(CancellationTokenSource token,  BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(token, entity))
            {
                return (Employee)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByIdAsync(CancellationTokenSource token,  int id)
        {
            var entityFromBase = await _repository.GetAsync(token, id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByNameAsync(CancellationTokenSource token,  string nameToSearch)
        {
            return await _repository.GetAsync(token,  nameToSearch);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByRangeAsync(CancellationTokenSource token,  int skip, int take)
        {
            var result = await _repository.GetAsync(token,  skip, take);

            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(CancellationTokenSource token,  BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(token,  entity);

            return updateUser;
        }

        public async Task<bool> DeleteEmployeeAsync(CancellationTokenSource token,  int id)
        {
            return await _repository.DeleteAsync(token,  id);
        }
    }
}
