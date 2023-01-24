using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Controller
{
    public class Clients
    {
        public Guid CliId { get; set; }
        public string? IdType { get; set; }
        public int? NumberId { get; set; }
        public string? NameClient { get; set; }
        public string? SurnameClient { get; set; }
        public string? ClientEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public List<Accounts> Accounts { get; set; } = new List<Accounts>();
         
    
    }
}
