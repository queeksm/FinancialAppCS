using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface ITransactionBase<TEntity,TEntityId> :IAdd<TEntity>, IList<TEntity, TEntityId>
    {
        void Deposit(TEntity entity, Guid accountid, decimal amount);

        void Withdraw(TEntity entity, Guid accountid, decimal amount);

        void Transfer(TEntity entity, Guid accountid, Guid accountid2, decimal amount);
        
    }
}

