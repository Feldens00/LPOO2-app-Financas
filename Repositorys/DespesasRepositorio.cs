using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using FinancasConnections;
using Entity;
using Repositorys.Contracts;
using Repositorys;

namespace Repositorys
{
    public class DespesasRepositorio: IDespesasRepositorio
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

        public IEnumerable<Despesas> getLimit()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select d.id, d.lugar, d.valor, d.datas, t.idTipo, t.nome ");
            sql.Append("From despesas d ");
            sql.Append("       inner join tipo t ");
            sql.Append("          on d.idTipo = t.idTipo ");
            sql.Append("   order by id desc limit 7");


            cmm.CommandText = sql.ToString();

            MySqlDataReader datar = conn.executarConsultas(cmm);
            while (datar.Read())
            {
                Despesas desp = new Despesas
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
                despesas.Add(desp);
            }
            datar.Dispose();
            return despesas;
        }
       

       

        


        public void Create(Despesas pDespesas)
        {
            /*string sql = "insert into despesas values(";
            sql += pDespesas.Id + ",'" + pDespesas.Lugar + "', '" + pDespesas.Data + "', " + pDespesas.Valor + " , " + pDespesas.Tipo.IdTipo + " )" ;
            conn.executarComando(sql);*/

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into despesas ( lugar , datas , valor , idTipo ) ");
            sql.Append(" values (@desp_lugar, @desp_data , @desp_valor , @desp_idTipo ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@desp_lugar",pDespesas.Lugar);
            cmm.Parameters.AddWithValue("@desp_data", pDespesas.Data);
            cmm.Parameters.AddWithValue("@desp_valor", pDespesas.Valor);
            cmm.Parameters.AddWithValue("@desp_idTipo", pDespesas.Tipo.IdTipo);
            conn.executarComando(cmm);
        }





        public  Despesas getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT *");
            sql.Append(" FROM despesas");
            sql.Append(" INNER JOIN  tipo  ");
            sql.Append(" ON despesas.idTipo = tipo.idTipo ");
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

            /* string update = "Update despesas set lugar='" + pDespesas.Lugar + "', datas='" + pDespesas.Data + "', valor= " + pDespesas.Valor + " , tipo ='"
                 + pDespesas.Tipo + "' where id=" + pDespesas.Id;
             conn.executarComando(update);*/

            MySqlCommand cmm = new MySqlCommand();
          
            StringBuilder sql = new StringBuilder();

            sql.Append("update despesas ");
            sql.Append("set datas=@data, valor=@valor,  lugar=@lugar, idTipo=@tipo ");
            sql.Append("where id=@idDesp");

            cmm.CommandText = sql.ToString();


            cmm.Parameters.AddWithValue("@data", pDespesas.Data);
            cmm.Parameters.AddWithValue("@valor", pDespesas.Valor);
            cmm.Parameters.AddWithValue("@lugar", pDespesas.Lugar);
            cmm.Parameters.AddWithValue("@tipo", pDespesas.Tipo.IdTipo);
            cmm.Parameters.AddWithValue("@idDesp", pDespesas.Id);
            conn.executarComando(cmm);

        }
        public void Delete(int pId)
        {
            /*string sql = "Delete from  despesas where id =" + pId;
            conn.executarComando(sql);*/

            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from despesas where id = @id_delete");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);

        }
    }
}