using Evacuation.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Dal.Interfaces
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        ContextUnitOfWork ContextUnitOfWork { get; }
    }
}
