using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.DB.Entity;

namespace TimeSheet.DB.Interface
{
    public interface IEmployeeRepository : IRepository
    {
        public Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, int employeeId);
        public Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, string nameToSearch);
        public Task<IReadOnlyList<Employee>> GetAsync(CancellationTokenSource token, int skip, int take);
        public Task<Employee> UpdateAsync(CancellationTokenSource token, BaseEntity<int> entity);
    }
}
