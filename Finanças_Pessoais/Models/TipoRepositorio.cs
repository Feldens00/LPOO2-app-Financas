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
       private List<Tipo> tipo = new List<Tipo>();


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
            /* string sql = "insert into tipo values(";
             sql += pTipo.IdTipo + ",'" + pTipo.Nome + "' )";
             conn.executarComando(sql);*/

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into tipo ( nome ) ");
            sql.Append(" values (@nome ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pTipo.Nome);
            conn.executarComando(cmm);
        }



        public Tipo getOnes(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT idTipo , nome  ");
            sql.Append(" FROM tipo ");
            sql.Append(" WHERE idTipo = @tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@tipo", pId);
            MySqlDataReader datar = conn.executarConsultas(cmm);
            datar.Read();

            Tipo tipo = new Tipo
            {
                IdTipo = (int)datar["idTipo"],
                Nome = (string)datar["nome"]
               
            };
            datar.Dispose();
            return tipo;
        }

       

   
        public void Update(Tipo pTipo)
        {

            /* string update = "Update tipo set nome='" + pTipo.Nome + "' " + "' where id=" + pTipo.IdTipo;
             conn.executarComando(update);*/

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("update tipo ");
            sql.Append("set nome = @nome ");
            sql.Append("where idTipo=@Tipo ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@Tipo", pTipo.IdTipo);
            cmm.Parameters.AddWithValue("@nome", pTipo.Nome);
            conn.executarComando(cmm);
        }
        public void Delete(int pId)
        {
            /* string sql = "Delete from  tipo where idTipo =" + pId;
             conn.executarComando(sql);*/

            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from tipo where idTipo = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);


        }
    }
}