using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using System.IO;
using Emgu.CV.Cvb;
using Emgu.CV.CvEnum;

namespace svmpractice
{
    public partial class Form1 : Form
    {
        CascadeClassifier face;
        Matrix<float> TrainData;
        Matrix<float> TestData;
        Matrix<int> TrainLabel;
        Matrix<int> TestLabel;
        VideoCapture _cameraCapture;
        CvTracks _tracker;
        SVM svm;
        int Counter = 0;
        int imagetrainsize = 50;
        bool IsDisplayImage = false;
        string transformstr;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadTrainData(string folderpath)
        {
            List<float[]> trainList = new List<float[]>();
            List<int> trainLabel = new List<int>();

            StreamReader reader = new StreamReader(folderpath + @"\train.txt");

            string line = "";
            if (!File.Exists(folderpath + @"\train.txt"))
            {
                throw new Exception("File Not found");
            }

            while ((line = reader.ReadLine()) != null)
            {
                int firstIndex = line.IndexOf(',');
                int currentLabel = Convert.ToInt32(line.Substring(0, firstIndex));
                string currentData = line.Substring(firstIndex + 1);

                float[] data = currentData.Split(',').Select(x => float.Parse(x)).ToArray();

                trainList.Add(data);
                trainLabel.Add(currentLabel);

            }

            TrainData = new Matrix<float>(To2D<float>(trainList.ToArray()));
            TrainLabel = new Matrix<int>(trainLabel.ToArray());
        }

        private void LoadTestData(string folderpath)
        {
            List<float[]> trainList = new List<float[]>();
            List<int> trainLabel = new List<int>();

            StreamReader reader = new StreamReader(folderpath + @"\test.txt");

            string line = "";
            if (!File.Exists(folderpath + @"\test.txt"))
            {
                throw new Exception("File Not found");
            }

            while ((line = reader.ReadLine()) != null)
            {
                int firstIndex = line.IndexOf(',');
                int currentLabel = Convert.ToInt32(line.Substring(0, firstIndex));
                //  string currentData = line.Substring(firstIndex + 1);
                //  float[] data = currentData.Split(',').Select(x => float.Parse(x)).ToArray();

                float[] data = line.Split(',').Select(x => float.Parse(x)).ToArray();

                trainList.Add(data);
                trainLabel.Add(currentLabel);

            }

            TestData = new Matrix<float>(To2D<float>(trainList.ToArray()));
            TestLabel = new Matrix<int>(trainLabel.ToArray());

        }

        private void trainSVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("svm.txt"))
                {
                    svm = new SVM();
                    FileStorage file = new FileStorage("svm.txt", FileStorage.Mode.Read);
                    svm.Read(file.GetNode("opencv_ml_svm"));
                }
                else
                {
                    svm = new SVM();
                    svm.C = 100;
                    svm.Type = SVM.SvmType.CSvc;
                    svm.Gamma = 0.005;
                    svm.SetKernel(SVM.SvmKernelType.Linear);
                    svm.TermCriteria = new MCvTermCriteria(1000, 1e-6);
                    svm.Train(TrainData, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, TrainLabel);
                    svm.Save("svm.txt");
                }
                MessageBox.Show("SVM is trained.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void testSVMToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (TestData == null)
            {
                return;
            }

            if (File.Exists("svm.txt"))
            {
                svm = new SVM();
                FileStorage file = new FileStorage("svm.txt", FileStorage.Mode.Read);
                svm.Read(file.GetNode("opencv_ml_svm"));
            }

            if (svm == null)
            {
                return;
            }
            try
            {
                int counter = 0;
                for (int i = 0; i < TestData.Rows; i++)
                {
                    Matrix<float> row = TestData.GetRow(i);
                    float predict = svm.Predict(row); //predict 即是預測class
                    lblTest.Text = "Input Label:  " + TestLabel[i, 0].ToString(); //test label顯示現在到第幾張
                    lblOouputLabel.Text = "Predicted Label:  " + predict.ToString();
                    if (predict == TestLabel[i, 0])
                    {
                        counter += 1;
                    }

                    if (IsDisplayImage == true)
                    {
                        Image<Gray, byte> imgout = TestData.GetRow(Counter).Mat.Reshape(0, imagetrainsize).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                        pictureBox1.Image = imgout.Bitmap;
                        await Task.Delay(1000);
                    }
                    else
                    {
                        await Task.Delay(1);
                    }
                }

                lblAccuracy.Text = "Accuracy = " + (counter / (float)(TestData.Rows));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainData(folder.SelectedPath);
                    //  LoadTestData(folder.SelectedPath);
                }

                MessageBox.Show("Data loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tansformToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //「提示性文字」, 「對話方塊標題」, 「預設值」, X座標, Y座標
            string classno = Interaction.InputBox("輸入類別:", "class", "", -1, -1);

            FolderBrowserDialog folder = new FolderBrowserDialog();
            string[] imgjpg;//存放所有的jpg

            if (folder.ShowDialog() == DialogResult.OK)
            {
                imgjpg = Directory.GetFileSystemEntries(folder.SelectedPath, "*.jpg");
                Image<Bgr, byte> img;
                Image<Gray, Byte> imgDst;
                Image<Gray, Byte> imgLtp;

                FileStream fileStream = new FileStream(folder.SelectedPath + @"\train.txt", FileMode.Create);
                fileStream.Close();

                txtdatapath.Text = folder.SelectedPath;

                for (int i = 0; i < imgjpg.Length; i++)
                {
                    StreamWriter sw = new StreamWriter(folder.SelectedPath + @"\train.txt", true, Encoding.Default);

                    sw.Write(classno);

                    img = new Image<Bgr, byte>(imgjpg[i]).Resize(imagetrainsize, imagetrainsize, Emgu.CV.CvEnum.Inter.Linear);
                    imgLtp = new Image<Gray, byte>(img.Cols, img.Rows);

                    imgDst = img.Convert<Gray, Byte>();

                    byte ltp_threshold = 10; //threshold

                    byte[,] padding = new byte[img.Rows + 2, img.Cols + 2];

                    // image to array
                    for (int row = 1; row < imgDst.Rows + 1; ++row)
                    {
                        for (int col = 1; col < imgDst.Cols + 1; ++col)
                        {
                            padding[row, col] = imgDst.Data[row - 1, col - 1, 0];
                        }
                    }

                    // cacluate ltp
                    double[] LTP = new double[8];

                    for (int x = 1; x < imgDst.Rows - 1; x++)
                    {
                        for (int y = 1; y < imgDst.Cols - 1; y++)
                        {
                            Byte center = padding[x, y];
                            LTP[0] = padding[x - 1, y - 1];
                            LTP[1] = padding[x, y - 1];
                            LTP[2] = padding[x + 1, y - 1];
                            LTP[3] = padding[x + 1, y];
                            LTP[4] = padding[x + 1, y + 1];
                            LTP[5] = padding[x, y + 1];
                            LTP[6] = padding[x - 1, y + 1];
                            LTP[7] = padding[x - 1, y];

                            Byte temp = 0;

                            // 计算LTP的值
                            for (int k = 0; k < 8; k++)
                            {

                                LTP[k] = LTP[k] - center;

                                ////upper pattern
                                //if (LTP[k] > ltp_threshold)
                                //{
                                //    temp |= (Byte)(1 << k);
                                //}

                                //lower pattern
                                if (LTP[k] < -ltp_threshold)
                                {
                                    temp |= (Byte)(1 << k);
                                }

                            }
                            imgLtp.Data[x, y, 0] = temp;
                        }//for x  
                    }//for y

                    // export pixel to csv
                    for (int x = 0; x < imgLtp.Rows; x++)
                    {
                        for (int y = 0; y < imgLtp.Cols; y++)
                        {
                            string pixel = imgLtp.Data[x, y, 0].ToString();


                            sw.Write(',' + pixel);

                        }
                    }
                    sw.Write("\r\n");

                    img.Dispose();
                    imgDst.Dispose();
                    imgLtp.Dispose();
                    sw.Close();
                }


                MessageBox.Show("ok");
            }
        }

        private void log(string logpath, string data)
        {
            if (!File.Exists(logpath + @"\log.txt"))
            {
                FileStream fileStream = new FileStream(logpath + @"\log.txt", FileMode.Create);
                fileStream.Close();
            }

            StreamWriter sw = new StreamWriter(logpath + @"\log.txt", false);
            sw.Write(data);
            sw.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IsDisplayImage = checkBox1.Checked;
        }

        private T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TrainData == null)
            {
                return;
            }

            if (Counter < TrainData.Rows - 1)
            {
                Counter++;

                Image<Gray, byte> imgout = TrainData.GetRow(Counter).Mat.Reshape(0, imagetrainsize).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                pictureBox1.Image = imgout.Bitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TrainData == null)
            {
                return;
            }

            if (Counter >= 0)
            {

                Image<Gray, byte> imgout = TrainData.GetRow(Counter).Mat.Reshape(0, imagetrainsize).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                pictureBox1.Image = imgout.Bitmap;
                Counter--;

            }

        }

        private void sVMPredictOneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists("svm.txt"))
            {
                svm = new SVM();
                FileStorage file = new FileStorage("svm.txt", FileStorage.Mode.Read);
                svm.Read(file.GetNode("opencv_ml_svm"));
            }
            if (svm == null)
            {
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();
            string[] imgjpg;//存放所有的jpg

            if (folder.ShowDialog() == DialogResult.OK)
            {
                imgjpg = Directory.GetFileSystemEntries(folder.SelectedPath, "*.jpg");
                for (int i = 0; i < imgjpg.Length; i++)
                {
                    Image<Bgr, byte> predictimg = new Image<Bgr, byte>(imgjpg[i]);
                    pictureBox1.Image = predictimg.Bitmap;

                    LTPtransform(predictimg);

                    List<float[]> testList = new List<float[]>();
                    List<int> testLabel = new List<int>();

                    transformstr = transformstr.Remove(0, 1);

                    int firstIndex = transformstr.IndexOf(',');
                    int currentLabel = Convert.ToInt32(transformstr.Substring(0, firstIndex));

                    float[] data = transformstr.Split(',').Select(x => float.Parse(x)).ToArray();

                    testList.Add(data);
                    testLabel.Add(currentLabel);

                    TestData = new Matrix<float>(To2D<float>(testList.ToArray()));
                    TestLabel = new Matrix<int>(testLabel.ToArray());

                    if (TestData == null)
                    {
                        return;
                    }           

                    try
                    {
                        for (int t = 0; t < TestData.Rows; t++)
                        {
                            Matrix<float> row = TestData.GetRow(t);
                            float predict = svm.Predict(row); //predict 即是預測class
                            //  lblOouputLabel.Text = "Predicted Label:  " + predict.ToString();

                        

                            if (predict.ToString() == "0")
                            {
                                MessageBox.Show("Predicted : WOMAN");
                            }
                            else if (predict.ToString() == "1")
                            {
                                MessageBox.Show("Predicted : MAN");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void loadTestDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    LoadTestData(folder.SelectedPath);
                }

                MessageBox.Show("Data loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LTPtransform(Image<Bgr, byte> img)
        {
            transformstr = "";
            Image<Gray, Byte> imgDst;
            Image<Gray, Byte> imgLtp;

            imgDst = img.Convert<Gray, Byte>().Resize(imagetrainsize, imagetrainsize, Emgu.CV.CvEnum.Inter.Linear);
            imgLtp = new Image<Gray, byte>(imgDst.Cols, imgDst.Rows);

            byte ltp_threshold = 10; //threshold

            byte[,] padding = new byte[img.Rows + 2, img.Cols + 2];

            // image to array
            for (int row = 1; row < imgDst.Rows + 1; ++row)
            {
                for (int col = 1; col < imgDst.Cols + 1; ++col)
                {
                    padding[row, col] = imgDst.Data[row - 1, col - 1, 0];
                }
            }

            // cacluate ltp
            double[] LTP = new double[8];

            for (int x = 1; x < imgDst.Rows - 1; x++)
            {
                for (int y = 1; y < imgDst.Cols - 1; y++)
                {
                    Byte center = padding[x, y];
                    LTP[0] = padding[x - 1, y - 1];
                    LTP[1] = padding[x, y - 1];
                    LTP[2] = padding[x + 1, y - 1];
                    LTP[3] = padding[x + 1, y];
                    LTP[4] = padding[x + 1, y + 1];
                    LTP[5] = padding[x, y + 1];
                    LTP[6] = padding[x - 1, y + 1];
                    LTP[7] = padding[x - 1, y];

                    Byte temp = 0;

                    // 计算LTP的值
                    for (int k = 0; k < 8; k++)
                    {

                        LTP[k] = LTP[k] - center;

                        ////upper pattern
                        //if (LTP[k] > ltp_threshold)
                        //{
                        //    temp |= (Byte)(1 << k);
                        //}

                        //lower pattern
                        if (LTP[k] < -ltp_threshold)
                        {
                            temp |= (Byte)(1 << k);
                        }

                    }
                    imgLtp.Data[x, y, 0] = temp;
                }//for x  
            }//for y

            // export pixel to csv
            for (int x = 0; x < imgLtp.Rows; x++)
            {
                for (int y = 0; y < imgLtp.Cols; y++)
                {
                    string pixel = imgLtp.Data[x, y, 0].ToString();
                    // sw.Write(',' + pixel);
                    transformstr += ',' + pixel;

                }
            }

            img.Dispose();
            imgDst.Dispose();
            imgLtp.Dispose();
            //  MessageBox.Show("ok");

        }

        private void videoPredictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _cameraCapture = new VideoCapture(1);
                _tracker = new CvTracks();
                //Load haarcascades for face detection
                face = new CascadeClassifier("haarcascade_frontalface_default.xml");
                //if (File.Exists("svm.txt"))
                //{
                //    svm = new SVM();
                //    FileStorage file = new FileStorage("svm.txt", FileStorage.Mode.Read);
                //    svm.Read(file.GetNode("opencv_ml_svm"));
                //}
                //if (svm == null)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Application.Idle += new EventHandler(ProcessFrame);
        }

        void ProcessFrame(object sender, EventArgs e)
        {
            Mat frame;
            frame = _cameraCapture.QueryFrame();

            //filter out noises
            using (Mat smoothedFrame = new Mat())
            {
                CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(3, 3), 1);
                HaarDetctface(frame);
            }
        }

        void HaarDetctface(IImage image)
        {
            List<Rectangle> faces = new List<Rectangle>();
            using (CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml"))
            {
                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    //normalizes brightness and increases contrast of the image
                    CvInvoke.EqualizeHist(ugray, ugray);

                    Rectangle[] facesDetected = face.DetectMultiScale(
                       ugray,
                       1.1,
                       10,
                       new Size(20, 20));
                    faces.AddRange(facesDetected);
                }
            }

            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            }

            pictureBox1.Image = image.Bitmap;


        }
    }
}
