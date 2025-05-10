namespace Project2
{
    partial class Form_ChartDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation rectangleAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation();
            System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation rectangleAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_Candlestick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.hScrollBar_Margin = new System.Windows.Forms.HScrollBar();
            this.textBox_Margin = new System.Windows.Forms.TextBox();
            this.label_UpWaves = new System.Windows.Forms.Label();
            this.label_DownWaves = new System.Windows.Forms.Label();
            this.label_Margin = new System.Windows.Forms.Label();
            this.comboBox_UpWaves = new System.Windows.Forms.ComboBox();
            this.comboBox_DownWaves = new System.Windows.Forms.ComboBox();
            this.timer_Simulate = new System.Windows.Forms.Timer(this.components);
            this.textBox_Confirmations = new System.Windows.Forms.TextBox();
            this.label_Confirmations = new System.Windows.Forms.Label();
            this.textBox_HighLowPrice = new System.Windows.Forms.TextBox();
            this.label_HighLowPrice = new System.Windows.Forms.Label();
            this.button_Simulate = new System.Windows.Forms.Button();
            this.button_Plus = new System.Windows.Forms.Button();
            this.button_Minus = new System.Windows.Forms.Button();
            this.hScrollBar_PercentageIterate = new System.Windows.Forms.HScrollBar();
            this.label_PercentageIterate = new System.Windows.Forms.Label();
            this.textBox_PercentageIterate = new System.Windows.Forms.TextBox();
            this.hScrollBar_PercentageRange = new System.Windows.Forms.HScrollBar();
            this.label_PercentageRange = new System.Windows.Forms.Label();
            this.textBox_PercentageRange = new System.Windows.Forms.TextBox();
            this.bindingSource_Candlestick = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlestick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Candlestick)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_Candlestick
            // 
            textAnnotation1.ForeColor = System.Drawing.Color.Red;
            textAnnotation1.Name = "PeakAnnotation";
            textAnnotation1.Text = "P";
            textAnnotation2.ForeColor = System.Drawing.Color.Green;
            textAnnotation2.Name = "ValleyAnnotation";
            textAnnotation2.Text = "V";
            rectangleAnnotation1.ClipToChartArea = "ChartArea_OHLC";
            rectangleAnnotation1.LineColor = System.Drawing.Color.Green;
            rectangleAnnotation1.Name = "UpWaveRectangle";
            rectangleAnnotation1.Text = "RectangleAnnotation1";
            rectangleAnnotation2.ClipToChartArea = "ChartArea_OHLC";
            rectangleAnnotation2.LineColor = System.Drawing.Color.Red;
            rectangleAnnotation2.Name = "DownWaveRectangle";
            rectangleAnnotation2.Text = "RectangleAnnotation1";
            lineAnnotation1.ClipToChartArea = "ChartArea_OHLC";
            lineAnnotation1.Name = "WaveLine";
            this.chart_Candlestick.Annotations.Add(textAnnotation1);
            this.chart_Candlestick.Annotations.Add(textAnnotation2);
            this.chart_Candlestick.Annotations.Add(rectangleAnnotation1);
            this.chart_Candlestick.Annotations.Add(rectangleAnnotation2);
            this.chart_Candlestick.Annotations.Add(lineAnnotation1);
            chartArea1.Name = "ChartArea_OHLC";
            this.chart_Candlestick.ChartAreas.Add(chartArea1);
            this.chart_Candlestick.DataSource = this.bindingSource_Candlestick;
            this.chart_Candlestick.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart_Candlestick.Legends.Add(legend1);
            this.chart_Candlestick.Location = new System.Drawing.Point(0, 0);
            this.chart_Candlestick.Name = "chart_Candlestick";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "High, Low, Open, Close";
            series1.YValuesPerPoint = 4;
            this.chart_Candlestick.Series.Add(series1);
            this.chart_Candlestick.Size = new System.Drawing.Size(1361, 508);
            this.chart_Candlestick.TabIndex = 0;
            this.chart_Candlestick.Text = "StockDisplay";
            this.chart_Candlestick.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_Candlestick_MouseDown);
            this.chart_Candlestick.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_Candlestick_MouseMove);
            this.chart_Candlestick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_Candlestick_MouseUp);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(907, 609);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(686, 607);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(1006, 607);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_EndDate.TabIndex = 3;
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(733, 588);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(69, 16);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start Date:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(1073, 584);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(66, 16);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "End Date:";
            // 
            // hScrollBar_Margin
            // 
            this.hScrollBar_Margin.LargeChange = 1;
            this.hScrollBar_Margin.Location = new System.Drawing.Point(75, 529);
            this.hScrollBar_Margin.Maximum = 4;
            this.hScrollBar_Margin.Minimum = 1;
            this.hScrollBar_Margin.Name = "hScrollBar_Margin";
            this.hScrollBar_Margin.Size = new System.Drawing.Size(400, 39);
            this.hScrollBar_Margin.TabIndex = 6;
            this.hScrollBar_Margin.Value = 1;
            this.hScrollBar_Margin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Margin_Scroll);
            // 
            // textBox_Margin
            // 
            this.textBox_Margin.Location = new System.Drawing.Point(572, 539);
            this.textBox_Margin.Name = "textBox_Margin";
            this.textBox_Margin.ReadOnly = true;
            this.textBox_Margin.Size = new System.Drawing.Size(100, 22);
            this.textBox_Margin.TabIndex = 7;
            this.textBox_Margin.Text = "1";
            // 
            // label_UpWaves
            // 
            this.label_UpWaves.AutoSize = true;
            this.label_UpWaves.Location = new System.Drawing.Point(137, 587);
            this.label_UpWaves.Name = "label_UpWaves";
            this.label_UpWaves.Size = new System.Drawing.Size(72, 16);
            this.label_UpWaves.TabIndex = 10;
            this.label_UpWaves.Text = "UP Waves";
            // 
            // label_DownWaves
            // 
            this.label_DownWaves.AutoSize = true;
            this.label_DownWaves.Location = new System.Drawing.Point(378, 588);
            this.label_DownWaves.Name = "label_DownWaves";
            this.label_DownWaves.Size = new System.Drawing.Size(96, 16);
            this.label_DownWaves.TabIndex = 11;
            this.label_DownWaves.Text = "DOWN Waves";
            // 
            // label_Margin
            // 
            this.label_Margin.AutoSize = true;
            this.label_Margin.Location = new System.Drawing.Point(515, 545);
            this.label_Margin.Name = "label_Margin";
            this.label_Margin.Size = new System.Drawing.Size(51, 16);
            this.label_Margin.TabIndex = 12;
            this.label_Margin.Text = "Margin:";
            // 
            // comboBox_UpWaves
            // 
            this.comboBox_UpWaves.FormattingEnabled = true;
            this.comboBox_UpWaves.Location = new System.Drawing.Point(74, 607);
            this.comboBox_UpWaves.Name = "comboBox_UpWaves";
            this.comboBox_UpWaves.Size = new System.Drawing.Size(209, 24);
            this.comboBox_UpWaves.TabIndex = 13;
            this.comboBox_UpWaves.SelectedIndexChanged += new System.EventHandler(this.comboBox_UpWaves_SelectedIndexChanged);
            // 
            // comboBox_DownWaves
            // 
            this.comboBox_DownWaves.FormattingEnabled = true;
            this.comboBox_DownWaves.Location = new System.Drawing.Point(324, 607);
            this.comboBox_DownWaves.Name = "comboBox_DownWaves";
            this.comboBox_DownWaves.Size = new System.Drawing.Size(199, 24);
            this.comboBox_DownWaves.TabIndex = 14;
            this.comboBox_DownWaves.SelectedIndexChanged += new System.EventHandler(this.comboBox_DownWaves_SelectedIndexChanged);
            // 
            // timer_Simulate
            // 
            this.timer_Simulate.Interval = 500;
            this.timer_Simulate.Tick += new System.EventHandler(this.timer_Simulate_Tick);
            // 
            // textBox_Confirmations
            // 
            this.textBox_Confirmations.Location = new System.Drawing.Point(827, 539);
            this.textBox_Confirmations.Name = "textBox_Confirmations";
            this.textBox_Confirmations.ReadOnly = true;
            this.textBox_Confirmations.Size = new System.Drawing.Size(155, 22);
            this.textBox_Confirmations.TabIndex = 18;
            this.textBox_Confirmations.Text = "0";
            // 
            // label_Confirmations
            // 
            this.label_Confirmations.AutoSize = true;
            this.label_Confirmations.Location = new System.Drawing.Point(855, 520);
            this.label_Confirmations.Name = "label_Confirmations";
            this.label_Confirmations.Size = new System.Drawing.Size(91, 16);
            this.label_Confirmations.TabIndex = 19;
            this.label_Confirmations.Text = "Confirmations:";
            // 
            // textBox_HighLowPrice
            // 
            this.textBox_HighLowPrice.Location = new System.Drawing.Point(1056, 539);
            this.textBox_HighLowPrice.Name = "textBox_HighLowPrice";
            this.textBox_HighLowPrice.ReadOnly = true;
            this.textBox_HighLowPrice.Size = new System.Drawing.Size(162, 22);
            this.textBox_HighLowPrice.TabIndex = 21;
            this.textBox_HighLowPrice.Text = "0";
            // 
            // label_HighLowPrice
            // 
            this.label_HighLowPrice.AutoSize = true;
            this.label_HighLowPrice.Location = new System.Drawing.Point(1089, 520);
            this.label_HighLowPrice.Name = "label_HighLowPrice";
            this.label_HighLowPrice.Size = new System.Drawing.Size(86, 16);
            this.label_HighLowPrice.TabIndex = 22;
            this.label_HighLowPrice.Text = "Current Price:";
            // 
            // button_Simulate
            // 
            this.button_Simulate.Location = new System.Drawing.Point(764, 694);
            this.button_Simulate.Name = "button_Simulate";
            this.button_Simulate.Size = new System.Drawing.Size(75, 52);
            this.button_Simulate.TabIndex = 15;
            this.button_Simulate.Text = "Start";
            this.button_Simulate.UseVisualStyleBackColor = true;
            this.button_Simulate.Click += new System.EventHandler(this.button_Simulate_Click);
            // 
            // button_Plus
            // 
            this.button_Plus.Location = new System.Drawing.Point(884, 679);
            this.button_Plus.Name = "button_Plus";
            this.button_Plus.Size = new System.Drawing.Size(75, 38);
            this.button_Plus.TabIndex = 16;
            this.button_Plus.Text = "+";
            this.button_Plus.UseVisualStyleBackColor = true;
            this.button_Plus.Click += new System.EventHandler(this.button_Plus_Click);
            // 
            // button_Minus
            // 
            this.button_Minus.Location = new System.Drawing.Point(884, 723);
            this.button_Minus.Name = "button_Minus";
            this.button_Minus.Size = new System.Drawing.Size(75, 41);
            this.button_Minus.TabIndex = 17;
            this.button_Minus.Text = "-";
            this.button_Minus.UseVisualStyleBackColor = true;
            this.button_Minus.Click += new System.EventHandler(this.button_Minus_Click);
            // 
            // hScrollBar_PercentageIterate
            // 
            this.hScrollBar_PercentageIterate.Location = new System.Drawing.Point(238, 671);
            this.hScrollBar_PercentageIterate.Minimum = 1;
            this.hScrollBar_PercentageIterate.Name = "hScrollBar_PercentageIterate";
            this.hScrollBar_PercentageIterate.Size = new System.Drawing.Size(236, 46);
            this.hScrollBar_PercentageIterate.TabIndex = 20;
            this.hScrollBar_PercentageIterate.Value = 1;
            this.hScrollBar_PercentageIterate.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_PercentageIterate_Scroll);
            // 
            // label_PercentageIterate
            // 
            this.label_PercentageIterate.AutoSize = true;
            this.label_PercentageIterate.Location = new System.Drawing.Point(507, 679);
            this.label_PercentageIterate.Name = "label_PercentageIterate";
            this.label_PercentageIterate.Size = new System.Drawing.Size(130, 16);
            this.label_PercentageIterate.TabIndex = 24;
            this.label_PercentageIterate.Text = "Percentage Iterating:";
            // 
            // textBox_PercentageIterate
            // 
            this.textBox_PercentageIterate.Location = new System.Drawing.Point(641, 679);
            this.textBox_PercentageIterate.Name = "textBox_PercentageIterate";
            this.textBox_PercentageIterate.ReadOnly = true;
            this.textBox_PercentageIterate.Size = new System.Drawing.Size(105, 22);
            this.textBox_PercentageIterate.TabIndex = 25;
            this.textBox_PercentageIterate.Text = "1";
            // 
            // hScrollBar_PercentageRange
            // 
            this.hScrollBar_PercentageRange.Location = new System.Drawing.Point(238, 730);
            this.hScrollBar_PercentageRange.Minimum = 1;
            this.hScrollBar_PercentageRange.Name = "hScrollBar_PercentageRange";
            this.hScrollBar_PercentageRange.Size = new System.Drawing.Size(236, 47);
            this.hScrollBar_PercentageRange.TabIndex = 26;
            this.hScrollBar_PercentageRange.Value = 25;
            this.hScrollBar_PercentageRange.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_PercentageRange_Scroll);
            // 
            // label_PercentageRange
            // 
            this.label_PercentageRange.AutoSize = true;
            this.label_PercentageRange.Location = new System.Drawing.Point(510, 748);
            this.label_PercentageRange.Name = "label_PercentageRange";
            this.label_PercentageRange.Size = new System.Drawing.Size(127, 16);
            this.label_PercentageRange.TabIndex = 27;
            this.label_PercentageRange.Text = "Percentage Range: ";
            // 
            // textBox_PercentageRange
            // 
            this.textBox_PercentageRange.Location = new System.Drawing.Point(634, 745);
            this.textBox_PercentageRange.Name = "textBox_PercentageRange";
            this.textBox_PercentageRange.ReadOnly = true;
            this.textBox_PercentageRange.Size = new System.Drawing.Size(121, 22);
            this.textBox_PercentageRange.TabIndex = 28;
            this.textBox_PercentageRange.Text = "25";
            // 
            // bindingSource_Candlestick
            // 
            this.bindingSource_Candlestick.DataSource = typeof(Project2.Candlestick);
            // 
            // Form_ChartDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 799);
            this.Controls.Add(this.textBox_PercentageRange);
            this.Controls.Add(this.label_PercentageRange);
            this.Controls.Add(this.hScrollBar_PercentageRange);
            this.Controls.Add(this.textBox_PercentageIterate);
            this.Controls.Add(this.label_PercentageIterate);
            this.Controls.Add(this.label_HighLowPrice);
            this.Controls.Add(this.textBox_HighLowPrice);
            this.Controls.Add(this.hScrollBar_PercentageIterate);
            this.Controls.Add(this.label_Confirmations);
            this.Controls.Add(this.textBox_Confirmations);
            this.Controls.Add(this.button_Minus);
            this.Controls.Add(this.button_Plus);
            this.Controls.Add(this.button_Simulate);
            this.Controls.Add(this.comboBox_DownWaves);
            this.Controls.Add(this.comboBox_UpWaves);
            this.Controls.Add(this.label_Margin);
            this.Controls.Add(this.label_DownWaves);
            this.Controls.Add(this.label_UpWaves);
            this.Controls.Add(this.textBox_Margin);
            this.Controls.Add(this.hScrollBar_Margin);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.chart_Candlestick);
            this.Name = "Form_ChartDisplay";
            this.Text = "Form_ChartDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlestick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Candlestick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Candlestick;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.BindingSource bindingSource_Candlestick;
        private System.Windows.Forms.HScrollBar hScrollBar_Margin;
        private System.Windows.Forms.TextBox textBox_Margin;
        private System.Windows.Forms.Label label_UpWaves;
        private System.Windows.Forms.Label label_DownWaves;
        private System.Windows.Forms.Label label_Margin;
        private System.Windows.Forms.ComboBox comboBox_UpWaves;
        private System.Windows.Forms.ComboBox comboBox_DownWaves;
        private System.Windows.Forms.Timer timer_Simulate;
        private System.Windows.Forms.TextBox textBox_Confirmations;
        private System.Windows.Forms.Label label_Confirmations;
        private System.Windows.Forms.TextBox textBox_HighLowPrice;
        private System.Windows.Forms.Label label_HighLowPrice;
        private System.Windows.Forms.Button button_Simulate;
        private System.Windows.Forms.Button button_Plus;
        private System.Windows.Forms.Button button_Minus;
        private System.Windows.Forms.HScrollBar hScrollBar_PercentageIterate;
        private System.Windows.Forms.Label label_PercentageIterate;
        private System.Windows.Forms.TextBox textBox_PercentageIterate;
        private System.Windows.Forms.HScrollBar hScrollBar_PercentageRange;
        private System.Windows.Forms.Label label_PercentageRange;
        private System.Windows.Forms.TextBox textBox_PercentageRange;
    }
}