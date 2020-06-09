using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository1;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository1 = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository1.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository1.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository1.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository1.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository1.UpdateAsync(user);
        }
    }
}
