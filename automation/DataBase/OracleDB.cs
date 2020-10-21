using Oracle.ManagedDataAccess.Client;
using RazorEngine.Templating;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automation02.DataBase
{
    class OracleDB
    {
        private OracleConnection connection;
        private OracleCommand command;
        private OracleConnectionStringBuilder ocsb;
        private OracleDataReader Data_Reader;
        private string QUERY_SQL;
        private bool canConnect = false;

        public OracleDB()
        {
            Connection();
        }

        private void Connection()
        {
            connection = new OracleConnection();
            ocsb = new OracleConnectionStringBuilder();
            ocsb.Password = "Pa$$word001";
            ocsb.UserID = "BIOPOS";
            ocsb.DataSource = "192.168.0.81:1521/Calidad";
            connection.ConnectionString = ocsb.ConnectionString;
       
            try {

                if (canConnect == false) 
                {
                    connection.Open();
                    canConnect = true;
                }

            }catch (SqlException e) 
            {
            
            }

            command = new OracleCommand();
            command.Connection = connection;
        }

        private void DataReader(String QUERY_SQL)
        {
            try
            {
                Thread.Sleep(1000);
                OracleCommand command = new OracleCommand(QUERY_SQL, connection);
                OracleDataReader reader = command.ExecuteReader();
                Data_Reader = reader;
            }
            catch (SqlException e) 
            {
            
            }
        
        }


        public void update_equipo()
        {
            try
            {
                QUERY_SQL = "Update C007T_DEVICE set TX_SERIAL = 'G46183600695' where NU_ID = '1002'";
                DataReader(QUERY_SQL);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            Data_Reader.Close();
        }


    }
}
