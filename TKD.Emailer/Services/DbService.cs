using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace TKD.Emailer.Services
{
    public class DbService
    {
        public DataSet QueryDatabase(string sqlCommand)
        {
            var conn = new
                OleDbConnection
            {
                ConnectionString = Config.ConnectionString
            };

            try
            {
                conn.Open();
                var comm = conn.CreateCommand();
                
                comm.CommandText = sqlCommand;
                comm.CommandType = CommandType.Text;

                var results = new DataTable();

                var ds = new DataSet();
                var adapter = new OleDbDataAdapter(comm);
                adapter.Fill(results);
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public DataGridView Search(string sql)
        {
            var dataTable = QueryDatabase(sql);
            var grid = new DataGridView { DataSource = dataTable.Tables[0] };
            return grid;
        }

        public DataTable GetCategories()
        {
            const string categorySql = "SELECT id, description FROM ContactCategories";
            var dataSet = QueryDatabase(categorySql);
            return dataSet.Tables[0];
        }

        public DataTable GetRankAndOrder()
        {
            const string rankSql = "SELECT name, rorder FROM ranks ORDER BY rorder";
            var dataSet = QueryDatabase(rankSql);
            return dataSet.Tables[0];
        }
    }
}