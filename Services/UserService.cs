using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Pokupatel>> GetAll()
        {
            return _repositoryWrapper.Pokupatel.FindAll().ToListAsync();
        }
        public Task<Pokupatel> GetById(int id)
        {
            var user = _repositoryWrapper.Pokupatel
            .FindByCondition(x => x.IdPokupatel == id).First();
            return Task.FromResult(user);
        }
        public Task Create(Pokupatel model)
        {
            _repositoryWrapper.Pokupatel.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Pokupatel model)
        {
            _repositoryWrapper.Pokupatel.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Pokupatel
            .FindByCondition(x => x.IdPokupatel == id).First();
            _repositoryWrapper.Pokupatel.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
