using System.Collections.Generic;
using System.Linq;
using BLEmployeeModel = TimeSheet.BusinessLogic.DAL.Entity.Employee;
using APIEmployeeModel = TimeSheet.API.DAL.Entity.Employee;

namespace TimeSheet.API.Mapping
{
    public static class EmployeeMapping
    {
        public static APIEmployeeModel MappingToAPIEmployeeModel(BLEmployeeModel entity)
        {
            if (entity == null) return null;
            
            return new APIEmployeeModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IReadOnlyList<APIEmployeeModel> MappingToAPIEmployeeModel(List<BLEmployeeModel> entityList)
        {
            if (entityList?.Count == null) return null;

            return (from entity in entityList
                where entity != null
                select new APIEmployeeModel
                {
                    Id = entity.Id,
                    Comment = entity.Comment,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MiddleName = entity.MiddleName,
                    IsDeleted = entity.IsDeleted
                }).ToList();
        }

        public static BLEmployeeModel MappingFromBLEmployeeModel(APIEmployeeModel entity)
        {
            if (entity == null) return null;

            return new BLEmployeeModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IEnumerable<BLEmployeeModel> MappingFromBLEmployeeModel(List<APIEmployeeModel> entityList)
        {
            if (entityList?.Count == null) return null;

            return (from entity in entityList
                where entity != null
                select new BLEmployeeModel
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