using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface IAccountBase<TEntity, TEntityId>: IAdd<TEntity>, IList<TEntity, TEntityId>
    {
        void CancelAccount(TEntity entity);

        void ChangeStatus(TEntity entity);

        void AddBalance(TEntity entity, decimal balance);

        void RemoveBalance(TEntity entity, decimal balance);
    }
}
