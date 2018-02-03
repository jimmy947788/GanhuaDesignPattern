using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Infrastructure.UnitofWork
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
