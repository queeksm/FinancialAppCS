using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Controller
{
    public class Accounts
    {
        public Guid Id { get; set; }        
        public int AccountType { get; set; }
        public int AccountNumber { get; set; } 
        public string AccountState { get; set; }
        public decimal AccountBalance { get; set; }
        public bool GMFExemption { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public List<Transactions> Transactions { get; set; }
        public Clients Client { get; set; }


    }
}
