using Ganhua.Library.Infrastructure;
using Ganhua.Library.Infrastructure.UnitofWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                { transaction.Commit(); }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
