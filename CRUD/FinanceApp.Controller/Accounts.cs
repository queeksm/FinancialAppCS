using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Controller
{   
    
    public class Accounts
    {
        public Guid AccId { get; set; }        
        public int AccountType { get; set; }
        public string? AccountNumber { get; set; } 
        public bool? AccountState { get; set; } = true;
        public bool? AccountCancelled { get; set; } = false;
        public decimal? AccountBalance { get; set; } = 0;
        public bool? GMFExemption { get; set; } = false;
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? ModificationDate { get; set; } = DateTime.Now;
        public List<Transactions>? Transactions { get; set; } = new List<Transactions>();
        public Clients? Client { get; set; }

    }
}
