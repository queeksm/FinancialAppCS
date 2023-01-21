﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Controller.Interfaces
{
    public interface IList<TEntity,TEntityId>
    {
        List<TEntity> GetAll();
        TEntity GetById(TEntityId entityId);
    }
}
