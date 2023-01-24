using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Controller.Interfaces.Repositories
{
    public interface IRepositoryAccounts<TEntity, TEntityId> : IList<TEntity, TEntityId>, ISave
    {

        TEntity AccAdd(TEntity entity, TEntityId entityId);
        void CancelAccount(TEntityId entityId);

        void ChangeStatus(TEntityId entityId);

        void AddBalance(TEntityId entityId, decimal balance);        
    }
}
