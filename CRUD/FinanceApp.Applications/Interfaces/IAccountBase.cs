using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceApp.Controller.Interfaces;

namespace FinanceApp.Applications.Interfaces
{
    public interface IAccountBase<TEntidad, TEntidadId>: IAdd<TEntidad>, IEdit<TEntidad>, IList<TEntidad, TEntidadId>
    {

    }
}
