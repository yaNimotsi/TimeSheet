using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.DB.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _dbContext;

        public EmployeeRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, int employeeId)
        {
            var employeeByIdList = await _dbContext.Employees.Where(x => x.Id == employeeId).ToListAsync();
            return employeeByIdList;
        }

        public async Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, string nameToSearch)
        {
            var employeeByNameList = await _dbContext.Employees.Where(x => x.FirstName.ToLower() == nameToSearch.ToLower()).ToListAsync();
            return employeeByNameList;
        }

        public async Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, int skip, int take)
        {
            if (skip >= _dbContext.Employees.Count())
            {
                return null;
            }

            var maxValue = _dbContext.Employees.Count() > take + skip
                ? take + skip : _dbContext.Employees.Count();

            return await _dbContext.Employees.Where(x => x.Id >= skip && x.Id <= maxValue).ToListAsync();
        }

        public async Task<bool> AddAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            var newemployee = (Employee)entity;

            if (newemployee == null) return false;

            await _dbContext.Employees.AddAsync(newemployee);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<Employee> UpdateAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            var updatedEmployee = (Employee)entity;
            if (updatedEmployee == null) return null;

            if (_dbContext.Employees.Any() == false) return null;
            
            var dbEntity = await _dbContext.Employees.FindAsync(entity.Id);

            dbEntity.FirstName = updatedEmployee.FirstName;
            dbEntity.LastName = updatedEmployee.LastName;
            dbEntity.MiddleName = updatedEmployee.MiddleName;
            dbEntity.Comment = updatedEmployee.Comment;
            dbEntity.IsDeleted = updatedEmployee.IsDeleted;

            await _dbContext.SaveChangesAsync();

            return updatedEmployee;
        }

        public async Task<bool> DeleteAsync(CancellationTokenSource token, int id)
        {
            if (_dbContext.Employees.Any() == false) return false;

            var employeeToDelete = _dbContext.Employees.First(x => x.Id == id);

            employeeToDelete.IsDeleted = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
