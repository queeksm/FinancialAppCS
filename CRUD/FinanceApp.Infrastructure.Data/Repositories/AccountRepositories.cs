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
    public class AccountRepositories : IRepositoryAccounts<Accounts,Guid>
    {
        private ClientContext db;

        public AccountRepositories(ClientContext _db)
        {
            db = _db;
        }      

        public void AddBalance(Guid entityId, decimal balance)
        {
            var selectedAccount = db.Accounts.Where(c => c.AccId == entityId).FirstOrDefault();
            if (balance >= 0)
            {                
                if (selectedAccount == null)
                    throw new NullReferenceException("You can't add balance to a non existant account");
                selectedAccount.AccountBalance += balance;
                selectedAccount.ModificationDate = DateTime.Now;
                db.Entry(selectedAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }else
            {
                if (selectedAccount == null)
                    throw new NullReferenceException("You can't remove balance to a non existant account");
                if (selectedAccount.AccountBalance - balance < 0)
                    throw new ArgumentException("You can't remove more funds that the available");
                selectedAccount.AccountBalance += balance;
                selectedAccount.ModificationDate = DateTime.Now;
                db.Entry(selectedAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void CancelAccount(Guid entityId)
        {
            var selectedAccount = db.Accounts.Where(c => c.AccId == entityId).FirstOrDefault();
            if (selectedAccount == null)
                throw new NullReferenceException("You can't cancel an account that does not exist");
            if (selectedAccount.AccountBalance != 0)
                throw new InvalidOperationException("You can't cancel an account with non zero balance");
            selectedAccount.AccountCancelled = true;
            selectedAccount.AccountState = false;
            selectedAccount.ModificationDate = DateTime.Now;
        }

        public void ChangeStatus(Guid entityId)
        {
            var selectedAccount = db.Accounts.Where(c => c.AccId == entityId).FirstOrDefault();
            if (selectedAccount == null)
                throw new NullReferenceException("you can't Change the status of a non existant account");

            selectedAccount.AccountState = !selectedAccount.AccountState;
            selectedAccount.ModificationDate = DateTime.Now;
            db.Entry(selectedAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Accounts> GetAll()
        {
            return db.Accounts.ToList();
        }

        public Accounts GetById(Guid entityId)
        {
            var selectedAccount = db.Accounts.Where(c => c.AccId == entityId).FirstOrDefault();
            return selectedAccount;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        Accounts IRepositoryAccounts<Accounts, Guid>.AccAdd(Accounts entity, Guid entityId)
        {
            
            var selectedClient = db.Clients.Where(c => c.CliId == entityId).First();
            Random random = new Random();
            if (selectedClient == null)
                throw new InvalidOperationException("The client you're trying to associate the account to does not exist");
            switch (entity.AccountType)
            {
                case 0:
                    entity.AccountNumber = string.Concat("53",random.Next(00000000, 99999999).ToString());
                    break;
                case 1:
                    entity.AccountNumber = string.Concat("33", random.Next(00000000, 99999999).ToString());
                    break;
                default:
                    throw new Exception("The account can only be 0 = savings, 1 = checking");
            }

            entity.AccId = Guid.NewGuid();
            entity.Client = selectedClient;
            db.SaveChanges();            
            db.Accounts.Add(entity);
            return entity;
        }
    }
}
    