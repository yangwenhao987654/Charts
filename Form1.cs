using Sunny.UI;
using System.ComponentModel;
using System.Xml.Linq;

namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UILineOption option = new UILineOption();
            option.Title.Text = "���Ǳ���u";
            uiLineChart1.SetOption(option);
        }
        [Description("��������")]
        private void ResetData()
        {
            uiLineChart1.Option.Clear();

            for (int i = 0; i < 4; i++)
            {
                var pointX = new List<double>();
                var pointY = new List<double>();
                var line = new UILineSeries("����{i}");
                for (int j = 0; j < 100; j++)
                {
                    pointX.Add(j);
                    pointY.Add(i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                    //var line = new UILineSeries("����{i}");
                    line.Add(j, i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                    //AddChartData(line, j, i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                }
                uiLineChart1.Option.AddSeries(line);
                //AddChartData($"������{i}", pointX.ToArray(), pointY.ToArray());
            }
            SetChartLineStyle();
        }

        /// <summary>
        /// ��ͼ���������
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="arrx">��������</param>
        /// <param name="arry">��������</param>

        private void AddChartData(UILineSeries line, double x, double y)
        {
            line.Add(x, y);
            uiLineChart1.Option.AddSeries(line);
        }
        [Description("����ChartLineStyle")]
        private void SetChartLineStyle()
        {
            /**
             *    �������
             *    var line = new UILineSeries(name);
             *    line.XData.AddRange(arrx);//double[]
                  line.YData.AddRange(arry);//double[]
             *    uiLineChart1.Option.AddSeries(line);
             */

            uiLineChart1.Option.ShowZeroLine = false;
            uiLineChart1.Option.ShowZeroValue = false;
            uiLineChart1.Option.XAxis.Clear();

            var uiTitle = new UITitle { Text = "ͼ��һ", SubText = "������" };
            uiLineChart1.Option.Title = uiTitle;//����ͼ������

            uiLineChart1.Option.XAxis.Name = "ʱ��";//��������
            uiLineChart1.Option.YAxis.Name = "��Ǯ1";//��������
            uiLineChart1.Option.Y2Axis.Name = "��Ǯ2";//��������

            uiLineChart1.Option.XAxis.ShowGridLine = true;//����������
            uiLineChart1.Option.YAxis.ShowGridLine = true;//����������


            //uiLineChart1.Option.XAxisType = UIAxisType.Value;//��������
            //uiLineChart1.Option.XAxis.SetRange(DateTime.Now, DateTime.Now.AddMinutes(10));//���ú���ʱ�䷶Χ
            uiLineChart1.Option.XAxisType = UIAxisType.Value;//��������

            double xBiggestValue = 100;
            uiLineChart1.Option.XAxis.SetRange(0, xBiggestValue);//���ú��᷶Χ��1.����Ϊʱ��ʱ��Ҫ����ʱ�䷶Χ��2.��ͨ������������ͼ����ʾ��
            double biggestValue = 1;
            uiLineChart1.Option.YAxis.SetRange(-1, biggestValue);//���ú��᷶Χ��1.����Ϊʱ��ʱ��Ҫ����ʱ�䷶Χ��2.��ͨ������������ͼ����ʾ��

            float xMin, xMax, yMin, yMax;
            /*    GetAxisRange(true, out xMin, out xMax);
                GetAxisRange(false, out yMin, out yMax);
                uiLineChart1.Option.XAxis.SetRange(xMin, xMax);//���ú��᷶Χ��1.����Ϊʱ��ʱ��Ҫ����ʱ�䷶Χ��2.��ͨ������������ͼ����ʾ��
                uiLineChart1.Option.YAxis.SetRange(yMin, yMax);//���ú��᷶Χ��1.����Ϊʱ��ʱ��Ҫ����ʱ�䷶Χ��2.��ͨ������������ͼ����ʾ��*/

            uiLineChart1.Refresh();

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            // ��ʼ�� UILineChart
            /*  UILineChart uiLineChart = new UILineChart
              {
                  Dock = DockStyle.Fill,
                  Title = "Heart Shape Chart",
                  TitleFont = new Font("Microsoft YaHei", 12, FontStyle.Bold),
                  SubTitle = "Drawn with UILineChart",
                  SubTitleFont = new Font("Microsoft YaHei", 10, FontStyle.Italic),
                  BackColor = Color.White
              };*/
            uiLineChart1.Option.Clear();
            uiLineChart1.Option.Title.Text = "Heart";

            uiLineChart1.Option.Title.SubText="";//����ͼ������

            uiLineChart1.Option.XAxis.Name = "";//��������
            uiLineChart1.Option.YAxis.Name = "";//��������
                                                   // ��ȡ������״����

            UILineSeries line = new UILineSeries("Heart Shape");
            line.Color = Color.Red;
            line = GetHeartData(line);

            // �����������
            uiLineChart1.Option.AddSeries(line);
            
            // ����ͼ��
            /*    uiLineChart1.Option.XAxis.AxisLabe = "X-Axis";
                uiLineChart1.AxisY.Label = "Y-Axis";*/
            uiLineChart1.Option.XAxis.SetRange(-20, 20);
            uiLineChart1.Option.YAxis.SetRange(-20, 20);
            uiLineChart1.Refresh();
        }

        /// <summary>
        /// ���ɰ�����״�������
        /// </summary>
        /// <returns>���� X �� Y ����ĵ��б�</returns>
        private Tuple<List<float>, List<float>> GetHeartData()
        {
            List<float> xData = new List<float>();
            List<float> yData = new List<float>();

            // ���� t ��Χ [0, 2��]
            double tStep = 0.01; // ���Ƶ�ľ�ϸ�̶�
            for (double t = 0; t <= 2 * Math.PI; t += tStep)
            {
                // ��������
                double x = 16 * Math.Pow(Math.Sin(t), 3);
                double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);

                xData.Add((float)x);
                yData.Add((float)y);
            }

            return new Tuple<List<float>, List<float>>(xData, yData);
        }

        /// <summary>
        /// ���ɰ�����״�������
        /// </summary>
        /// <returns>���� X �� Y ����ĵ��б�</returns>
        private UILineSeries GetHeartData(UILineSeries line)
        {
            // ���� t ��Χ [0, 2��]
            double tStep = 0.001; // ���Ƶ�ľ�ϸ�̶�
            for (double t = 0; t <= 2 * Math.PI; t += tStep)
            {
                // ��������
                double x = 16 * Math.Pow(Math.Sin(t), 3);
                double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);

                line.Add(x, y);
            }

            return line;
        }


        /* /// <summary>
         /// ��ȡ��ϵ��Χ
         /// </summary>
         /// <param name="isXAxis">�Ƿ�ΪX��</param>
         /// <param name="min">���ֵ</param>
         /// <param name="max">��Сֵ</param>
         private void GetAxisRange(bool isXAxis, out float min, out float max)
         {
             min = isXAxis ? 0 : -10;
             max = isXAxis ? 100 : 10;
             if (uiLineChart1.Option.Series.Count < 1) return;

             var name = uiLineChart1.Option.Series.ElementAt(0).Key;
             double tempMin, tempMax;
             if (isXAxis)
             {
                 tempMin = uiLineChart1.Option.Series[name].XData.Min();
                 tempMax = uiLineChart1.Option.Series[name].XData.Max();
                 for (int i = 1; i < uiLineChart1.Option.Series.Count; i++)
                 {
                     name = uiLineChart1.Option.Series.ElementAt(i).Key;
                     tempMin = Math.Min(uiLineChart1.Option.Series[name].XData.Min(), tempMin);
                     tempMax = Math.Max(uiLineChart1.Option.Series[name].XData.Max(), tempMax);
                 }
             }
             else
             {
                 tempMin = uiLineChart1.Option.Series[name].YData.Min();
                 tempMax = uiLineChart1.Option.Series[name].YData.Max();
                 for (int i = 1; i < uiLineChart1.Option.Series.Count; i++)
                 {
                     name = uiLineChart1.Option.Series.ElementAt(i).Key;
                     tempMin = Math.Min(uiLineChart1.Option.Series[name].YData.Min(), tempMin);
                     tempMax = Math.Max(uiLineChart1.Option.Series[name].YData.Max(), tempMax);
                 }
                 double dReservedValue = (tempMax - tempMin) * 0.2;//����Ԥ��1/5
                 tempMin -= dReservedValue;
                 tempMax += dReservedValue;
             }
             min = (float)tempMin;
             max = (float)tempMax;
         }*/
    }
}
