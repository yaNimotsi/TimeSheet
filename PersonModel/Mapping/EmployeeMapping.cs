using System.Collections.Generic;
using System.Linq;
using TimeSheet.BusinessLogic.DAL.Entity;

namespace TimeSheet.BusinessLogic.Mapping
{
    public static class EmployeeMapping
    {
        public static Employee MappingToBLEmployeeModel(DB.DAL.Entity.Employee entity)
        {
            if (entity == null) return null;
            
            return new Employee
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IReadOnlyList<Employee> MappingToBLEmployeeModel(List<DB.DAL.Entity.Employee> entityList)
        {
            if (entityList?.Count() == null) return null;

            return (from entity in entityList
                where entity != null
                select new Employee
                {
                    Id = entity.Id,
                    Comment = entity.Comment,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MiddleName = entity.MiddleName,
                    IsDeleted = entity.IsDeleted
                }).ToList();
        }

        public static DB.DAL.Entity.Employee MappingFromBLEmployeeModel(Employee entity)
        {
            if (entity == null) return null;

            return new DB.DAL.Entity.Employee
            {
                Id = entity.Id,
                Comment = entity.Comment,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static IEnumerable<DB.DAL.Entity.Employee> MappingFromBLEmployeeModel(List<Employee> entityList)
        {
            if (entityList?.Count() == null) return null;

            return (from entity in entityList
                where entity != null
                select new DB.DAL.Entity.Employee
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