using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.AppService.ViewModels
{
    public class BankAccountView
    {
        public Guid AccountNo { get; set; }
        public string Balance { get; set; }
        public string CustomerRef { get; set; }
        public IList<TransactionView> Transactions { get; set; }
    }
}
