namespace Charts
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uiLineChart1 = new Sunny.UI.UILineChart();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiLineChart1
            // 
            uiLineChart1.ChartStyleType = Sunny.UI.UIChartStyleType.Default;
            uiLineChart1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.LegendFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.Location = new Point(47, 50);
            uiLineChart1.MinimumSize = new Size(1, 1);
            uiLineChart1.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            uiLineChart1.MouseZoom = false;
            uiLineChart1.Name = "uiLineChart1";
            uiLineChart1.Size = new Size(558, 312);
            uiLineChart1.SubFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.TabIndex = 2;
            uiLineChart1.Text = "uiLineChart1";
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Location = new Point(681, 86);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 3;
            uiButton1.Text = "uiButton1";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Location = new Point(681, 172);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new Size(100, 35);
            uiButton2.TabIndex = 4;
            uiButton2.Text = "Heart";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiLineChart1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILineChart uiLineChart1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
    }
}
