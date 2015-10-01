using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancasConnections;
using MySql.Data.MySqlClient;
using System.Text;

namespace Finanças_Pessoais.Models
{
    public class TipoRepositorio
    {

        DataBase conn = new DataBase();
        List<Tipo> tipo = new List<Tipo>();


        public IEnumerable<Tipo> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select  * from tipo");
            
        


            cmm.CommandText = sql.ToString();
            
            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Tipo tip = new Tipo
                {
                    IdTipo= (int)dr["idTipo"],
                    Nome = (string)dr["nome"]
                   
                    


                };
                tipo.Add(tip);
            }
            dr.Dispose();
            return tipo;
        }


        public void Create(Tipo pTipo)
        {
            string sql = "insert into tipo values(";
            sql += pTipo.IdTipo + ",'" + pTipo.Nome + "' )";
            conn.executarComando(sql);
        }

      


        public Tipo getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" select *");
            sql.Append(" FROM tipo");
            sql.Append(" WHERE idTipo = @id_tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_tipo", pId);
            MySqlDataReader dr = conn.executarConsultas(cmm);
            dr.Read();

            Tipo tipo = new Tipo
            {
                IdTipo = (int)dr["idTipo"],
                Nome = (string)dr["nome"],
               
            };

            return tipo;
        }

   
        public void Update(Tipo pTipo)
        {

            string update = "Update tipo set nome='" + pTipo.Nome + "' " + "' where id=" + pTipo.IdTipo;
            conn.executarComando(update);


        }
        public void Delete(int pId)
        {
            string sql = "Delete from  tipo where idTipo =" + pId;
            conn.executarComando(sql);


        }
    }
}