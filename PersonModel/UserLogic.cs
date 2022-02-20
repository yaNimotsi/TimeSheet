using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.DB;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.BusinessLogic
{
    public class UserLogic
    {
        public async Task<User> AddNewUserAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await repository.AddAsync(token, context, entity))
            {
                return (User)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<User>> GetUserByIDAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, int id)
        {
            var entityFromBase = await repository.GetAsync(token, context, id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<User>> GetUserByNameAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, string nameToSearch)
        {
            return await repository.GetAsync(token, context, nameToSearch);
        }

        public async Task<IReadOnlyList<User>> GetUserByRangeAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, int skip, int take)
        {
            var result = await repository.GetAsync(token, context, skip, take);

            return result;
        }

        public async Task<User> UpdateUserAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await repository.UpdateAsync(token, context, entity);

            return updateUser;
        }

        public async Task<bool> DeleteUserAsync(CancellationTokenSource token, MyDBContext context, IUserRepository repository, int id)
        {
            return await repository.DeleteAsync(token, context, id);
        }
    }
}
