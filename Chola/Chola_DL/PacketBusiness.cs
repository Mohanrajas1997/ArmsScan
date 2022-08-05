using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chola.Chola_DL
{
    public class PacketBusiness
    {
        public DataTable GetPacketDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_arms_get_packetqueue", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }
        //public DataTable GetScanningDetails(string ConditionStatus)
        //{
        //    DataTable dtScandtl = new DataTable();
        //    try
        //    {
        //        Dictionary<string, Object> values = new Dictionary<string, object>();
        //        DataConnection con = new DataConnection();
        //        values.Add("In_Condition", ConditionStatus);
        //        dtScandtl = con.RunProc("sp_get_scanningqueue", values);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return dtScandtl;
        //}
        public DataTable GetRescanningList(int Packetgid)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_packetgid", Packetgid);
                dtScandtl = con.RunProc("sp_arms_get_rescanninglist", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }
        public DataTable GetPacketSinglefetch(int Packetgid)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_packetgid", Packetgid);
                dtScandtl = con.RunProc("sp_arms_get_packetlist", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }
        public DataTable GetChequeDetails(int Packetgid)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_packetgid", Packetgid);
                dtScandtl = con.RunProc("sp_arms_get_chequelist", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }
        public DataTable GetPacketSingleDetails(string GnsaRefNo)
        {
            DataTable dtPacketdt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_GnsaRefNo", GnsaRefNo);
                dtPacketdt = con.RunProc("sp_arms_get_packetdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtPacketdt;

        }
        public DataTable GetScanImageGid(int ScanGid)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_scan_gid", ScanGid);
                dtScandtl = con.RunProc("sp_arms_get_scanimage", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public string[] UpdateScanReimage(int Packetgid)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_packetgid", Packetgid);                
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_set_rescan", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;

        }

    }
}
