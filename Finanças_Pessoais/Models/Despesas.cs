﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finanças_Pessoais.Models
{
    public class Despesas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " campo obrigatorio")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = " campo obrigatorio")]
        public string Data { get; set; }

        [Required(ErrorMessage = " campo obrigatorio")]
        public decimal Valor { get; set; }

        
        public Tipo Tipo { get; set; }

        public Despesas()
        {

        }
        
        public Despesas(int pId, string pLugar, string pData, decimal pValor, Tipo pTipo )
        {
            Id = pId;
            Lugar = pLugar;
            Data = pData;
            Valor = pValor;
            Tipo = pTipo;

        }
    }

}