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
    public class TransactionServices : ITransactionBase<Transactions, Guid>
    {

        IRepositoryAccounts<Accounts, Guid> accountRepo;
        IRepositoryTransactions<Transactions, Guid> transactionRepo;
        public TransactionServices(IRepositoryAccounts<Accounts,Guid> _accountRepo, IRepositoryTransactions<Transactions, Guid> _transactionRepo)
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

        public void Deposit(Transactions entity, Guid accountid, decimal amount)
        {
            var account = accountRepo.GetById(accountid);
            accountRepo.AddBalance(account.AccId, amount);
            entity.Id = Guid.NewGuid();
            entity.TransactionType = "Deposit";
            entity.Amount = amount;
            entity.ReceiverAccount = accountid;
            entity.SendingAccount = accountRepo.GetById(accountid);
            transactionRepo.Add(entity);
            transactionRepo.SaveChanges();

            
            account.Transactions.Add(entity);


        }

        public void Withdraw(Transactions entity, Guid accountid, decimal amount)
        {
            var account = accountRepo.GetById(accountid);
            accountRepo.AddBalance(accountid, -amount);
            entity.Id = Guid.NewGuid();
            entity.TransactionType = "Whithdrawal";
            entity.Amount = amount;
            entity.ReceiverAccount = accountid;
            entity.SendingAccount = accountRepo.GetById(accountid);
            transactionRepo.Add(entity);
            transactionRepo.SaveChanges();


            account.Transactions.Add(entity);
        }

        public void Transfer(Transactions entity, Guid accountid, Guid accountid2, decimal amount)
        {
            var account = accountRepo.GetById(accountid);
            accountRepo.AddBalance(accountid, -amount);
            accountRepo.AddBalance(accountid2, amount);
            entity.Id = Guid.NewGuid();
            entity.TransactionType = "Transfer";
            entity.Amount = amount;
            entity.ReceiverAccount = accountid2;
            entity.SendingAccount = accountRepo.GetById(accountid);

            transactionRepo.Add(entity);
            transactionRepo.SaveChanges();


            account.Transactions.Add(entity);
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
