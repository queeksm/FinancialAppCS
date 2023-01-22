﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface ITransactionBase<TEntity,TEntityId, TAccount, TAccount2>:IAdd<TEntity>, IList<TEntity, TEntityId>
    {
        void Deposit(TEntity entity,TAccount account, decimal amount);

        void Withdraw(TEntity entity,TAccount account, decimal amount);

        void Transfer(TEntity entity,TAccount account, TAccount2 account2, decimal amount);
        
    }
}
