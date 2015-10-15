using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finanças_Pessoais.Models
{
    public class Tipo
    {
        public int IdTipo { get; set; }
        public string Nome { get; set; }
       

        public Tipo()
        {

        }

        public Tipo(int pIdTipo, string pNome)
        {
            IdTipo = pIdTipo;
            Nome = pNome;

        }

     
        
    }
}