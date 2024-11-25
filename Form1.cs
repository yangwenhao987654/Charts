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
            option.Title.Text = "这是标题u";
            uiLineChart1.SetOption(option);
        }
        [Description("生成数据")]
        private void ResetData()
        {
            uiLineChart1.Option.Clear();

            for (int i = 0; i < 4; i++)
            {
                var pointX = new List<double>();
                var pointY = new List<double>();
                var line = new UILineSeries("线条{i}");
                for (int j = 0; j < 100; j++)
                {
                    pointX.Add(j);
                    pointY.Add(i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                    //var line = new UILineSeries("线条{i}");
                    line.Add(j, i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                    //AddChartData(line, j, i + Math.Sin(j / 100.0 * (Math.PI * 2 * 4)));
                }
                uiLineChart1.Option.AddSeries(line);
                //AddChartData($"线条：{i}", pointX.ToArray(), pointY.ToArray());
            }
            SetChartLineStyle();
        }

        /// <summary>
        /// 向图标添加数据
        /// </summary>
        /// <param name="name">线条名称</param>
        /// <param name="arrx">横轴数据</param>
        /// <param name="arry">纵轴数据</param>

        private void AddChartData(UILineSeries line, double x, double y)
        {
            line.Add(x, y);
            uiLineChart1.Option.AddSeries(line);
        }
        [Description("设置ChartLineStyle")]
        private void SetChartLineStyle()
        {
            /**
             *    添加数据
             *    var line = new UILineSeries(name);
             *    line.XData.AddRange(arrx);//double[]
                  line.YData.AddRange(arry);//double[]
             *    uiLineChart1.Option.AddSeries(line);
             */

            uiLineChart1.Option.ShowZeroLine = false;
            uiLineChart1.Option.ShowZeroValue = false;
            uiLineChart1.Option.XAxis.Clear();

            var uiTitle = new UITitle { Text = "图表一", SubText = "正玄波" };
            uiLineChart1.Option.Title = uiTitle;//设置图表名称

            uiLineChart1.Option.XAxis.Name = "时间";//横轴名称
            uiLineChart1.Option.YAxis.Name = "金钱1";//纵轴名称
            uiLineChart1.Option.Y2Axis.Name = "金钱2";//纵轴名称

            uiLineChart1.Option.XAxis.ShowGridLine = true;//横轴网格线
            uiLineChart1.Option.YAxis.ShowGridLine = true;//纵轴网格线


            //uiLineChart1.Option.XAxisType = UIAxisType.Value;//横轴类型
            //uiLineChart1.Option.XAxis.SetRange(DateTime.Now, DateTime.Now.AddMinutes(10));//设置横轴时间范围
            uiLineChart1.Option.XAxisType = UIAxisType.Value;//横轴类型

            double xBiggestValue = 100;
            uiLineChart1.Option.XAxis.SetRange(0, xBiggestValue);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）
            double biggestValue = 1;
            uiLineChart1.Option.YAxis.SetRange(-1, biggestValue);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）

            float xMin, xMax, yMin, yMax;
            /*    GetAxisRange(true, out xMin, out xMax);
                GetAxisRange(false, out yMin, out yMax);
                uiLineChart1.Option.XAxis.SetRange(xMin, xMax);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）
                uiLineChart1.Option.YAxis.SetRange(yMin, yMax);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）*/

            uiLineChart1.Refresh();

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            // 初始化 UILineChart
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

            uiLineChart1.Option.Title.SubText="";//设置图表名称

            uiLineChart1.Option.XAxis.Name = "";//横轴名称
            uiLineChart1.Option.YAxis.Name = "";//纵轴名称
                                                   // 获取爱心形状数据

            UILineSeries line = new UILineSeries("Heart Shape");
            line.Color = Color.Red;
            line = GetHeartData(line);

            // 添加曲线数据
            uiLineChart1.Option.AddSeries(line);
            
            // 配置图表
            /*    uiLineChart1.Option.XAxis.AxisLabe = "X-Axis";
                uiLineChart1.AxisY.Label = "Y-Axis";*/
            uiLineChart1.Option.XAxis.SetRange(-20, 20);
            uiLineChart1.Option.YAxis.SetRange(-20, 20);
            uiLineChart1.Refresh();
        }

        /// <summary>
        /// 生成爱心形状的坐标点
        /// </summary>
        /// <returns>包含 X 和 Y 坐标的点列表</returns>
        private Tuple<List<float>, List<float>> GetHeartData()
        {
            List<float> xData = new List<float>();
            List<float> yData = new List<float>();

            // 参数 t 范围 [0, 2π]
            double tStep = 0.01; // 控制点的精细程度
            for (double t = 0; t <= 2 * Math.PI; t += tStep)
            {
                // 参数方程
                double x = 16 * Math.Pow(Math.Sin(t), 3);
                double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);

                xData.Add((float)x);
                yData.Add((float)y);
            }

            return new Tuple<List<float>, List<float>>(xData, yData);
        }

        /// <summary>
        /// 生成爱心形状的坐标点
        /// </summary>
        /// <returns>包含 X 和 Y 坐标的点列表</returns>
        private UILineSeries GetHeartData(UILineSeries line)
        {
            // 参数 t 范围 [0, 2π]
            double tStep = 0.001; // 控制点的精细程度
            for (double t = 0; t <= 2 * Math.PI; t += tStep)
            {
                // 参数方程
                double x = 16 * Math.Pow(Math.Sin(t), 3);
                double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);

                line.Add(x, y);
            }

            return line;
        }


        /* /// <summary>
         /// 获取轴系范围
         /// </summary>
         /// <param name="isXAxis">是否为X轴</param>
         /// <param name="min">最大值</param>
         /// <param name="max">最小值</param>
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
                 double dReservedValue = (tempMax - tempMin) * 0.2;//上下预留1/5
                 tempMin -= dReservedValue;
                 tempMax += dReservedValue;
             }
             min = (float)tempMin;
             max = (float)tempMax;
         }*/
    }
}
