using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finanças_Pessoais.Models
{
    public class Despesas
    {
        public int Id { get; set; }
        public string Lugar { get; set; }
        public string Data { get; set; }
        public int  Valor { get; set; }
        public string Tipo { get; set; }

        public Despesas()
        {

        }
        
        public Despesas(int pId, string pLugar, string pData, int pValor, string pTipo )
        {
            Id = pId;
            Lugar = pLugar;
            Data = pData;
            Valor = pValor;
            Tipo = pTipo;

        }
    }

}