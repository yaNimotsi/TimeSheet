using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.DB;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly MyDBContext _context;
        private readonly IEmployeeRepository _repository;
        public EmployeeLogic(MyDBContext context, IEmployeeRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Employee> AddNewEmployeeAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(token, _context, entity))
            {
                return (Employee)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByIDAsync(CancellationTokenSource token, int id)
        {
            var entityFromBase = await _repository.GetAsync(token, _context, id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByNameAsync(CancellationTokenSource token, string nameToSearch)
        {
            return await _repository.GetAsync(token, _context, nameToSearch);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByRangeAsync(CancellationTokenSource token, int skip, int take)
        {
            var result = await _repository.GetAsync(token, _context, skip, take);

            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(token, _context, entity);

            return updateUser;
        }

        public async Task<bool> DeleteEmployeeAsync(CancellationTokenSource token, int id)
        {
            return await _repository.DeleteAsync(token, _context, id);
        }
    }
}
