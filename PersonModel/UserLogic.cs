using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.BusinessLogic.DAL.Entity;
using TimeSheet.BusinessLogic.Mapping;
using TimeSheet.DB.DAL.Interface;
using TimeSheet.DB.DAL.Interface.ModelInterface;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;

namespace TimeSheet.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserRepository _repository;

        public UserLogic(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<User> AddNewUserAsync(CancellationTokenSource token, User entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(token, UserMapping.MappingFromBLUserModel(entity)))
            {
                return (User)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<User>> GetUserByIdAsync(CancellationTokenSource token, int id)
        {
            var entityFromBase = await _repository.GetAsync(token, id);

            return UserMapping.MappingToBLUserModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<User>> GetUserByNameAsync(CancellationTokenSource token, string nameToSearch)
        {
            var entityFromBase = await _repository.GetAsync(token, nameToSearch);
            return UserMapping.MappingToBLUserModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<User>> GetUserByRangeAsync(CancellationTokenSource token, int skip, int take)
        {
            var result = await _repository.GetAsync(token, skip, take);

            return UserMapping.MappingToBLUserModel(result.ToList());
        }

        public async Task<User> UpdateUserAsync(CancellationTokenSource token, User entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(token, UserMapping.MappingFromBLUserModel(entity));

            return UserMapping.MappingToBLUserModel(updateUser);
        }

        public async Task<bool> DeleteUserAsync(CancellationTokenSource token, int id)
        {
            return await _repository.DeleteAsync(token, id);
        }
    }
}
