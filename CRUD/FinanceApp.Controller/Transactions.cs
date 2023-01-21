using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Controller
{
    public class Transactions
    {
        public Guid Id { get; set; }        
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public Accounts ReceiverAccount { get; set; }
        public Accounts SendingAccount { get; set; }

    }
}
