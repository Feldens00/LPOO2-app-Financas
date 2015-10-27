using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorys.Contracts
{
    interface IDespesasRepositorio : IRepositorioGenerico<Despesas>
    {
        IEnumerable<Despesas> getLimit();
    }
}
