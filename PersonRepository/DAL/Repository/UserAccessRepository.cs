using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface.ModelInterface;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;

namespace TimeSheet.DB.DAL.Repository
{
    public class UserAccessRepository : IUserAccessRepository
    {
        private readonly MyDbContext _dbContext;

        public UserAccessRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IUserAccessModel> FindUser(CancellationToken token, IUserAccessModel entity)
        {
            if (entity == null)
            {
                return null;
            }

            var userAccessModel = await _dbContext.Users
                .Where(x => x.UserName == entity.UserLogin && x.UserPassword == entity.UserPass).FirstAsync(token);

            if (userAccessModel == null)
            {
                return null;
            }

            var result = new UserAccessData
            {
                Id = userAccessModel.Id,
                UserLogin = userAccessModel.UserName,
                UserPass = userAccessModel.UserPassword,
                IsDeleted = userAccessModel.IsDeleted
            };

            return result;
        }
    }
}
