using Ganhua.UnitOfWork.Infrastructure;
using Ganhua.UnitOfWork.Model;
using Ganhua.UnitOfWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.UnitOfWork.Test
{
    [TestClass]
    public class AccounServiceTests
    {
        [TestMethod]
        public void AccounService_Transfer()
        {
            Account accountA = new Account();
            Account accountB = new Account();

            IUnitOfWork unitOfWork = new Ganhua.UnitOfWork.Infrastructure.UnitOfWork();
            AccountRepository accountRepository = new AccountRepository(unitOfWork);

            AccountService accountService = new AccountService(accountRepository, unitOfWork);
            accountA.Balance = 1000;
            accountB.Balance = 500;
            accountService.Transfer(accountA, accountB, 100);
        }
    }
}
