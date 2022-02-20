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
        public async Task<Employee> AddNewEmployeeAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await repository.AddAsync(token, context, entity))
            {
                return (Employee)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByIDAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, int id)
        {
            var entityFromBase = await repository.GetAsync(token, context, id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByNameAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, string nameToSearch)
        {
            return await repository.GetAsync(token, context, nameToSearch);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByRangeAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, int skip, int take)
        {
            var result = await repository.GetAsync(token, context, skip, take);

            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await repository.UpdateAsync(token, context, entity);

            return updateUser;
        }

        public async Task<bool> DeleteEmployeeAsync(CancellationTokenSource token, MyDBContext context, IEmployeeRepository repository, int id)
        {
            return await repository.DeleteAsync(token, context, id);
        }
    }
}
