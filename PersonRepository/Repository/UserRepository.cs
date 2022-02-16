using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.DB.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<IReadOnlyList<User>> GetAsync(MyDBContext dbContext, int userId)
        {
            var userByIdList = await dbContext.Users.Where(x => x.Id == userId).ToListAsync();
            return userByIdList;
        }

        public async Task<IReadOnlyList<User>> GetAsync(MyDBContext dbContext, string nameToSearch)
        {
            var userByNameList = await dbContext.Users.Where(x => x.FirstName == nameToSearch).ToListAsync();
            return null;
        }

        public async Task<IReadOnlyList<User>> GetAsync(MyDBContext dbContext, int skip, int take)
        {
            if (skip >= dbContext.Users.Count())
            {
                return null;
            }

            var maxValue = dbContext.Users.Count() > take + skip
                ? take + skip : dbContext.Users.Count();
            
            return await dbContext.Users.Where(x => x.Id >= skip && x.Id < maxValue).ToListAsync();
        }

        public async Task<bool> AddAsync(MyDBContext context, BaseEntity<int> entity)
        {

            var newUser = (User)entity;

            if (newUser == null) return false;

            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            return true;
        }
        
        public async Task<User> UpdateAsync(MyDBContext dbContext, BaseEntity<int> entity)
        {
            var updatedUser = (User)entity;
            if (updatedUser == null) return null;

            if (dbContext.Users.Any() == false) return null;

            var dbEntity = await  dbContext.Users.FirstOrDefaultAsync(x => x.Id == updatedUser.Id);

            dbEntity.FirstName = updatedUser.FirstName;
            dbEntity.LastName = updatedUser.LastName;
            dbEntity.MiddleName = updatedUser.MiddleName;
            dbEntity.Comment = updatedUser.Comment;
            dbEntity.IsDeleted = updatedUser.IsDeleted;

            await dbContext.SaveChangesAsync();

            return updatedUser;
        }

        public async Task<bool> DeleteAsync(MyDBContext dbContext, int id)
        {
            if (dbContext.Users.Any() == false) return false;

            var userToDelete = dbContext.Users.First(x => x.Id == id);

            userToDelete.IsDeleted = true;

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
