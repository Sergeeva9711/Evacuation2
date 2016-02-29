
using Evacuation.Dal.Interfaces;
using Evacuation.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Evacuation.Bll.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWorkFactoryPerCall>().To<UnitOfWorkFactory>();
            this.Bind<IUnitOfWorkFactoryPerRequest>().To<UnitOfWorkFactory>().InRequestScope();
        }
    }
}
