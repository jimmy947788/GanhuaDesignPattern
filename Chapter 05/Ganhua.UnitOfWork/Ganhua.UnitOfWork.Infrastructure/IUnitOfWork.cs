using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.UnitOfWork.Infrastructure
{
    public interface IUnitOfWork
    {
        //預備要更新的entity
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        //預備要新增的entity
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        //預備要刪除的entity
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        //認可交易
        void Commit();
    }
}
