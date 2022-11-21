using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
//aidi_vision使用的namespace
using aqrose.aidi_vision;
//AidiRunner和AidiParse使用的namespace
using aqrose.aidi_vision_client;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace FCM_Test
{
    public partial class Form1 : Form
    {
        private HObject ho_Image;
        private HObject ho_Image2;

        private RecordDisplay mRecordDisplay = null;
        private System.Timers.Timer tme = new System.Timers.Timer();
        private HObject img;
        private string[] ImagePath;
        AIDIRunner runner = new AIDIRunner("AUTH-ee8dfeef-bce6-4fef-bed8-88023ec6f86c");
        private int index;

        private HDevProcedure HDevProcedure;//Halcon 函数
        HDevEngine hDevEngine = new HDevEngine();//引擎
        //HDevProgram HDevProgram;//Halcon程序
        //HDevProgramCall HDevProgramCall;//Halcon程序执行实例
        string exePath = AppDomain.CurrentDomain.BaseDirectory + "HDEV\\";


        public Form1()
        {
            InitializeComponent();
            
            hDevEngine.SetProcedurePath(exePath);
            hDevEngine.StartDebugServer();          

        }

        /// <summary>打印log
        /// 
        /// </summary>

        public void UpdateLog(string log, Color color)
        {
            rtbLog.BeginInvoke(new Action(delegate
            {
                log = DateTime.Now.ToString("HH-mm-ss-fff") + " : " + log + "\n";
                rtbLog.AppendText(log);
                rtbLog.SelectionStart = rtbLog.TextLength - log.Length;
                rtbLog.SelectionLength = log.Length;
                rtbLog.SelectionColor = color;
                rtbLog.SelectionStart = rtbLog.TextLength - 1;
                rtbLog.SelectionLength = 0;
                rtbLog.ScrollToCaret();
                if (rtbLog.TextLength > 100000)
                {
                    rtbLog.Clear();
                }
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                HOperatorSet.GenEmptyObj(out ho_Image);
                mRecordDisplay = new RecordDisplay(hW);
                UpdateLog("软件启动!", Color.Red);
                ErrLog.WriteLogEx("软件启动!");
                InitTime();
                UpdateLog("外部函数库目录：" + exePath, Color.Green);
            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }

      

        private void InitTime()
        {

            tme.AutoReset = true;
            tme.Interval = 500;
            tme.Elapsed += Tme_Elapsed;
            tme.Enabled = true;
        }

        /// <summary>点击listview显示照片
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count == 0)
                    return;
                //采用索引方式 imagePathList记录图片真实路径
                index = this.listView1.SelectedItems[0].Index;
                //显示图片
                HOperatorSet.ReadImage(out ho_Image, ImagePath[index]);
                mRecordDisplay.Image = ho_Image.Clone();
                //ho_Image.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void Tme_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ElapsedEventHandler(Tme_Elapsed), sender, e);
                return;
            }
            try
            {
                tsslTime.Text = DateTime.Now.ToString("MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {


            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ho_Image.Dispose();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void hW_Resize(object sender, EventArgs e)
        {
            try
            {
                if (ho_Image != null)
                {
                    mRecordDisplay.Image = ho_Image;
                    mRecordDisplay.ZoomFit();
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Initialize local and output iconic variables 
            int count = 0;
            ho_Image.Dispose();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;   //是否允许多选
            dialog.Title = "请选择要处理的文件";  //窗口title
            dialog.Filter = "图片|*.jpg;*.png;*.jpeg;*.bmp";    //可选择的文件类型
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImagePath = dialog.FileNames;  //获取文件路径
                this.listView1.Items.Clear();
                imageList1.Images.Clear();

                //开始绑定
                this.listView1.BeginUpdate();


                foreach (var item in ImagePath)
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(item);
                    string keyName = Path.GetFileNameWithoutExtension(item);

                    imageList1.Images.Add(keyName, img);
                    // 
                    ListViewItem itemimage = new ListViewItem();
                    itemimage.ImageIndex = count;
                    itemimage.Text = keyName;


                    listView1.Items.Add(itemimage);
                    count++;
                }
                this.listView1.EndUpdate();
            }

        }

        private void 上一张_Click(object sender, EventArgs e)
        {
            if (mRecordDisplay.Image != null)
            {
                if (index > 0)
                {
                    index--;
                    listView1.SelectedItems.Clear();
                    listView1.Items[index].Selected = true;//设定选中            
                    listView1.Items[index].EnsureVisible();//保证可见
                    listView1.Items[index].Focused = true;
                    listView1.Select();
                    //显示图片
                    HOperatorSet.ReadImage(out ho_Image, ImagePath[index]);
                    mRecordDisplay.Image = ho_Image;
                    mRecordDisplay.ZoomFit();
                    //ho_Image.Dispose();
                }
                else if (index == 0)
                {
                    index = ImagePath.Length;
                    index--;
                    listView1.SelectedItems.Clear();
                    listView1.Items[index].Selected = true;//设定选中            
                    listView1.Items[index].EnsureVisible();//保证可见
                    listView1.Items[index].Focused = true;
                    listView1.Select();
                    //显示图片
                    HOperatorSet.ReadImage(out ho_Image, ImagePath[index]);
                    mRecordDisplay.Image = ho_Image;
                    //ho_Image.Dispose();
                }
            }
        }

        private void 下一张_Click(object sender, EventArgs e)
        {
            if (mRecordDisplay.Image != null)
            {
                if (index == ImagePath.Length - 1) //最后一张图片
                {
                    index = 0;
                    listView1.SelectedItems.Clear();
                    listView1.Items[index].Selected = true;//设定选中            
                    listView1.Items[index].EnsureVisible();//保证可见
                    listView1.Items[index].Focused = true;
                    listView1.Select();
                    //显示图片
                    HOperatorSet.ReadImage(out ho_Image, ImagePath[index]);
                    mRecordDisplay.Image = ho_Image;
                    mRecordDisplay.ZoomFit();
                    //ho_Image.Dispose();
                }
                else
                {
                    index++;
                    listView1.SelectedItems.Clear();
                    listView1.Items[index].Selected = true;//设定选中            
                    listView1.Items[index].EnsureVisible();//保证可见
                    listView1.Items[index].Focused = true;
                    listView1.Select();
                    //显示图片
                    HOperatorSet.ReadImage(out ho_Image, ImagePath[index]);
                    mRecordDisplay.Image = ho_Image;
                    //ho_Image.Dispose();
                }
            }
        }

        //private void 程序测试_Click(object sender, EventArgs e)
        //{
        //    //获取程序路径
        //    OpenFileDialog Program_path = new OpenFileDialog();
        //    //设定允许单选
        //    Program_path.Multiselect = false;
        //    //选择框限定文件类型
        //    Program_path.Filter = "hdev files(*.hdev)|*.hdev|All files(*.*)|*.*";
        //    //限定成功读取路径
        //    if (Program_path.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        //通过路径实例化程序
        //        HDevProgram Program = new HDevProgram(Program_path.FileName);
        //        //绑定程序到程序触发器
        //        HDevProgramCall = new HDevProgramCall(Program);
        //        //显示路径
        //        UpdateLog("程序路径：" + Program_path.FileName, Color.Green);
        //        //var Program1 = new HDevProcedure("CreateShapeModel1");
        //        //ProcCallC = new HDevProcedureCall(Program1);
        //        //开放执行控件

        //    }
        //}

        private void 运行_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ComboBox1.Text)
                {

                    case "FCMdamage":
                        HObject img1 = ho_Image;
                        FCMdamage(img1);
                        break;

                    case "FCMdeviation":
                        HObject img2 = ho_Image;
                        FCMdeviation(img2);

                        break;

                    case "HAF_L测试":

                        break;

                    default:
                        break;
                }


            }
            catch (Exception ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void FCMdeviation(HObject Image)
        {
            HDevProcedure = new HDevProcedure("FCMdeviation");//new一个Halcon外部函数的实例，参数为函数名
            HDevProcedureCall hDevProcedureCall = new HDevProcedureCall(HDevProcedure);//new一个函数执行的实例
            try
            {

                hDevProcedureCall.SetInputIconicParamObject("Image", Image);
                //hDevProcedureCall.SetInputCtrlParamTuple("num2", num2);
                hDevProcedureCall.Execute();//执行函数

                //执行程序
                //HDevProgramCall.Execute();
                //获取数据 只有执行后才能获取
                UpdateLog("检测结束", Color.Green);
                HTuple htp1 = hDevProcedureCall.GetOutputCtrlParamTuple("Angle");
               
                if (Image != null)
                {
                    mRecordDisplay.Image = Image;
                    UpdateLog(System.Math.Abs(htp1.DArr.Max()).ToString(),Color.Green);
                    UpdateLog(System.Math.Abs(htp1.DArr.Min()).ToString(), Color.Green);



                    if (System.Math.Abs(htp1.DArr.Max()) > 5.73||System.Math.Abs(htp1.DArr.Min()) > 5.73)
                    {
                        mRecordDisplay.Message("NG", Position.image, 200, 200, FontColor.red, false, "20");
                    }
                    else
                    {
                        mRecordDisplay.Message("OK", Position.image, 200, 200, FontColor.green, false, "20");
                    }
                }

            }
            catch (HDevEngineException Ex)
            {
                System.Windows.MessageBox.Show(Ex.Message, "HDevEngine Exception");

            }

        }

        private void AI加载_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ModelPath = new FolderBrowserDialog();
            //如果未成功获取
            if (ModelPath.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            else //绑定并显示 开放读取程序路径控件
            {
                //初始化模型
                bool InitBl = runner.InitModel(ModelPath.SelectedPath.Trim(), 0);
                //打印加载的结果
                UpdateLog("InitReturn" + InitBl.ToString(), Color.Green);
                //设定外部函数路径

            }
        }

        private void AI运行_Click(object sender, EventArgs e)
        {
            //读图
            Bitmap bmp = new Bitmap(ImagePath[index], false);//右线尾图
            //转成Byte[]
            aqrose.aidi_vision_client.ImageConverter converter = new aqrose.aidi_vision_client.ImageConverter();
            int stride, channel_num;
            byte[] transform_image = converter.bitmap_to_byte(ref bmp, out stride, out channel_num);
            //推理
            Bitmap bmp2 = new Bitmap(runner.Run_Draw_Bitmap(transform_image, bmp.Height, bmp.Width, channel_num));

            bmp2.Save("d:\\Image\\name.bmp");

            converter.Bitmap2HObjectBpp24(bmp2, out ho_Image2);
            mRecordDisplay.Image = ho_Image2;

            string result = runner.Run(transform_image, bmp.Height, bmp.Width, channel_num);
            UpdateLog("result:" + result, Color.Green);
            //解析result，转换成AidiResult类
            AIDIResult aidi_result = ResultParser.Parse(result);
            //计算aidi_result中检测出的每个区域的面积及其他信息的接口
            List<RegionInfo> region_info = ResultParser.AbstractRegionInfo(aidi_result);
            //打印面积计算的结果
            for (int z = 0; z < region_info.Count(); z++)
            {
                UpdateLog("第" + z.ToString() + "个区域的面积是：" + region_info[z].area, Color.Green);
            }
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
            
        }
        public void FCMdamage(HObject Image)
        {
            HDevProcedure = new HDevProcedure("FCMdamage");//new一个Halcon外部函数的实例，参数为函数名
            HDevProcedureCall hDevProcedureCall = new HDevProcedureCall(HDevProcedure);//new一个函数执行的实例
            try
            {

                hDevProcedureCall.SetInputIconicParamObject("Image", Image);
                //hDevProcedureCall.SetInputCtrlParamTuple("num2", num2);
                hDevProcedureCall.Execute();//执行函数

                //执行程序
                //HDevProgramCall.Execute();
                //获取数据 只有执行后才能获取
                UpdateLog("检测结束", Color.Green);
                HRegion hObject = hDevProcedureCall.GetOutputIconicParamRegion("EmptyObject");
                HImage img = hDevProcedureCall.GetOutputIconicParamImage("Imageout");
                //HImage img = HDevProgramCall.GetIconicVarImage("Image");
                //HRegion hObject= HDevProgramCall.GetIconicVarRegion("EmptyObject");
                if (img != null)
                {
                    mRecordDisplay.Image = img;
                    mRecordDisplay.DisplayRegion(hObject, FontColor.red);
                    if (hObject.Area.LArr.Max() > 0)
                    {
                        mRecordDisplay.Message("NG", Position.image, 300, 200, FontColor.red, false, "20");
                    }
                    else
                    {
                        mRecordDisplay.Message("OK", Position.image, 300, 200, FontColor.green, false, "20");
                    }
                }

            }
            catch (HDevEngineException Ex)
            {
                System.Windows.MessageBox.Show(Ex.Message, "HDevEngine Exception");
               
            }

        }
    }

}
