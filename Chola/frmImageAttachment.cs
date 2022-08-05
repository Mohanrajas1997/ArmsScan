using Chola.Chola_DL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Arms_Scan
{
    public partial class frmImageAttachment : Form
    {
        #region Initialization
        private string batch_num = string.Empty;
        private string check_Count = string.Empty;
        private string batch_amt = string.Empty;
        private string dep_slip_no = string.Empty;
        private string cust_name = string.Empty;
        private string scan_type = string.Empty;
        int uvCount = 0;
        private enum XportStates
        {
            TransportShutDown = 0,
            TransportStartingUp = 1,
            TransportChangeOptions = 2,
            TransportEnablingOptions = 3,
            TransportReadyToFeed = 4,
            TransportFeeding = 5,
            TransportExceptionInProgress = 6,
            TransportShuttingDown = 7
        };
        private enum FeedingStoppedReasons
        {
            FeedRequestFinished = 0,
            MainHopperEmpty = 1,
            MergeHopperEmpty = 2,
            ManualDropEmpty = 3,
            FeedStopRequested = 4,
            ClearTrackRequested = 5,
            BlackBandItemDetected = 6,
            EndOfLogicalMicrofilmRoll = 7,
            ExceptionDetected = 8
        };
        private enum IQATestIDs
        {
            IQATest_UndersizeImage = 1,
            IQATest_OversizeImage = 2,
            IQATest_BelowMinCompressedSize = 3,
            IQATest_AboveMaxCompressedSize = 4,
            IQATest_FrontRearDimensionMismatch = 5,
            IQATest_HorizontalStreaks = 6,
            IQATest_ImageTooLight = 7,
            IQATest_ImageTooDark = 8,
            IQATest_CarbonStrip = 9,
            IQATest_FramingError = 10,
            IQATest_ExcessiveSkew = 11,
            IQATest_TornEdges = 12,
            IQATest_TornCorners = 13,
            IQATest_SpotNoise = 14
        };
        private enum IQATestStatus
        {
            IQATestStatus_NotTested = 0,
            IQATestStatus_DefectPresent = 1,
            IQATestStatus_DefectNotPresent = 2
        };
        private enum IQAResults
        {
            IQAResult_TestResult = 1
        };
        private enum IQAResults_UndersizeImage : int
        {
            UndersizeImage_ImageWidth = 2,
            UndersizeImage_ImageHeight = 3
        };
        private enum IQAResults_OversizeImage
        {
            OversizeImage_ImageWidth = 2,
            OversizeImage_ImageHeight = 3
        };
        private enum IQAResults_BelowMinCompressedSize
        {
            BelowMinCompressedSize_CompressedImageSize = 2,
            BelowMinCompressedSize_ImageResolution = 3
        };
        private enum IQAResults_AboveMaxCompressedSize
        {
            AboveMaxCompressedSize_CompressedImageSize = 2,
            AboveMaxCompressedSize_ImageResolution = 3
        };
        private enum IQAResults_FrontRearDimensionMismatch
        {
            FrontRearDimensionMismatch_WidthDifference = 2,
            FrontRearDimensionMismatch_HeightDifference = 3
        };
        private enum IQAResults_HorizontalStreaks
        {
            HorizontalStreaks_StreakCount = 2,
            HorizontalStreaks_ThickestStreak = 3,
            HorizontalStreaks_ThickestStreakLocation = 4
        };
        private enum IQAResults_ImageTooLight
        {
            ImageTooLight_BitonalBlackPixelPercent = 2
        };
        private enum IQAResults_ImageTooDark
        {
            ImageTooDark_BitonalBlackPixelPercent = 2
        };
        private enum IQAResults_FramingError
        {
            FramingError_TopEdge = 2,
            FramingError_LeftEdge = 3,
            FramingError_BottomEdge = 4,
            FramingError_RightEdge = 5
        };
        private enum IQAResults_ExcessiveSkew
        {
            ExcessiveSkew_Angle = 2
        };
        private enum IQAResults_TornEdges
        {
            TornEdges_LeftTearWidth = 2,
            TornEdges_LeftTearHeight = 3,
            TornEdges_BottomTearWidth = 4,
            TornEdges_BottomTearHeight = 5,
            TornEdges_RightTearWidth = 6,
            TornEdges_RightTearHeight = 7,
            TornEdges_TopTearWidth = 8,
            TornEdges_TopTearHeight = 9
        };
        private enum IQAResults_TornCorners
        {
            TornCorners_TopLeftTearWidth = 2,
            TornCorners_TopLeftTearHeight = 3,
            TornCorners_BottomLeftTearWidth = 4,
            TornCorners_BottomLeftTearHeight = 5,
            TornCorners_TopRightTearWidth = 6,
            TornCorners_TopRightTearHeight = 7,
            TornCorners_BottomRightTearWidth = 8,
            TornCorners_BottomRightTearHeight = 9
        };
        private enum IQAResults_SpotNoise
        {
            SpotNoise_AverageSpotNoiseCount = 2
        };
        private enum Sides
        {
            TransportFront = 0,
            TransportRear = 1,
        };
        private enum ImageColorTypes
        {
            ImageColorTypeUnknown = -1,
            ImageColorTypeBitonal = 0,
            ImageColorTypeGrayscale = 1,
            ImageColorTypeColor = 2
        };
        string exePath = string.Empty;
        string root = string.Empty;
        int count = 0;
        int i = 0;
        static string base64String = "";
        #endregion


        #region variables
        MySqlConnection con;

        DataTable dtScan = new DataTable();
        DataRow drScan;
        DataGridViewButtonColumn dgvBtnCol;

        int scan_slno = 0;
        string reader_txt;
        string[] reader_split;
        string micr_code;
        string chq_no;
        string base_code;
        string tran_code;
        List<string> tran_code_list;
        int batchid = 0;
        int PacketGid = 0;
        int ReScanCount = 0;

        int sizeImg;
        byte[] mybytesImg;
        IntPtr ptrImg;
        Bitmap bitImg;
        System.IO.MemoryStream streamBmpImg;
        string branch_code;
        string chq_type;


        int GCSCANRESCAN = 16;
        #endregion


        public frmImageAttachment()
        {
            InitializeComponent();
            con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            con.Open();
        }

        private void LoadRescan(int PacketGid)
        {
            try
            {
                ReScanCount = 0;
                dgvReScan.Columns.Clear();
                DataTable dtscanning = new DataTable();
                dgvReScan.DataSource = null;
                PacketBusiness ObjInward = new PacketBusiness();
                dtscanning = ObjInward.GetRescanningList(PacketGid);
                dgvReScan.DataSource = dtscanning;

                if (dgvReScan.Columns["scan_gid"] != null)
                {
                    dgvReScan.Columns["scan_packet_gid"].Visible = false;
                    dgvReScan.Columns["scan_gid"].Visible = false;

                }
                if (dgvReScan.Rows.Count > 0)
                {

                    ReScanCount = dgvReScan.Rows.Count;

                    rdoReScanning.Checked = true;
                    rdoNewScanning.Checked = false;
                    dgvReScan.Visible = true;

                }
                dgvReScan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPackId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPackId.Text != "") PacketGid = Convert.ToInt32(txtPackId.Text);
                if (PacketGid == 0)
                {
                    MessageBox.Show("Please Enter Packet Id !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPackId.Focus();
                    return;
                }

                DataTable dtscanning = new DataTable();
                PacketBusiness ObjInward = new PacketBusiness();
                dtscanning = ObjInward.GetPacketSinglefetch(PacketGid);

                if (dtscanning.Rows.Count == 0)
                {
                    MessageBox.Show("There is no record !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPackId.Focus();
                    return;

                }
                else
                {
                    //Packet Details Data Bind

                    txtGnsaRefNo.Text = dtscanning.Rows[0]["Cover No"].ToString();
                    txtLotNo.Text = dtscanning.Rows[0]["Lot No"].ToString();
                    txtContractNo.Text = dtscanning.Rows[0]["Contract No"].ToString();
                    PacketRecv_Date.Text = dtscanning.Rows[0]["Packet Received Date"].ToString();
                    txtRemarks.Text = dtscanning.Rows[0]["Packet Remarks"].ToString();
                    txtEntityName.Text = dtscanning.Rows[0]["Entity Name"].ToString();
                    //LoadRescan(PacketGid);

                    LoadRescan(PacketGid);

                    btnSave.Enabled = true;
                    btnScan.Enabled = true;

                    //Cheque Tab Details Data Bind

                    DataTable dtChq = new DataTable();
                    PacketBusiness ObjChq = new PacketBusiness();
                    dtChq = ObjChq.GetChequeDetails(PacketGid);
                    gvmChkrEntry.DataSource = dtChq;

                    btnStartRanger.Enabled = true;
                    btnStartRanger.Focus();
                }
            }

        }

        private void frmImageAttachment_Load(object sender, EventArgs e)
        {
            try
            {
                btnStartRanger.Enabled = false;

                //InwardBusiness obj = new InwardBusiness();
                // tran_code_list = obj.TranCodeList();

                // data table column structuring
                //rdoNewScanning.Checked = true;
                // dgvReScan.Visible = false;
                KeyPreview = true;
                DataColumn dc;

                dc = new DataColumn();

                dc.ColumnName = "S No";
                dc.DataType = System.Type.GetType("System.Int16");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Chq No";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Micr Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Tran Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Base Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "reader_txt";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bw_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bw_rear_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "gray_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "uv_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);



                dc = new DataColumn();
                dc.ColumnName = "bw_front_image_str";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bw_rear_image_str";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "gray_front_image_str";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "uv_front_image_str";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region RangerEvents
        private void axRanger1_TransportChangeOptionsState(object sender, AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEvent e)
        {
            if (e.previousState == (int)XportStates.TransportStartingUp)
            {
                axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "True");
                axRanger1.EnableOptions();
            }
        }

        private void axRanger1_TransportNewState(object sender, AxRANGERLib._DRangerEvents_TransportNewStateEvent e)
        {
            try
            {
                if (e.currentState == (int)XportStates.TransportChangeOptions)
                {
                    string txt = "";
                }
                else if (e.currentState == (int)XportStates.TransportReadyToFeed)
                {
                    btnScan.Enabled = true;
                    btnShutdown.Enabled = true;
                }
                else if (e.currentState == (int)XportStates.TransportShutDown)
                {
                    btnScan.Enabled = false;
                    btnShutdown.Enabled = false;
                    btnStartRanger.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axRanger1_TransportFeedingStopped(object sender, AxRANGERLib._DRangerEvents_TransportFeedingStoppedEvent e)
        {
            try
            {
                if (e.reason == (int)FeedingStoppedReasons.MainHopperEmpty)
                {
                    MessageBox.Show("Feeder is Empty");
                }
                else if (e.reason == (int)FeedingStoppedReasons.ExceptionDetected)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void axRanger1_TransportNewItem(object sender, System.EventArgs e)
        {
            try
            {
                int ItemID = axRanger1.GetItemID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axRanger1_TransportSetItemOutput(object sender, AxRANGERLib._DRangerEvents_TransportSetItemOutputEvent e)
        {
            axRanger1.SetTargetLogicalPocket(1);
        }

        private void axRanger1_TransportItemInPocket(object sender, AxRANGERLib._DRangerEvents_TransportItemInPocketEvent e)
        {
            try
            {
                string txt1 = "", txt2 = "", txt3 = "";

                reader_txt = axRanger1.GetMicrText(1);

                scan_slno += 1;

                drScan = dtScan.NewRow();

                drScan["S No"] = scan_slno;
                drScan["reader_txt"] = reader_txt;

                reader_txt = reader_txt.Replace("c", "");
                reader_txt = reader_txt.Replace("d", "");
                reader_txt = reader_txt.Replace("!", "");
                reader_txt = reader_txt.Replace("-", "");
                reader_txt = reader_txt.Replace("  ", " ");

                reader_txt = reader_txt.Trim();
                reader_split = reader_txt.Split(new String[] { " " }, StringSplitOptions.None);


                if (reader_split.Length == 3)
                {
                    drScan["Chq No"] = reader_split[0];
                    drScan["Micr Code"] = reader_split[1];
                    drScan["Tran Code"] = reader_split[2];
                }
                else if (reader_split.Length == 4)
                {
                    drScan["Chq No"] = reader_split[0];
                    drScan["Micr Code"] = reader_split[1];
                    drScan["Tran Code"] = reader_split[3];
                    drScan["Base Code"] = reader_split[2];
                }
                else if (reader_split.Length > 4)
                {
                    drScan["Chq No"] = reader_split[0];
                    drScan["Micr Code"] = reader_split[1];

                    for (int i = 2; i < reader_split.Length; i++)
                    {
                        if (reader_split[i].Length == 6) drScan["Base Code"] = reader_split[i];
                        if (reader_split[i].Length == 2) drScan["Tran Code"] = reader_split[i];
                    }
                }

                if (drScan["Chq No"].ToString().Length == 15)
                {
                    txt1 = drScan["Chq No"].ToString();
                    txt2 = drScan["Micr Code"].ToString();
                    txt3 = drScan["Base Code"].ToString();

                    drScan["Chq No"] = txt1.Substring(0, 6);
                    drScan["Micr Code"] = txt1.Substring(6, 9);

                    if (txt2.Length == 8)
                    {
                        drScan["Base Code"] = txt2.Substring(0, 6);
                        drScan["Tran Code"] = txt2.Substring(6, 2);
                    }

                    if (txt2.Length == 6)
                    {
                        drScan["Base Code"] = txt2;
                    }

                    if (txt3.Length == 2)
                    {
                        drScan["Tran Code"] = txt3;
                    }
                }

                if (drScan["Micr Code"].ToString().Length == 15)
                {
                    txt2 = drScan["Micr Code"].ToString();
                    txt3 = drScan["Tran Code"].ToString();

                    drScan["Micr Code"] = txt2.Substring(0, 9);
                    drScan["Base Code"] = txt2.Substring(9, 6);

                    if (txt3.Length == 2)
                    {
                        drScan["Tran Code"] = txt3;
                    }
                }

                // bw front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal));
                //Copy the bytes from nmanaged memory to managed memory
                System.Runtime.InteropServices.Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;
                drScan["bw_front_image_str"] = Convert.ToBase64String(mybytesImg);
                drScan["bw_front_image"] = mybytesImg;

                // bw rear
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal));
                //Copy the bytes from nmanaged memory to managed memory
                System.Runtime.InteropServices.Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;
                drScan["bw_rear_image_str"] = Convert.ToBase64String(mybytesImg);
                drScan["bw_rear_image"] = mybytesImg;

                // gray front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeGrayscale);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeGrayscale));
                //Copy the bytes from nmanaged memory to managed memory
                System.Runtime.InteropServices.Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;
                drScan["gray_front_image_str"] = Convert.ToBase64String(mybytesImg);
                drScan["gray_front_image"] = mybytesImg;

                // uv front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, 4);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, 4));
                //Copy the bytes from nmanaged memory to managed memory
                System.Runtime.InteropServices.Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                drScan["uv_front_image_str"] = Convert.ToBase64String(mybytesImg);
                drScan["uv_front_image"] = mybytesImg;

                dtScan.Rows.Add(drScan);

                dgvScan.DataSource = dtScan;
                dgvScan.FirstDisplayedScrollingRowIndex = dgvScan.Rows.Count - 1;


                if (dgvScan.Columns["S No"] != null)
                {
                    dgvScan.Columns["reader_txt"].Visible = false;
                    dgvScan.Columns["bw_front_image_str"].Visible = false;
                    dgvScan.Columns["bw_front_image"].Visible = false;
                    dgvScan.Columns["bw_rear_image_str"].Visible = false;
                    dgvScan.Columns["bw_rear_image"].Visible = false;
                    dgvScan.Columns["gray_front_image_str"].Visible = false;
                    dgvScan.Columns["gray_front_image"].Visible = false;
                    dgvScan.Columns["uv_front_image_str"].Visible = false;
                    dgvScan.Columns["uv_front_image"].Visible = false;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void disp_image()
        {
            string fld_image = "";

            if (lblScanSerialNo.Tag.ToString() == "") return;

            if (rdoBW.Checked)
            {
                if (rdoFront.Checked)
                {
                    fld_image = "bw_front_image";
                }
                else
                {
                    fld_image = "bw_rear_image";
                }
            }
            else if (rdoGray.Checked)
            {
                fld_image = "gray_front_image";
            }
            else
            {
                fld_image = "uv_front_image";
            }

            streamBmpImg = new MemoryStream((byte[])dtScan.Rows[Convert.ToInt16(lblScanSerialNo.Tag) - 1][fld_image]);
            bitImg = new Bitmap(Image.FromStream(streamBmpImg));
            //assign that bitmap object to the picture box
            picChq.Image = bitImg;

        }

        private void ImageAttachment_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                pnlBatch.Width = pnlButton.Width;

                TabChqDetails.Top = pnlBatch.Top;
                TabChqDetails.Left = pnlBatch.Left + pnlBatch.Width + 8;
                TabChqDetails.Height = pnlBatch.Height + pnlButton.Height;
                TabChqDetails.Width = this.Width - (pnlBatch.Left + pnlBatch.Width + 32);

                dgvScan.Left = 0;
                dgvScan.Width = TabChqDetails.Width;
                dgvScan.Height = TabChqDetails.Height - dgvScan.Top;

                dgvReScan.Left = dgvScan.Left;
                dgvReScan.Width = dgvScan.Width;
                dgvReScan.Height = dgvScan.Height;

                picChq.Top = (pnlButton.Top + pnlButton.Height) + 8;
                picChq.Left = 8;
                picChq.Height = this.Height - (pnlButton.Top + pnlButton.Height) - 56;
                picChq.Width = this.Width - 32;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartRanger_Click(object sender, EventArgs e)
        {
            try
            {
                axRanger1.StartUp();
                dgvScan.Rows.Clear();
                dgvScan.Columns.Clear();
                btnStartRanger.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            axRanger1.ShutDown();

            btnShutdown.Enabled = false;
            btnStartRanger.Enabled = true;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                int FeedSourceMainHopper = 0,
                    FeedContinuously = 0;
                //Request that the transport feed continuously from the main hopper.
                //Other possible feed sources are:
                //   + FeedSourceMergeHopper
                //   + FeedSourceManualDrop

                //axRanger1.StartFeeding() can be used to feed a single item or continously.

                //Ranger will transition to the "TransportFeeding" state before StartFeeding() returns.
                //Document cycle events will be fired after an item has been fed.
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
                if (rdoReScanning.Checked == true)
                {
                    rdoNewScanning.Checked = true;
                }
                //axRanger1.ShutDown();
                //enable stop feeding button
                //if (dgvScan.Rows.Count > 0)
                //{
                //    MessageBox.Show("Total " + dgvScan.Rows.Count + " Cheque Scanned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClrScan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear scan ?", "Clear Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtScan.Rows.Clear();
                scan_slno = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblScanSerialNo.Tag == "")
            {
                MessageBox.Show("Please select the cheque !", "Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(lblScanSerialNo.Tag.ToString()) > dgvScan.Rows.Count)
            {
                MessageBox.Show("Invalid cheque !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBaseCode.Text = "";
                txtChqNo.Text = "";
                txtMicrCode.Text = "";
                txtTranCode.Text = "";

                return;
            }

            if (txtChqNo.Text == "")
            {
                MessageBox.Show("Cheque no cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChqNo.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{6}$").IsMatch(txtChqNo.Text)))
            {
                MessageBox.Show("Invalid cheque no !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChqNo.Focus();
                return;
            }

            if (txtMicrCode.Text == "")
            {
                MessageBox.Show("Micr code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMicrCode.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{9}$").IsMatch(txtMicrCode.Text)))
            {
                MessageBox.Show("Invalid micr code !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMicrCode.Focus();
                return;
            }

            if (txtTranCode.Text == "")
            {
                MessageBox.Show("Tran code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTranCode.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{2}$").IsMatch(txtTranCode.Text)))
            {
                MessageBox.Show("Invalid tran code !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTranCode.Focus();
                return;
            }

            if (txtBaseCode.Text != "")
            {
                if (txtBaseCode.Text.All(char.IsDigit) == false)
                {
                    MessageBox.Show("Base code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaseCode.Focus();
                    return;
                }
            }

            if (MessageBox.Show("Are you sure to update cheque details ?", "Update Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int i = Convert.ToInt16(lblScanSerialNo.Tag) - 1;

                dtScan.Rows[i]["Micr Code"] = txtMicrCode.Text;
                dtScan.Rows[i]["Chq No"] = txtChqNo.Text;
                dtScan.Rows[i]["Tran Code"] = txtTranCode.Text;
                dtScan.Rows[i]["Base Code"] = txtBaseCode.Text;

                dgvScan.Refresh();

                clear_cheque();

                MessageBox.Show("Updated successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvScan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 /*&& e.ColumnIndex == 0*/)
            {
                lblScanSerialNo.Tag = dgvScan.Rows[e.RowIndex].Cells["S No"].Value.ToString();
                lblScanSerialNo.Text = "Scan Serial No : " + dgvScan.Rows[e.RowIndex].Cells["S No"].Value.ToString();
                txtBaseCode.Text = dgvScan.Rows[e.RowIndex].Cells["Base Code"].Value.ToString();
                txtChqNo.Text = dgvScan.Rows[e.RowIndex].Cells["Chq No"].Value.ToString();
                txtMicrCode.Text = dgvScan.Rows[e.RowIndex].Cells["Micr Code"].Value.ToString();
                txtTranCode.Text = dgvScan.Rows[e.RowIndex].Cells["Tran Code"].Value.ToString();

                disp_image();

                btnUpdate.Enabled = true;
                btnClear.Enabled = true;
            }
        }

        private void clear_cheque()
        {
            lblScanSerialNo.Tag = "";
            lblScanSerialNo.Text = "";
            txtBaseCode.Text = "";
            txtChqNo.Text = "";
            txtMicrCode.Text = "";
            txtTranCode.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblScanSerialNo.Tag != "")
            {
                if (MessageBox.Show("Are you sure to clear cheque details ?", "Clear Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    clear_cheque();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            bool valid_flag;
            string txt;
            int i;
            int chq_gid;
            int scan_gid;
            int result;
            string msg;

            bool disc_flag = false;
            string disc_txt = "";
            PacketBusiness ObjPacketBusiness = new PacketBusiness();
            MySqlCommand cmd;
            try
            {
                if (txtGnsaRefNo.Text == "")
                {
                    MessageBox.Show("Cover No is Empty!", "Rescanning list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGnsaRefNo.Focus();
                    return;
                }
                if (ReScanCount > 0)
                {
                    if (dtScan.Rows.Count < ReScanCount)
                    {
                        MessageBox.Show("Scan cheque count lesser then Rescan count !", "Rescanning list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (dtScan.Rows.Count > ReScanCount)
                    {
                        if (MessageBox.Show("Scan Cheque Count Greater then Rescan count, Are you sure to process?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            string[] results = ObjPacketBusiness.UpdateScanReimage(PacketGid);
                        }
                    }
                    else if (dtScan.Rows.Count == ReScanCount)
                    {
                        string[] results = ObjPacketBusiness.UpdateScanReimage(PacketGid);
                    }
                }
                for (i = 0; i < dtScan.Rows.Count; i++)
                {
                    txt = "Rows No : " + (i + 1).ToString() + ",";
                    valid_flag = true;
                    if (dtScan.Rows[i]["reader_txt"].ToString() != "")
                    {


                        if (dtScan.Rows[i]["Chq No"].ToString() == "" ||
                            dtScan.Rows[i]["Chq No"].ToString().Length != 6 ||
                            dtScan.Rows[i]["Chq No"].ToString() == "000000")
                        {
                            valid_flag = false;

                            if (dtScan.Rows[i]["Chq No"].ToString() == "")
                            {
                                txt += "Blank Chq No,";
                            }
                            else
                            {
                                txt += "Invalid Chq No:" + dtScan.Rows[i]["Chq No"].ToString() + ",";
                            }
                        }


                        if (dtScan.Rows[i]["Micr Code"].ToString() == "" ||
                            dtScan.Rows[i]["Micr Code"].ToString().Length != 9 ||
                            dtScan.Rows[i]["Micr Code"].ToString() == "000000000")
                        {
                            valid_flag = false;

                            if (dtScan.Rows[i]["Micr Code"].ToString() == "")
                            {
                                txt += "Blank Micr Code,";
                            }
                            else
                            {
                                txt += "Invalid Micr Code:" + dtScan.Rows[i]["Micr Code"].ToString() + ",";
                            }
                        }

                        if (dtScan.Rows[i]["Base Code"].ToString() != "")
                        {
                            if (!dtScan.Rows[i]["Base Code"].ToString().All(char.IsDigit) ||
                                dtScan.Rows[i]["Base Code"].ToString().Length != 6 || dtScan.Rows[i]["Base Code"].ToString() == "000000")
                            {
                                txt += "Invalid Base Code:" + dtScan.Rows[i]["Base Code"].ToString() + ",";
                            }
                        }

                        // bool tran_result = tran_code_list.Any(s => s == dtScan.Rows[i]["Tran Code"].ToString());

                        if (dtScan.Rows[i]["Tran Code"].ToString() == "")
                        {
                            valid_flag = false;

                            if (dtScan.Rows[i]["Tran Code"].ToString() == "")
                            {
                                txt += "Blank Tran Code,";
                            }
                            else
                            {
                                txt += "Invalid Tran Code:" + dtScan.Rows[i]["Tran Code"].ToString() + ",";
                            }
                        }
                    }
                    if (!valid_flag)
                    {
                        disc_flag = true;
                        disc_txt += txt + "\n";
                    }
                }

                if (disc_flag)
                {
                    MessageBox.Show(disc_txt, "Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(disc_txt);
                    if (MessageBox.Show("Is Captured informations are correct ?", "Discrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                if (MessageBox.Show("Are you sure to complete the scan batch ?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (dtScan.Rows.Count == 0)
                {
                    MessageBox.Show("Scan cheque not available !", "Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (Convert.ToInt16(txtStatus.Text) != dtScan.Rows.Count)
                //{
                //    if (MessageBox.Show("Scanned cheque count not tallied with batch cheque count ! Are you sure to close the batch ?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                //    {
                //        return;
                //    }
                //}

                // axRanger1.ShutDown();
                btnSave.Enabled = false;

                ScanResponse ObjScanRsp = new ScanResponse();
                for (i = 0; i < dtScan.Rows.Count; i++)
                {


                    Scan_Model ObjScanHdr = new Scan_Model();
                    ScanBusiness ObjScanBusiness = new ScanBusiness();

                    ObjScanHdr.scan_gid = 0;
                    ObjScanHdr.scan_packet_gid = PacketGid;
                    ObjScanHdr.scan_reader_text = dtScan.Rows[i]["reader_txt"].ToString();
                    ObjScanHdr.scan_chq_no = dtScan.Rows[i]["Chq No"].ToString();
                    ObjScanHdr.scan_micr_code = dtScan.Rows[i]["Micr Code"].ToString();
                    ObjScanHdr.scan_tran_code = dtScan.Rows[i]["Tran Code"].ToString();
                    ObjScanHdr.scan_base_code = dtScan.Rows[i]["Base Code"].ToString();
                    ObjScanHdr.scan_chq_type = "";
                    ObjScanHdr.scan_chq_gid = 0;
                    ObjScanHdr.scan_remarks = "";

                    ObjScanRsp = ObjScanBusiness.SaveScanHeader(ObjScanHdr);
                    CholaMasterBusiness.ScanHeaderGid = ObjScanRsp.Out_scan_gid.ToString();
                    if (ObjScanRsp.Out_result == 1)
                    {
                        // front bw                  

                        ScanResponse ObjImageRes = new ScanResponse();
                        ScanImage_Model ObjImageReq = new ScanImage_Model();

                        ObjImageReq.scanimage_gid = 0;
                        ObjImageReq.scamimage_scan_gid = ObjScanRsp.Out_scan_gid;
                        ObjImageReq.scanimage_type = "B";
                        ObjImageReq.scanimage_side = "F";

                        ObjImageRes = ObjScanBusiness.SaveScanImage(ObjImageReq);

                        if (ObjImageRes.Out_result == 1)
                        {
                            ScanSaveImageFld_Model ObjImageFldRes = new ScanSaveImageFld_Model();
                            ObjImageFldRes.scanimage_gid = ObjImageRes.Out_scanimage_gid;
                            ObjImageFldRes.scanImage_dtls = dtScan.Rows[i]["bw_front_image_str"].ToString();
                            ObjImageFldRes = ObjScanBusiness.SaveImageFld(ObjImageFldRes);
                        }

                        // rear bw                   

                        ObjImageReq.scanimage_gid = 0;
                        ObjImageReq.scamimage_scan_gid = ObjScanRsp.Out_scan_gid;
                        ObjImageReq.scanimage_type = "B";
                        ObjImageReq.scanimage_side = "R";

                        ObjImageRes = ObjScanBusiness.SaveScanImage(ObjImageReq);
                        if (ObjImageRes.Out_result == 1)
                        {
                            ScanSaveImageFld_Model ObjImageFldRes = new ScanSaveImageFld_Model();
                            ObjImageFldRes.scanimage_gid = ObjImageRes.Out_scanimage_gid;
                            ObjImageFldRes.scanImage_dtls = dtScan.Rows[i]["bw_rear_image_str"].ToString();
                            ObjImageFldRes = ObjScanBusiness.SaveImageFld(ObjImageFldRes);
                        }

                        // front gray

                        ObjImageReq.scanimage_gid = 0;
                        ObjImageReq.scamimage_scan_gid = ObjScanRsp.Out_scan_gid;
                        ObjImageReq.scanimage_type = "G";
                        ObjImageReq.scanimage_side = "F";
                        ObjImageRes = ObjScanBusiness.SaveScanImage(ObjImageReq);
                        if (ObjImageRes.Out_result == 1)
                        {
                            ScanSaveImageFld_Model ObjImageFldRes = new ScanSaveImageFld_Model();
                            ObjImageFldRes.scanimage_gid = ObjImageRes.Out_scanimage_gid;
                            ObjImageFldRes.scanImage_dtls = dtScan.Rows[i]["gray_front_image_str"].ToString();
                            ObjImageFldRes = ObjScanBusiness.SaveImageFld(ObjImageFldRes);
                        }

                        // uv gray                   

                        ObjImageReq.scanimage_gid = 0;
                        ObjImageReq.scamimage_scan_gid = ObjScanRsp.Out_scan_gid;
                        ObjImageReq.scanimage_type = "U";
                        ObjImageReq.scanimage_side = "F";
                        ObjImageRes = ObjScanBusiness.SaveScanImage(ObjImageReq);
                        if (ObjImageRes.Out_result == 1)
                        {
                            ScanSaveImageFld_Model ObjImageFldRes = new ScanSaveImageFld_Model();
                            ObjImageFldRes.scanimage_gid = ObjImageRes.Out_scanimage_gid;
                            ObjImageFldRes.scanImage_dtls = dtScan.Rows[i]["uv_front_image_str"].ToString();
                            ObjImageFldRes = ObjScanBusiness.SaveImageFld(ObjImageFldRes);
                        }

                    }
                }

                if (ObjScanRsp.Out_result == 1)
                {
                    // axRanger1.Dispose();
                    dtScan.Dispose();

                    MessageBox.Show("Scan completed !", "Scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                    clear_cheque();
                    txtGnsaRefNo.Text = "";
                    txtLotNo.Text = "";
                    txtContractNo.Text = "";
                    txtEntityName.Text = "";
                    txtRemarks.Text = "";
                    txtGnsaRefNo.Focus();
                    btnScan.Enabled = true;
                    btnShutdown.Enabled = true;
                    dtScan.Rows.Clear();
                    scan_slno = 0;
                    PacketGid = 0;
                }
                else
                {
                    MessageBox.Show(ObjScanRsp.Out_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //btnShutdown.Enabled = false;
                btnStartRanger.Enabled = true;
                btnSave.Enabled = false;
                btnScan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                axRanger1.ShutDown();

                axRanger1.Dispose();
                dtScan.Dispose();

                this.Close();
            }
        }

        private void rdoFront_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoRear_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoBW_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoGray_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoUV_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void txtChqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtMicrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtTranCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtBaseCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ImageAttachment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                axRanger1.ShutDown();

                axRanger1.Dispose();
                dtScan.Dispose();

                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void rdoReScanning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReScanning.Checked == true)
            {
                dgvScan.Visible = false;
                dgvReScan.Visible = true;
                LoadRescan(PacketGid);
            }
        }

        private void rdoNewScanning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewScanning.Checked == true)
            {
                dgvScan.Visible = true;
                dgvReScan.Visible = false;
            }
        }

        private void dgvReScan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ScanImagegid = 0;
            DataTable dtscanGid = new DataTable();
            ScanBusiness ObjImageBusiness = new ScanBusiness();
            if (e.RowIndex >= 0 /*&& e.ColumnIndex == 0*/)
            {
                ScanImagegid = Convert.ToInt32(dgvReScan.Rows[e.RowIndex].Cells["scan_gid"].Value.ToString());
                PacketBusiness ObjInward = new PacketBusiness();
                dtscanGid = ObjInward.GetScanImageGid(ScanImagegid);

                ScanSaveImageFld_Model ObjScanImagedtls = new ScanSaveImageFld_Model();
                if (dtscanGid.Rows.Count > 0)
                {
                    ObjScanImagedtls.scanimage_gid = Convert.ToInt32(dtscanGid.Rows[0]["scanimage_gid"].ToString());
                    ObjScanImagedtls.scanImage_dtls = "";
                    ObjScanImagedtls = ObjImageBusiness.GetScanImage(ObjScanImagedtls);
                    if (ObjScanImagedtls.scanImage_dtls == "" || ObjScanImagedtls.scanImage_dtls == null)
                    {
                        picChq.Image = null;
                        MessageBox.Show("Re Scan Image not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        byte[] byteBuffer = Convert.FromBase64String(ObjScanImagedtls.scanImage_dtls);
                        streamBmpImg = new MemoryStream(byteBuffer);
                        bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                        //assign that bitmap object to the picture box
                        picChq.Image = bitImg;
                    }

                }
                else
                {
                    picChq.Image = null;
                }


            }
        }

        private void txtGnsaRefNo_Leave(object sender, EventArgs e)
        {
            DataTable dtscanning = new DataTable();

            PacketBusiness ObjInward = new PacketBusiness();
            string GnsaRefno = txtGnsaRefNo.Text.ToString();
            dtscanning = ObjInward.GetPacketSingleDetails(GnsaRefno);
            if (dtscanning.Rows.Count > 0)
            {
                PacketGid = Convert.ToInt32(dtscanning.Rows[0]["Packet Gid"]);
                PacketRecv_Date.Text = dtscanning.Rows[0]["Packet Received Date"].ToString();
                txtGnsaRefNo.Text = dtscanning.Rows[0]["Cover No"].ToString();
                txtLotNo.Text = dtscanning.Rows[0]["Lot No"].ToString();
                txtContractNo.Text = dtscanning.Rows[0]["Contract No"].ToString();
                txtEntityName.Text = dtscanning.Rows[0]["Entity Name"].ToString();
                txtRemarks.Text = dtscanning.Rows[0]["Packet Remarks"].ToString();
                LoadRescan(PacketGid);

                btnSave.Enabled = true;
                btnScan.Enabled = true;

                btnScan.Focus();
            }
            else
            {
                if (txtGnsaRefNo.Text != "")
                {
                    MessageBox.Show("Invalid Packet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void frmImageAttachment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtPackId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
    }
}
