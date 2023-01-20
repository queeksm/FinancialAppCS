using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Controller.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>, ISave
    {
    }
}
