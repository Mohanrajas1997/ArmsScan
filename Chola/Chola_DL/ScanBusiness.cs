using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
namespace Chola.Chola_DL
{
    public class ScanBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public ScanResponse SaveScanHeader(Scan_Model ObjScanMdl)
        {
            ScanResponse ObjHdr = new ScanResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    string Urlcon = "Scan/";
                    client.BaseAddress = new Uri(apiurl + Urlcon);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(ObjScanMdl), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("SaveScanDetails", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    ObjHdr = (ScanResponse)JsonConvert.DeserializeObject(post_data, ObjHdr.GetType());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ObjHdr;
        }

        public ScanResponse SaveScanImage(ScanImage_Model ObjSaveImg)
        {
            ScanResponse ObjRes = new ScanResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    string Urlcon = "Scan/";
                    client.BaseAddress = new Uri(apiurl + Urlcon);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(ObjSaveImg), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("SaveScanImage", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    ObjRes = (ScanResponse)JsonConvert.DeserializeObject(post_data, ObjRes.GetType());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ObjRes;
        }
        public ScanSaveImageFld_Model SaveImageFld(ScanSaveImageFld_Model ObjImageFld)
        {
            ScanSaveImageFld_Model ObjImageRes = new ScanSaveImageFld_Model();
            try
            {
                using (var client = new HttpClient())
                {
                    string Urlcon = "Scan/";
                    client.BaseAddress = new Uri(apiurl + Urlcon);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(ObjImageFld), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("SaveImageFolder", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    ObjImageRes = (ScanSaveImageFld_Model)JsonConvert.DeserializeObject(post_data, ObjImageRes.GetType());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ObjImageRes;
        }
        public ScanSaveImageFld_Model GetScanImage(ScanSaveImageFld_Model ObjGetImage)
        {
            ScanSaveImageFld_Model ObjGetImageRes = new ScanSaveImageFld_Model();
            try
            {
                using (var client = new HttpClient())
                {
                    string Urlcon = "Scan/";
                    client.BaseAddress = new Uri(apiurl + Urlcon);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(ObjGetImage), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("viewimage", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();



                   string res = (string)JsonConvert.DeserializeObject(post_data, typeof(string));
                   ObjGetImageRes = (ScanSaveImageFld_Model)JsonConvert.DeserializeObject(res, typeof(ScanSaveImageFld_Model));

                    //MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(post_data));
                  //  ObjGetImageRes = (ScanSaveImageFld_Model)JsonConvert.DeserializeObject(post_data, typeof(ScanSaveImageFld_Model));
                    //var tempPost = new { scanImage_dtls = "" };
                    //var post = JsonConvert.DeserializeAnonymousType(post_data, tempPost);
                    //string scandetails = post.scanImage_dtls;

                    //ObjGetImageRes = JsonConvert.DeserializeObject<ScanSaveImageFld_Model>(post_data);

                    //ObjGetImageRes = (ScanSaveImageFld_Model)JsonConvert.DeserializeObject(post_data, ObjGetImageRes.GetType());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ObjGetImageRes;
        }
    }
}
