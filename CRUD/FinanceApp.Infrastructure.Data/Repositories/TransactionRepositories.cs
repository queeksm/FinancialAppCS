using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller;
using FinanceApp.Controller.Interfaces.Repositories;
using FinanceApp.Infrastructure.Data.Context;

namespace FinanceApp.Infrastructure.Data.Repositories
{
    public class TransactionRepositories : IRepositoryTransactions<Transactions, Guid>
    {
        private ClientContext db;

        public TransactionRepositories(ClientContext _db)
        {
            db = _db;
        }
        public Transactions Add(Transactions entity)
        {
            db.Transactions.Add(entity);            
            return entity;
        }

        public void Deposit(Transactions entity, Guid account, decimal amount)
        {
            /*if (amount >= 0)
            {
                var accountdb = db.Accounts.Where(c => c.AccId == account).First();
                
                
            }
            else
                throw new Exception("You can't deposit a negative ammount please use a withdrawal operation");
        */
            }

        public List<Transactions> GetAll()
        {
            return db.Transactions.ToList();
        }

        public Transactions GetById(Guid entityId)
        {
            var transaction = db.Transactions.FirstOrDefault(c => c.Id == entityId);
            return transaction;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Transfer(Transactions entity, Guid account, Guid account2, decimal amount)
        {
            
        }

        public void Withdraw(Transactions entity, Guid account, decimal amount)
        {
            if (amount <= 0)
            {
                
                
                
            }
            else
                throw new Exception("You can't withdraw a negative ammount please use a deposit operation");
        }
    }
}
