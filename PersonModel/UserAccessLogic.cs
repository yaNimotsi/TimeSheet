using System.Threading;
using System.Threading.Tasks;
using TimeSheet.BusinessLogic.DAL.Interface;
using TimeSheet.BusinessLogic.Mapping;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;

namespace TimeSheet.BusinessLogic
{
    public class UserAccessLogic
    {
        private readonly IUserAccessRepository _repository;

        public UserAccessLogic(IUserAccessRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> FindUserAccessAsync(CancellationToken token, IUserAccessModel entity)
        {
            if (entity == null)
            {
                return -1;
            }

            var dbUserAccessModel = UserAccessMapping.MappingFromBLUserAccessModel(entity);

            var userAccessFromDB = await _repository.FindUser(token, dbUserAccessModel);

            if (userAccessFromDB == null)
            {
                return -1;
            }

            return entity.UserPass == userAccessFromDB.UserPass ? 
                userAccessFromDB.Id : -1;
        }
    }
}