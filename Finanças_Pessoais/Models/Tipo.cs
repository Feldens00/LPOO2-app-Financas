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
        public static List<Tipo> tipo = new List<Tipo>();

        public Tipo()
        {

        }

        public Tipo(int pIdTipo, string pNome)
        {
            IdTipo = pIdTipo;
            Nome = pNome;

        }

        public static void popular()
        {
            
            Tipo t = new Tipo(1, "Alimentação");
            Tipo t2 = new Tipo(2, "combustível");
            Tipo t3 = new Tipo(3, "supermercado");
            Tipo t4 = new Tipo(4, "farmácias");
            Tipo t5 = new Tipo(5, "Impostos");
            tipo.Add(t);
            tipo.Add(t2);
            tipo.Add(t3);
            tipo.Add(t4);
            tipo.Add(t5);


        }
    }
}