using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.BusinessLogic.DAL.Interface;
using TimeSheet.BusinessLogic.Mapping;
using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;
using Employee = TimeSheet.BusinessLogic.DAL.Entity.Employee;

namespace TimeSheet.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeLogic(IEmployeeRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<Employee> AddNewEmployeeAsync(CancellationTokenSource token,  Employee entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(token, EmployeeMapping.MappingFromBLEmployeeModel(entity)))
            {
                return (Employee)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByIdAsync(CancellationTokenSource token,  int id)
        {
            var entityFromBase = await _repository.GetAsync(token, id);

            return EmployeeMapping.MappingToBLEmployeeModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByNameAsync(CancellationTokenSource token,  string nameToSearch)
        {
            var entityFromBase = await _repository.GetAsync(token, nameToSearch);
            return EmployeeMapping.MappingToBLEmployeeModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeeByRangeAsync(CancellationTokenSource token,  int skip, int take)
        {
            var result = await _repository.GetAsync(token,  skip, take);

            return EmployeeMapping.MappingToBLEmployeeModel(result.ToList());
        }

        public async Task<Employee> UpdateEmployeeAsync(CancellationTokenSource token, Employee entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(token, EmployeeMapping.MappingFromBLEmployeeModel(entity));

            return EmployeeMapping.MappingToBLEmployeeModel(updateUser);
        }

        public async Task<bool> DeleteEmployeeAsync(CancellationTokenSource token,  int id)
        {
            return await _repository.DeleteAsync(token,  id);
        }
    }
}
