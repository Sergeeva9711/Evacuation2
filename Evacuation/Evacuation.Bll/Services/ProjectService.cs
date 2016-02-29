using Evacuation.Bll.Infrastructure;
using Evacuation.Bll.Interfaces;
using Evacuation.Dal.Entities;
using Evacuation.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Bll.Services
{
    public class ProjectService : IService<Project>
    {
        IUnitOfWorkFactoryPerRequest database { get; set; }

        public ProjectService(IUnitOfWorkFactoryPerRequest uow)
        {
            database = uow;
        }

        public void Create(Project item)
        {
            database.ContextUnitOfWork.Projects.Create(item);
            database.ContextUnitOfWork.Save();
        }

        public void Delete(Project item)
        {
            database.ContextUnitOfWork.Projects.Delete(item);
            database.ContextUnitOfWork.Save();
        }

        public void Dispose()
        {
            database.Dispose();
        }

        public void Edit(Project item)
        {
            database.ContextUnitOfWork.Projects.Update(item);
            database.ContextUnitOfWork.Save();
        }

        public Project Get(int id)
        {
            if (id == 0)
                throw new ValidationException("Не установлено project id", "");
            if (database.ContextUnitOfWork.Projects.Get(id) == null)
                throw new ValidationException("Project не найден", "");
            else return database.ContextUnitOfWork.Projects.Get(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return database.ContextUnitOfWork.Projects.GetAll();
        }
    }
}
