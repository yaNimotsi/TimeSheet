using System.Collections.Generic;
using System.Threading.Tasks;

using TimeSheet.DB;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.BusinessLogic
{
    public class EmployeeLogic
    {
        public async Task<Employee> AddNewEmployeeAsync(MyDBContext context, IEmployeeRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await repository.AddAsync(context, entity))
            {
                return (Employee)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByIDAsync(MyDBContext context, IEmployeeRepository repository, int id)
        {
            var entityFromBase = await repository.GetAsync(context, id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByNameAsync(MyDBContext context, IEmployeeRepository repository, string nameToSearch)
        {
            return await repository.GetAsync(context, nameToSearch);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByRangeAsync(MyDBContext context, IEmployeeRepository repository, int skip, int take)
        {
            var result = await repository.GetAsync(context, skip, take);

            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(MyDBContext context, IEmployeeRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await repository.UpdateAsync(context, entity);

            return updateUser;
        }

        public async Task<bool> DeleteEmployeeAsync(MyDBContext context, IEmployeeRepository repository, int id)
        {
            return await repository.DeleteAsync(context, id);
        }
    }
}
