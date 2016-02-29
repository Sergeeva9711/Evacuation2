using Evacuation.Bll.Interfaces;
using Evacuation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evacuation.Dal.Interfaces;
using Evacuation.Bll.Infrastructure;

namespace Evacuation.Bll.Services
{
    public class UserService : IService<User>
    {
        IUnitOfWorkFactoryPerRequest database { get; set; }

        public UserService(IUnitOfWorkFactoryPerRequest uow)
        {
            database = uow;
        }

        public void Create(User item)
        {
            database.ContextUnitOfWork.Users.Create(item);
            database.ContextUnitOfWork.Save();
        }

        public void Edit(User item)
        {
            database.ContextUnitOfWork.Users.Update(item);
            database.ContextUnitOfWork.Save();
        }

        public void Delete(User item)
        {
            database.ContextUnitOfWork.Users.Delete(item);
            database.ContextUnitOfWork.Save();
        }

        public User Get(int id)
        {
            if (id == 0)
                throw new ValidationException("Не установлено id user", "");
            if (database.ContextUnitOfWork.Users.Get(id) == null)
                throw new ValidationException("User не найден", "");
            else return database.ContextUnitOfWork.Users.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return database.ContextUnitOfWork.Users.GetAll();
        }

        public void Dispose()
        {
            database.Dispose();
        } 

    }
}
