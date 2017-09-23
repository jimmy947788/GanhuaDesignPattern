using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Model
{
    public class BankAccountHasEnoughFundsToWithdrawSpecification
    {
        private decimal _amountToWithdraw;

        public BankAccountHasEnoughFundsToWithdrawSpecification(decimal amountToWithdraw)
        {
            _amountToWithdraw = amountToWithdraw;
        }

        public bool IsSatisfiedBy(BankAccount bankAccount)
        {
            return bankAccount.Balance >= _amountToWithdraw;
        }
    }
}
