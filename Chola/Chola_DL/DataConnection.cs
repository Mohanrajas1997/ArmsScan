using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Chola.Chola_DL
{
    public class DataConnection
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public DataConnection()
        {
            con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

            cmd = new MySqlCommand();
            cmd.Connection = con;

        }
        public DataConnection(string db)
        {
            con = new MySqlConnection();
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
        public DataTable RunProc(string command, Dictionary<string, Object> values = null)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        cmd.Parameters.AddWithValue(key, values[key]);
                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;
            }

        }
        public DataSet RunProc_ds(string command, Dictionary<string, Object> values = null)
        {
            DataSet temp = new DataSet();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        cmd.Parameters.AddWithValue(key, values[key]);
                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;
            }

        }
        public string[] RunDmlProc(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            //string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            //string source_name = this.GetType().ToString();
            string retmsg = string.Empty;
            string retresult = string.Empty; ;

            try
            {

                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            if (values[key] == null)
                            {
                                cmd.Parameters.AddWithValue(key, null);
                            }
                            else if (values[key].ToString() != "null")
                            {
                                cmd.Parameters.AddWithValue(key, values[key]);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(key, null);
                            }
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                retmsg = (string)cmd.Parameters["out_msg"].Value;
                retresult = (string)cmd.Parameters["out_result"].Value;

                string[] returnvalues = { retmsg, retresult };
                con.Close();
                return returnvalues;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] returnvalues = { "failed", "0" };
                return returnvalues;
            }
        }
    }
}
