using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface IAccountBase<TEntity, TEntityId>: IList<TEntity, TEntityId>
    {

        TEntity AccAdd(TEntity entity, TEntityId entityId);
        void CancelAccount(TEntityId entityId);

        void ChangeStatus(TEntityId entityId);

        void AddBalance(TEntityId entityId, decimal balance);
        
    }
}
