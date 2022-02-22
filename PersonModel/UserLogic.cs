﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserRepository _repository;

        public UserLogic(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<User> AddNewUserAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            if (await _repository.AddAsync(token,  entity))
            {
                return (User)entity;
            }

            return null;
        }

        public async Task<IReadOnlyList<User>> GetUserByIdAsync(CancellationTokenSource token, int id)
        {
            var entityFromBase = await _repository.GetAsync(token,  id);

            return entityFromBase;
        }

        public async Task<IReadOnlyList<User>> GetUserByNameAsync(CancellationTokenSource token, string nameToSearch)
        {
            return await _repository.GetAsync(token,  nameToSearch);
        }

        public async Task<IReadOnlyList<User>> GetUserByRangeAsync(CancellationTokenSource token, int skip, int take)
        {
            var result = await _repository.GetAsync(token,  skip, take);

            return result;
        }

        public async Task<User> UpdateUserAsync(CancellationTokenSource token, BaseEntity<int> entity)
        {
            if (entity == null) return null;

            var updateUser = await _repository.UpdateAsync(token,  entity);

            return updateUser;
        }

        public async Task<bool> DeleteUserAsync(CancellationTokenSource token, int id)
        {
            return await _repository.DeleteAsync(token,  id);
        }
    }
}