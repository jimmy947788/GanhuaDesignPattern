using System;
using Ganhua.UnitOfWork.Infrastructure;
using Ganhua.UnitOfWork.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ganhua.UnitOfWork.Test
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void UnitOfWorkRepository_Is_Used_For_The_Real_Persistence_When_Commit_Is_Called_On_The_Unit_Of_Work()
        {
            Account accountToBeAmended = new Account();
            Account accountToBeRemoved = new Account();
            Account accountToBeAdded = new Account();

            Infrastructure.UnitOfWork uow = new Infrastructure.UnitOfWork();

            var uowRepositoryMockery = new Mock<IUnitOfWorkRepository>();

            IUnitOfWorkRepository uowRepository = uowRepositoryMockery.Object;

            uowRepositoryMockery.Setup(uowr => uowr.PersistCreationOf(accountToBeAdded));
            uowRepositoryMockery.Setup(uowr => uowr.PersistDeletionOf(accountToBeRemoved));
            uowRepositoryMockery.Setup(uowr => uowr.PersistUpdateOf(accountToBeAmended));

            uow.RegisterNew(accountToBeAdded, uowRepository);
            uow.RegisterAmended(accountToBeAmended, uowRepository);
            uow.RegisterRemoved(accountToBeRemoved, uowRepository);

            uow.Commit();

            uowRepositoryMockery.VerifyAll();

        }
    }
}
