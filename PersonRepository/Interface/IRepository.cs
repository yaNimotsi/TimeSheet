using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.Entity;

namespace TimeSheet.DB.Interface
{
    public interface IRepository
    {
        public Task<bool> AddAsync(CancellationTokenSource token, BaseEntity<int> entity);
        public Task<bool> DeleteAsync(CancellationTokenSource token, int entityId);
    }
}
