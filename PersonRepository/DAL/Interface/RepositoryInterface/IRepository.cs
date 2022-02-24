using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface.ModelInterface;

namespace TimeSheet.DB.DAL.Interface.RepositoryInterface
{
    public interface IRepository
    {
        public Task<bool> AddAsync(CancellationTokenSource token, IBaseEntity<int> entity);
        public Task<bool> DeleteAsync(CancellationTokenSource token, int entityId);
    }
}
