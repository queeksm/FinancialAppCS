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
        public Accounts Add(Accounts entity)
        {
            if (entity == null)
                throw new ArgumentNullException("'Account' cannot be null");
            var addAccount = accountRepo.Add(entity);

            if (clientRepo.GetById(entity.Client.Id) == null)
                throw new NullReferenceException("The client associated to this account does not exist");
            
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

        public void CancelAccounts (Accounts entity)
        {
            if (entity == null)
                throw new ArgumentNullException("You cannot cancel a non existant account.");
            if (entity.AccountBalance != 0)
                throw new ArgumentException("You cannot cancel an account with a balance different from 0");
            entity.AccountCancelled = true;
        }

        public void ChangeStatus (Accounts entity)
        {
            if (entity == null)
                throw new NullReferenceException("You cannot change the status of a non existant account");
            entity.AccountState = !entity.AccountState;
        }

        public void AddBalance(Accounts entity, decimal balance)
        {
            if(entity == null)
                throw new ArgumentNullException("You cannot add funds to a non existant account");
            entity.AccountBalance += balance;
        }

        public void RemoveBalance(Accounts entity, decimal balance)
        {
            if (entity == null)
                throw new ArgumentNullException("You cannot add funds to a non existant account");
            if (entity.AccountBalance - balance < 0)
                throw new ArgumentException("You can't remove more funds than the actual balance of the account");
            entity.AccountBalance -= balance;
        }
    }
}
