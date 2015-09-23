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

        public IEnumerable<Despesas> getAll()
        {
            

            string sql = "select * from despesas";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                despesas.Add(new Despesas((int)dr["id"], (string)dr["lugar"], (string)dr["datas"], (int)dr["valor"], (string)dr["tipo"]));

            }
            return despesas;
        }

        public IEnumerable<Despesas> getLimit()
        {


            string sql = "select * from despesas order by id desc limit 7";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                despesas.Add(new Despesas((int)dr["id"], (string)dr["lugar"], (string)dr["datas"], (int)dr["valor"], (string)dr["tipo"]));

            }
            return despesas;
        }

        public void Create(Despesas pDespesas)
        {
            string sql = "insert into despesas values(";
            sql += pDespesas.Id + ",'" + pDespesas.Lugar + "', '" + pDespesas.Data + "', " + pDespesas.Valor + ", '" + pDespesas.Tipo + "' )" ;
            conn.executarComando(sql);
        }



       

        public Despesas getOne(int pId)
        {


            string sql = "select * from despesas where id=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);


            dr.Read();
            Despesas despesasUpdate = new Despesas((int)dr["id"], (string)dr["lugar"], (string)dr["datas"], (int)dr["valor"], (string)dr["tipo"]);




            return despesasUpdate;
        }
        public void Update(Despesas pDespesas)
        {
            
            string update = "Update despesas set tipo='" + pDespesas.Tipo + "' where id=" + pDespesas.Id;
            conn.executarComando(update);


        }
        public void Delete(int pId)
        {
            string sql = "Delete from  despesas where id =" + pId;
            conn.executarComando(sql);

            
        }
    }
}