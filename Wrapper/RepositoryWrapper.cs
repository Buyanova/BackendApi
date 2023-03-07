using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ИнтернетмагазинContext _repoContext;

        private IUserRepository _pokupatel;
        public IUserRepository Pokupatel
        {
            get
            {
                if (_pokupatel == null)
                {
                    _pokupatel = new UserRepository(_repoContext);
                }
                return _pokupatel;
            }
        }
        public RepositoryWrapper(ИнтернетмагазинContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
