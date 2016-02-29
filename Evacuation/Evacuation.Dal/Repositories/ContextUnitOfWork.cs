using Evacuation.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evacuation.Dal.Entities;
using Evacuation.Dal.Context;

namespace Evacuation.Dal.Repositories
{
    public class ContextUnitOfWork 
    {
        private UserContext db;
       // private ProjectContext pc;
        private UserRepository userRepository;
        private ProjectRepository projectRepository;

        public ContextUnitOfWork()
        {
            db = new UserContext();
           // pc = new ProjectContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
