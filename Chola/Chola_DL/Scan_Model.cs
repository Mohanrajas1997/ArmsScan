using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chola.Chola_DL
{
    public class GlobalClass
    {
        public string gUserName;
        public int gUid;
        public string gUserFullName;
        public string gUserRights;
    }
   public class Scan_Model
    {

        public int scan_gid { get; set; }
        public int scan_packet_gid { get; set; }
        public string scan_reader_text { get; set; }
        public string scan_chq_no { get; set; }
        public string scan_micr_code { get; set; }
        public string scan_tran_code { get; set; }
        public string scan_base_code { get; set; }
        public string scan_chq_type { get; set; }
        public int scan_chq_gid { get; set; }
        public string scan_remarks { get; set; }
       
    }
   public class ScanResponse
   {
       public int Out_scanimage_gid { get; set; }
       public int Out_scan_gid { get; set; }
       public string Out_msg { get; set; }
       public int Out_result { get; set; }
   }
    public class ScanImage_Model
    {
        public int scanimage_gid { get; set; }
        public int scamimage_scan_gid { get; set; }
        public string scanimage_type { get; set; }
        public string scanimage_side { get; set; }
    }
    public class ScanSaveImageFld_Model
    {
        public int scanimage_gid { get; set; }
        public string scanImage_dtls { get; set; }
    }
    
}
