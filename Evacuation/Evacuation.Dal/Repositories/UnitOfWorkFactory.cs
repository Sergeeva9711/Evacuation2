using Evacuation.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Dal.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactoryPerCall, IUnitOfWorkFactoryPerRequest
    {
        public UnitOfWorkFactory()
        {
            ContextUnitOfWork = new ContextUnitOfWork();            
        }

        public ContextUnitOfWork ContextUnitOfWork
        {
            get; private set;
        }

        public void Dispose()
        {
            ContextUnitOfWork.Dispose();
        }
    }
}
