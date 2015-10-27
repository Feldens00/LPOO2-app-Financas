using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IDespesas

    {
         int Id { get; set; }
         string Lugar { get; set; }
         string Data { get; set; }
         decimal Valor { get; set; }

    }
}
