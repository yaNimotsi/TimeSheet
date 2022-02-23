using System.Collections.Generic;
using System.Linq;
using TimeSheet.BusinessLogic.DAL.Entity;
using BLUserModel = TimeSheet.BusinessLogic.DAL.Entity.User;
using APIUserModel = TimeSheet.API.DAL.Entity.User;

namespace TimeSheet.API.Mapping
{
    public static class UserMapping
    {
        public static APIUserModel MappingToAPIUserModel(BLUserModel entity)
        {
            if (entity == null) return null;
            
            return new APIUserModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IReadOnlyList<APIUserModel> MappingToAPIUserModel(List<BLUserModel> entityList)
        {
            if (entityList?.Count == null) return null;

            return (from entity in entityList
                where entity != null
                select new APIUserModel
                {
                    Id = entity.Id,
                    Comment = entity.Comment,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MiddleName = entity.MiddleName,
                    IsDeleted = entity.IsDeleted
                }).ToList();
        }

        public static BLUserModel MappingFromAPIUserModel(APIUserModel entity)
        {
            if (entity == null) return null;

            return new BLUserModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IEnumerable<BLUserModel> MappingFromAPIUserModel(List<APIUserModel> entityList)
        {
            if (entityList?.Count == null) return null;

            return (from entity in entityList
                where entity != null
                select new BLUserModel
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