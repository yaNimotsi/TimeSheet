using TimeSheet.API.DAL.Interface;

using IBLUserAccess = TimeSheet.BusinessLogic.DAL.Interface.IUserAccessData;
using BLUserAccess = TimeSheet.BusinessLogic.DAL.Entity.UserAccessData;
namespace TimeSheet.API.Mapping
{
    public static class UserAccessMapping
    {
        public static IBLUserAccess MappingFromApiUserAccessModel(IUserAccessData entity)
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