using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.BusinessLogic.DAL.Entity;
using TimeSheet.BusinessLogic.DAL.Interface;
using TimeSheet.BusinessLogic.Mapping;
using TimeSheet.DB.DAL.Entity;
using TimeSheet.DB.DAL.Interface;
using TimeSheet.DB.DAL.Interface.ModelInterface;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;
using User = TimeSheet.BusinessLogic.DAL.Entity.User;
using UserAccessData = TimeSheet.BusinessLogic.DAL.Entity.UserAccessData;

namespace TimeSheet.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserRepository _repository;

        public UserLogic(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<User> AddNewUserAsync(CancellationTokenSource cancelToken, User entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(cancelToken, UserMapping.MappingFromBLUserModel(entity)))
            {
                return (User)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<User>> GetUserByIdAsync(CancellationTokenSource cancelToken, int id)
        {
            var entityFromBase = await _repository.GetAsync(cancelToken, id);

            return UserMapping.MappingToBLUserModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<User>> GetUserByNameAsync(CancellationTokenSource cancelToken, string nameToSearch)
        {
            var entityFromBase = await _repository.GetAsync(cancelToken, nameToSearch);
            return UserMapping.MappingToBLUserModel(entityFromBase.ToList());
        }

        public async Task<IReadOnlyList<User>> GetUserByRangeAsync(CancellationTokenSource cancelToken, int skip, int take)
        {
            var result = await _repository.GetAsync(cancelToken, skip, take);

            return UserMapping.MappingToBLUserModel(result.ToList());
        }

        public async Task<User> UpdateUserAsync(CancellationTokenSource cancelToken, User entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(cancelToken, UserMapping.MappingFromBLUserModel(entity));

            return UserMapping.MappingToBLUserModel(updateUser);
        }

        public async Task<bool> DeleteUserAsync(CancellationTokenSource cancelToken, int id)
        {
            return await _repository.DeleteAsync(cancelToken, id);
        }

        public async Task<TokenModel> AuthenticateAsync(CancellationTokenSource cancelToken, string userLogin, string userPassword)
        {
            var blModel = new UserAccessData
            {
                UserLogin = userLogin,
                UserPass = userPassword
            };

            var dbAccessData = UserMapping.MappingToDBUserAccessData(blModel);

            var userData = await _repository.FindUserAsync(cancelToken.Token, dbAccessData);

            if (userData == null) return null;
            
            var tokenModel = TokenGeneration.Authenticate(userData);

            return tokenModel;
        }
    }
}
