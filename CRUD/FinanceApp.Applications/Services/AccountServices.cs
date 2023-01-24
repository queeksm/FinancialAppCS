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
    public class AccountServices : IAccountBase<Accounts, Guid>
    {   
        IRepositoryAccounts<Accounts, Guid> accountRepo;
        IBaseRepository<Clients, Guid> clientRepo;
        

        public AccountServices(IRepositoryAccounts<Accounts,Guid> _accountRepo,IBaseRepository<Clients,Guid> _clientRepo)
        {
            accountRepo = _accountRepo;
            clientRepo = _clientRepo;            
        }
        public Accounts AccAdd(Accounts entity, Guid id)
        {
            if (entity == null)
                throw new ArgumentNullException("'Account' cannot be null");            

            if (clientRepo.GetById(id) == null)
                throw new NullReferenceException("The client associated to this account does not exist");

            var addAccount = accountRepo.AccAdd(entity,id);
            addAccount.Client.Accounts.Add(entity);                       
            clientRepo.SaveChanges();
            return addAccount;
        }
        public List<Accounts> GetAll()
        {
            return accountRepo.GetAll();
        }

        public Accounts GetById(Guid entityId)
        {
            return accountRepo.GetById(entityId);
        }

        public void CancelAccount (Guid entityId)
        {
            var selectedAccount = accountRepo.GetById(entityId);            
            if (selectedAccount.AccountBalance != 0)
                throw new ArgumentException("You cannot cancel an account with a balance different from 0");
            selectedAccount.AccountCancelled = true;
            clientRepo.SaveChanges();
        }

        public void ChangeStatus (Guid entityId)
        {
            var selectedAccount = accountRepo.GetById(entityId);

            selectedAccount.AccountState = !selectedAccount.AccountState;
            clientRepo.SaveChanges();
        }

        public void AddBalance(Guid entityId, decimal balance)
        {
            var selectedAccount = accountRepo.GetById(entityId);
            if (balance >= 0)
            {
                
                if (selectedAccount == null)
                    throw new ArgumentNullException("You cannot add funds to a non existant account");
                selectedAccount.AccountBalance += balance;
                clientRepo.SaveChanges();
            }
            else
            {                
                if (selectedAccount == null)
                    throw new ArgumentNullException("You cannot add funds to a non existant account");
                if (selectedAccount.AccountBalance - balance < 0)
                    throw new ArgumentException("You can't remove more funds than the actual balance of the account");
                selectedAccount.AccountBalance -= balance;
                clientRepo.SaveChanges();
            }
            
        }
    }
}
