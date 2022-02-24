using TimeSheet.BusinessLogic.DAL.Entity;
using TimeSheet.DB.DAL.Interface.ModelInterface;

using BLUserAccessModel = TimeSheet.BusinessLogic.DAL.Entity.UserAccessModel;
using DBUserAccessModel = TimeSheet.DB.DAL.Entity.UserAccessData;

namespace TimeSheet.BusinessLogic.Mapping
{
    public static class UserAccessMapping
    {

        public static BLUserAccessModel MappingToBLUserAccessModel(IUserAccessModel entity)
        {
            if (entity == null) return null;

            return new BLUserAccessModel
            {
                Id = entity.Id,
                UserLogin = entity.UserLogin,
                UserPass = entity.UserPass,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IUserAccessModel MappingFromBLUserAccessModel(DAL.Interface.IUserAccessModel entity)
        {
            if (entity == null) return null;

            return new DBUserAccessModel
            {
                Id = entity.Id,
                UserLogin = entity.UserLogin,
                UserPass = ProtectPassword.HashPassword(entity.UserPass),
                IsDeleted = entity.IsDeleted
            };
        }

        
    }
}