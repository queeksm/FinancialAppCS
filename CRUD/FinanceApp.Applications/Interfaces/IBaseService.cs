using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface IBaseService<TEntidad, TEntidadId>: IAdd<TEntidad>, IEdit<TEntidad>, IDelete<TEntidadId>, IList<TEntidad, TEntidadId>
    {
    }
}
