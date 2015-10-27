using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class Tipo :ITipo
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