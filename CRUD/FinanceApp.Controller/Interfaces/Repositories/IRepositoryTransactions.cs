using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Controller.Interfaces.Repositories
{
    public interface IRepositoryTransactions<TEntity, TEntityId> :IAdd<TEntity>, IList<TEntity, TEntityId>, ISave
    {
        void Deposit(TEntity entity, Guid accountId, decimal amount);

        void Withdraw(TEntity entity, Guid accountId, decimal amount);

        void Transfer(TEntity entity, Guid accountId, Guid account2, decimal amount);
    }
}
