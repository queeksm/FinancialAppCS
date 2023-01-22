using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller;
using FinanceApp.Controller.Interfaces.Repositories;
using FinanceApp.Applications.Interfaces;

namespace FinanceApp.Applications.Services
{
    public class TransactionServices : ITransactionBase<Transactions, Guid, Accounts, Accounts>
    {

        IRepositoryAccounts<Accounts, Guid> accountRepo;
        IRepositoryTransactions<Transactions, Guid, Accounts, Accounts> transactionRepo;
        public TransactionServices(IRepositoryAccounts<Accounts,Guid> _accountRepo, IRepositoryTransactions<Transactions, Guid,Accounts,Accounts> _transactionRepo)
        {
            accountRepo = _accountRepo;
            transactionRepo = _transactionRepo;
        }
        public Transactions Add(Transactions entity)
        {
            if (entity == null)
                throw new NullReferenceException("You can't create an empty transaction");
            var transaction = transactionRepo.Add(entity);
            return transaction;
        }

        public void Deposit(Transactions entity, Accounts account, decimal amount)
        {
            accountRepo.AddBalance(account, amount);
            entity.TransactionType = "Deposit";
            entity.Amount = amount;
            entity.ReceiverAccount = account;
            entity.SendingAccount = account;            

        }

        public void Withdraw(Transactions entity, Accounts account, decimal amount)
        {
            accountRepo.RemoveBalance(account, amount);
            entity.TransactionType = "Whithdrawal";
            entity.Amount = amount;
            entity.ReceiverAccount = account;
            entity.SendingAccount = account;
        }

        public void Transfer(Transactions entity, Accounts account, Accounts account2, decimal amount)
        {
            accountRepo.RemoveBalance(account, amount);
            accountRepo.AddBalance(account2, amount);
            entity.TransactionType = "Transfer";
            entity.Amount = amount;
            entity.ReceiverAccount = account2;
            entity.SendingAccount = account;
        }

        public List<Transactions> GetAll()
        {
            return transactionRepo.GetAll();
        }

        public Transactions GetById(Guid entityId)
        {
            return transactionRepo.GetById(entityId);
        }
    }
}
