using Ganhua.DesignPattern.AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.AppService.Messages
{
    public class FindBankAccountResponse : ResponseBase
    {
        public BankAccountView BankAccount { get; set; }
    }
}
