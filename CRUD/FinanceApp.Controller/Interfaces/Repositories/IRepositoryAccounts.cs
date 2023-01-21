using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Controller.Interfaces.Repositories
{
    public interface IRepositoryAccounts<TEntity, TEntityId> : IAdd<TEntity>, IList<TEntity, TEntityId>, ISave
    {
        void CancelAccount(TEntity entity);

        void ChangeStatus(TEntity entity);

        void AddBalance(TEntity entity, decimal balance);

        void RemoveBalance(TEntity entity, decimal balance);
    }
}
