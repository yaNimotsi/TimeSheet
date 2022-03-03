using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface;
using TimeSheet.DB.DAL.Interface.ModelInterface;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;

namespace TimeSheet.DB.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, int userId)
        {
            var userByIdList = await _dbContext.Users.Where(x => x.Id == userId).ToListAsync();
            return userByIdList;
        }

        public async Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, string nameToSearch)
        {
            var userByNameList = await _dbContext.Users.Where(x => x.FirstName == nameToSearch).ToListAsync();
            return userByNameList;
        }

        public async Task<IReadOnlyList<User>> GetAsync(CancellationTokenSource token, int skip, int take)
        {
            if (skip >= _dbContext.Users.Count())
            {
                return null;
            }

            var maxValue = _dbContext.Users.Count() > take + skip
                ? take + skip : _dbContext.Users.Count();

            return await _dbContext.Users.Where(x => x.Id >= skip && x.Id < maxValue).ToListAsync();
        }

        public async Task<bool> AddAsync(CancellationTokenSource token, IBaseEntity<int> entity)
        {

            var newUser = (User)entity;

            if (newUser == null) return false;

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> UpdateAsync(CancellationTokenSource token, IUserModel entity)
        {
            var updatedUser = (User)entity;
            if (updatedUser == null) return null;

            if (_dbContext.Users.Any() == false) return null;

            var dbEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == updatedUser.Id);

            dbEntity.FirstName = updatedUser.FirstName;
            dbEntity.LastName = updatedUser.LastName;
            dbEntity.MiddleName = updatedUser.MiddleName;
            dbEntity.Comment = updatedUser.Comment;
            dbEntity.IsDeleted = updatedUser.IsDeleted;

            await _dbContext.SaveChangesAsync();

            return updatedUser;
        }

        public async Task<UserAccessData> FindUserAsync(CancellationToken token, IUserAccessModel entity)
        {
            var user = await _dbContext.Users.
                Where(x => x.UserName == entity.UserLogin && x.UserPassword == entity.UserPass).FirstAsync(token);

            return new UserAccessData
            {
                Id = user.Id,
                UserLogin = user.UserName,
                UserPass = user.UserPassword,
                IsDeleted = user.IsDeleted
            };
        }

        public async Task<bool> DeleteAsync(CancellationTokenSource token, int id)
        {
            if (_dbContext.Users.Any() == false) return false;

            var userToDelete = _dbContext.Users.First(x => x.Id == id);

            userToDelete.IsDeleted = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
