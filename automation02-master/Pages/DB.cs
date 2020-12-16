using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace automation02.Pages
{
    class DB
    {
        private String cs = "Host=192.168.0.81;Username=BIOPOS;Password=Pa$$word001;Database=BIOPOS";
        private NpgsqlConnection con;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        private String padden;
        private String sql;
        //private Afiliado afiliado_temporal;
        private String padtipo;
        private String padcta;
        private String padcod;
        private String padcondoc;
        private String planilla;
        private String planilla_aux;
        private String padconcod;
        private bool canConnect = false;

        private String aux;


        /* MODIFICARLOS 
         
        public string Padtipo { get => padtipo; set => padtipo = value; }
        public string Padcta { get => padcta; set => padcta = value; }
        public string Padcod { get => padcod; set => padcod = value; }
        public string Padconcod { get => padconcod; set => padconcod = value; }
        public string Padcondoc { get => padcondoc; set => padcondoc = value; }

        */

        public DB()
        {
            connect2();
        }


        public void update_equipo(String planilla)
        {
            try
            {

                sql = "Update C007T_DEVICE set TX_SERIAL = 'G46183600694' where NU_ID = '1002'";
                data_reader(sql);
            }

            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            dr.Close();
        }

        public void temporal_liquidacion()
        {

            try
            {
                sql = "select p.padtipo,p.padcta,p.padcod,p.padconcod,p.padcondoc from usuwebcontribuyente uwc join padron p on uwc.concod = p.padconcod where uwc.usuwebcondoc = 37933047 ORDER BY RANDOM() LIMIT 1";
                data_reader(sql);
                while (dr.Read())
                {
                    // (string)dr["columna"].ToString();
                    padtipo = (string)dr["padtipo"].ToString().Trim();
                    padcta = (string)dr["padcta"].ToString().Trim();
                    padcod = (string)dr["padcod"].ToString().Trim();
                    padconcod = (string)dr["padconcod"].ToString().Trim();
                    padcondoc = (string)dr["padcondoc"].ToString().Trim();
                }
                dr.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        private void connect2()
        {
            con = new NpgsqlConnection(cs);

            try
            {
                if (canConnect == false)
                {
                    con.Open();
                    canConnect = true;
                }



            }
            catch
            {
                canConnect = false;
            }



            cmd = new NpgsqlCommand();
            cmd.Connection = con;
        }



        private void data_reader(String sql)
        {
            try
            {
                Thread.Sleep(1000);
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();
                dr = reader;

            }
            catch (Exception e)
            {
            }
        }
    }
}

