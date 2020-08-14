using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using FastMember;
using KaryaMurniTask.Models;
using Newtonsoft.Json;

namespace KaryaMurniTask.Helper
{
    public class ConnectionString
    {
        public string KARYA_MURNI { get; set; }
    }

    public class SQLHelper : IDisposable
    {
        static string Config = File.ReadAllText(@"Config.json");
        static ConnectionString Conn = JsonConvert.DeserializeObject<ConnectionString>(Config);

        private string CONNECTION_STRING1 = Conn.KARYA_MURNI;

        private SqlConnection conn;
        private string selecConnection = "";

        public SQLHelper()
        {
            conn = new SqlConnection();
            switchConnection();
            this.conn.ConnectionString = getConnectionString();
        }

        public string switchConnection(string Conn = "1")
        {
            if (Conn == "1")
                selecConnection = CONNECTION_STRING1;
            else
                selecConnection = "";
            return selecConnection;
        }

        public string getConnectionString()
        {
            return selecConnection;
        }

        ~SQLHelper()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
           
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        public SqlDataReader Execute(string Querys)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = getConnectionString();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = conn.CreateCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Querys;

                var dr = cmd.ExecuteReader();

                return dr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
