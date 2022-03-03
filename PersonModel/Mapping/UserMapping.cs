using System.Collections.Generic;
using System.Linq;
using TimeSheet.BusinessLogic.DAL.Interface;
using DBUserModelInterface = TimeSheet.DB.DAL.Interface.ModelInterface.IUserModel;
using DBUserModel = TimeSheet.DB.DAL.Entity.User;
using DbUserAccessModel = TimeSheet.DB.DAL.Entity.UserAccessData;
using User = TimeSheet.BusinessLogic.DAL.Entity.User;

namespace TimeSheet.BusinessLogic.Mapping
{
    public static class UserMapping
    {
        public static DbUserAccessModel MappingToDBUserAccessData(IUserAccessData entity)
        {
            if (entity == null) return null;

            return new DbUserAccessModel()
            {
                Id = entity.Id,
                UserLogin = entity.UserLogin,
                UserPass = entity.UserPass,
                IsDeleted = entity.IsDeleted
            };
        }

        public static User MappingToBLUserModel(DBUserModel entity)
        {
            if (entity == null) return null;
            
            return new User
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IReadOnlyList<User> MappingToBLUserModel(List<DBUserModel> entityList)
        {
            if (entityList?.Count() == null) return null;

            return (from entity in entityList
                where entity != null
                select new User
                {
                    Id = entity.Id,
                    Comment = entity.Comment,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MiddleName = entity.MiddleName,
                    IsDeleted = entity.IsDeleted
                }).ToList();
        }

        public static DBUserModelInterface MappingFromBLUserModel(User entity)
        {
            if (entity == null) return null;

            return new DBUserModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IEnumerable<DBUserModelInterface> MappingFromBLUserModel(List<User> entityList)
        {
            if (entityList?.Count() == null) return null;

            return (from entity in entityList
                where entity != null
                select new DBUserModel
                {
                    Id = entity.Id,
                    Comment = entity.Comment,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MiddleName = entity.MiddleName,
                    IsDeleted = entity.IsDeleted
                }).ToList();
        }
    }
}