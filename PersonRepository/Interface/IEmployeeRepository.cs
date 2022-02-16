using System.Collections.Generic;
using System.Threading.Tasks;

using TimeSheet.DB.Entity;

namespace TimeSheet.DB.Interface
{
    public interface IEmployeeRepository : IRepository
    {
        public Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, int userId);
        public Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, string nameToSearch);
        public Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, int skip, int take);
        public Task<Employee> UpdateAsync(MyDBContext dbContext, BaseEntity<int> entity);
    }
}
