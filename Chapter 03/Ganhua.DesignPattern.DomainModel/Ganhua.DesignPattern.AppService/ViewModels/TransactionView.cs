using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.AppService.ViewModels
{
    public class TransactionView
    {
        public string Deposit { get; set; }
        public string Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }
}
