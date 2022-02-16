﻿using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.DB.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, int userId)
        {
            var userByIdList = await dbContext.Employees.Where(x => x.Id == userId).ToListAsync();
            return userByIdList;
        }

        public async Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, string nameToSearch)
        {
            var userByNameList = await dbContext.Employees.Where(x => x.FirstName == nameToSearch).ToListAsync();
            return null;
        }

        public async Task<IReadOnlyList<Employee>> GetAsync(MyDBContext dbContext, int skip, int take)
        {
            if (skip >= dbContext.Employees.Count())
            {
                return null;
            }

            var maxValue = dbContext.Employees.Count() > take + skip
                ? take + skip : dbContext.Employees.Count();

            return await dbContext.Employees.Where(x => x.Id >= skip && x.Id <= maxValue).ToListAsync();
        }

        public async Task<bool> AddAsync(MyDBContext context, BaseEntity<int> entity)
        {
            var newUser = (Employee)entity;

            if (newUser == null) return false;

            await context.Employees.AddAsync(newUser);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<Employee> UpdateAsync(MyDBContext dbContext, BaseEntity<int> entity)
        {
            var updatedEmployee = (Employee)entity;
            if (updatedEmployee == null) return null;

            if (dbContext.Employees.Any() == false) return null;
            
            var dbEntity = await dbContext.Employees.FindAsync(entity.Id);

            dbEntity.FirstName = updatedEmployee.FirstName;
            dbEntity.LastName = updatedEmployee.LastName;
            dbEntity.MiddleName = updatedEmployee.MiddleName;
            dbEntity.Comment = updatedEmployee.Comment;
            dbEntity.IsDeleted = updatedEmployee.IsDeleted;

            await dbContext.SaveChangesAsync();

            return updatedEmployee;
        }

        public async Task<bool> DeleteAsync(MyDBContext dbContext, int id)
        {
            if (dbContext.Employees.Any() == false) return false;

            var userToDelete = dbContext.Employees.First(x => x.Id == id);

            userToDelete.IsDeleted = true;

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
