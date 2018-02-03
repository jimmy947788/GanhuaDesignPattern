using Ganhua.UnitOfWork.Infrastructure;
using Ganhua.UnitOfWork.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.UnitOfWork.Repository
{
    public class AccountRepository : IAccountRepository, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(Account account)
        {
            _unitOfWork.RegisterAmended(account, this);
        }

        public void Add(Account account)
        {
            _unitOfWork.RegisterNew(account, this);
        }

        public void Remove(Account account)
        {
            _unitOfWork.RegisterRemoved(account, this);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // ADO.net code to update the entity...
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            // ADO.net code to Add the entity...
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            // ADO.net code to delete the entity...
        }
    }
}
