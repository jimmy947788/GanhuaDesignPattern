using System;
using Ganhua.UnitOfWork.Infrastructure;
using Ganhua.UnitOfWork.Model;
using Ganhua.UnitOfWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ganhua.UnitOfWork.Test
{
    [TestClass]
    public class AccountRepositoryTests
    {
        [TestMethod]
        public void AccountRepository_Delegates_Changes_To_The_Unit_Of_Work_Instance()
        {
            Account accountToBeAmended = new Account();
            Account accountToBeRemoved = new Account();
            Account accountToBeAdded = new Account();

            var unitOfWorkMockery = new Mock<IUnitOfWork>();

            AccountRepository accountRepository = new AccountRepository(unitOfWorkMockery.Object);

            unitOfWorkMockery.Setup(uow => uow.RegisterAmended(accountToBeAmended, accountRepository));
            unitOfWorkMockery.Setup(uow => uow.RegisterNew(accountToBeAdded, accountRepository));
            unitOfWorkMockery.Setup(uow => uow.RegisterRemoved(accountToBeRemoved, accountRepository));

            accountRepository.Add(accountToBeAdded);
            accountRepository.Save(accountToBeAmended);
            accountRepository.Remove(accountToBeRemoved);

            unitOfWorkMockery.VerifyAll();

        }
    }
}
