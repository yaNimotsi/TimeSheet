using TimeSheet.API.DAL.Entity;
using TimeSheet.API.DAL.Interface;

using IBLUserAccess = TimeSheet.BusinessLogic.DAL.Interface.IUserAccessModel;
using BLUserAccess = TimeSheet.BusinessLogic.DAL.Entity.UserAccessModel;
namespace TimeSheet.API.Mapping
{
    public class UserAccessMapping
    {
        public static IBLUserAccess MappingFromAPIUserAccessModel(IUserAccessModel entity)
        {
            if (entity == null) return null;

            return new BLUserAccess
            {
                Id = entity.Id,
                UserLogin = entity.UserLogin,
                UserPass = entity.UserPass,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}