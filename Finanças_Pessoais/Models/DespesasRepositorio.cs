using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using FinancasConnections;


namespace Finanças_Pessoais.Models
{
    public class DespesasRepositorio
    {

        DataBase conn = new DataBase();
        private List<Despesas> despesas = new List<Despesas>();

       /*  public IEnumerable<Despesas> getAll()
         {


             string sql = "select * from despesas";
             MySqlDataReader dr = conn.executarConsulta(sql);

             while (dr.Read())
             {
                 despesas.Add(new Despesas((int)dr["id"], (string)dr["lugar"], (DateTime)dr["datas"], (int)dr["valor"], (Tipo)dr["tipo"]));

             }
             return despesas;
         }
         */
        public IEnumerable<Despesas> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select d.id, d.lugar, d.valor, d.datas, t.idTipo, t.nome ");
            sql.Append("From despesas d ");
            sql.Append("       inner join tipo t ");
            sql.Append("          on d.idTipo = t.idTipo ");


            cmm.CommandText = sql.ToString();
           
            MySqlDataReader datar = conn.executarConsultas(cmm);
            while (datar.Read())
            {
              Despesas desp= new Despesas
              {
                  Id = (int)datar["id"],
                  Lugar = (string)datar["lugar"],
                  Data = (string)datar["datas"],
                  Valor = (decimal)datar["valor"],
                  Tipo = new Tipo
                        {
                          IdTipo = (int)datar["idTipo"],
                        Nome=(string)datar["nome"]

                        }
              } ;
                despesas.Add(desp);
            }
            datar.Dispose();
            return despesas;
        }

        /*public List<Despesas> getLimit()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from despesas order by id desc limit 7");
           


            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsulta(cmm);
            while (dr.Read())
            {

                Despesas desp = new Despesas
                {
                    Id = (int)dr["id"],
                    Lugar = (string)dr["lugar"],
                    Data = (DateTime)dr["datas"],
                    Valor = (int)dr["valor"],
                    Tipo = new Tipo
                    {
                        IdTipo = (int)dr["idTipo"],
                        Nome = (string)dr["nome"]

                    }


                };
                despesas.Add(desp);
            }
            dr.Dispose();
            return despesas;
        }*/

       

        


        public void Create(Despesas pDespesas)
        {
            string sql = "insert into despesas values(";
            sql += pDespesas.Id + ",'" + pDespesas.Lugar + "', '" + pDespesas.Data + "', '" + pDespesas.Valor + "' , " + pDespesas.Tipo.IdTipo + " )" ;
            conn.executarComando(sql);
        }



       

        public  Despesas getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" select *");
            sql.Append(" FROM despesas");
            sql.Append(" WHERE id = @id_despesa");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_despesa", pId);
              MySqlDataReader datar = conn.executarConsultas(cmm);
            datar.Read();

            Despesas despesa = new Despesas
            {
                Id = (int)datar["id"],
                Lugar = (string)datar["lugar"],
                Data = (string)datar["datas"],
                Valor = (decimal)datar["valor"],
                Tipo = new Tipo
                {
                    IdTipo = (int)datar["idTipo"],
                    Nome = (string)datar["nome"]

                }
            };
            datar.Dispose();
            return despesa;
        }
        public void Update(Despesas pDespesas)
        {
            
            string update = "Update despesas set lugar='" + pDespesas.Lugar + "', datas='" + pDespesas.Data + "', valor= '" + pDespesas.Valor + "' , tipo ='"
                + pDespesas.Tipo + "' where id=" + pDespesas.Id;
            conn.executarComando(update);


        }
        public void Delete(int pId)
        {
            string sql = "Delete from  despesas where id =" + pId;
            conn.executarComando(sql);

            
        }
    }
}