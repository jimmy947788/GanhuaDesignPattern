using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ganhua.UnitOfWork.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        //預備要更新的entity
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        //預備要新增的entity
        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, unitofWorkRepository);
            };
        }

        //預備要刪除的entity
        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistCreationOf(entity);
                }

                foreach (IAggregateRoot entity in this.changedEntities.Keys)
                {
                    this.changedEntities[entity].PersistUpdateOf(entity);
                }

                foreach (IAggregateRoot entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletionOf(entity);
                }

                scope.Complete();
            }
        }

    }
}
