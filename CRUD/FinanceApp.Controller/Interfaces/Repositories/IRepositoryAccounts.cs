using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Controller.Interfaces.Repositories
{
    public interface IRepositoryAccounts<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IList<TEntity, TEntityId>, ISave
    {
    }
}
