using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface.ModelInterface;

namespace TimeSheet.DB.DAL.Interface.RepositoryInterface
{
    public interface IUserRepository : IRepository
    {
        public Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, int userId);
        public Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, string nameToSearch);
        public Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, int skip, int take);
        public Task<User> UpdateAsync(CancellationTokenSource token, IUserModel entity);
    }
}
