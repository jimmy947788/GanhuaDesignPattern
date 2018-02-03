using Ganhua.Library.Infrastructure;
using Ganhua.Library.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistUpdateOf(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistCreationOf(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistDeletionOf(entity);
        }
    }
}
