namespace Project001
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_LoadTicker = new System.Windows.Forms.Button();
            this.openFileDialog_LoadTicker = new System.Windows.Forms.OpenFileDialog();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_OHLCV = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chart_Candlestick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OHLCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlestick)).BeginInit();
            this.SuspendLayout();
            // 
            // button_LoadTicker
            // 
            this.button_LoadTicker.Location = new System.Drawing.Point(490, 18);
            this.button_LoadTicker.Name = "button_LoadTicker";
            this.button_LoadTicker.Size = new System.Drawing.Size(149, 61);
            this.button_LoadTicker.TabIndex = 0;
            this.button_LoadTicker.Text = "Load Ticker";
            this.button_LoadTicker.UseVisualStyleBackColor = true;
            this.button_LoadTicker.Click += new System.EventHandler(this.button_LoadTicker_Click);
            // 
            // openFileDialog_LoadTicker
            // 
            this.openFileDialog_LoadTicker.DefaultExt = "CSV";
            this.openFileDialog_LoadTicker.FileName = "AAPL-Month.csv";
            this.openFileDialog_LoadTicker.Filter = "All|*.csv|Month|*-Month.csv|Week|*-Week.csv|Day|*-Day.csv|Start with A|A*.csv";
            this.openFileDialog_LoadTicker.InitialDirectory = "C:\\Users\\jesph\\Desktop\\Jessica\'s folder\\Jessica\\USF\\SPRING 2025\\COP 4365 Spring 2" +
    "025\\Stock Data";
            this.openFileDialog_LoadTicker.Multiselect = true;
            this.openFileDialog_LoadTicker.ReadOnlyChecked = true;
            this.openFileDialog_LoadTicker.ShowReadOnly = true;
            this.openFileDialog_LoadTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_LoadTicker_FileOk);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(666, 18);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(69, 16);
            this.label_StartDate.TabIndex = 1;
            this.label_StartDate.Text = "Start Date:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(666, 57);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(66, 16);
            this.label_EndDate.TabIndex = 2;
            this.label_EndDate.Text = "End Date:";
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(757, 12);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(239, 22);
            this.dateTimePicker_StartDate.TabIndex = 3;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(757, 57);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(239, 22);
            this.dateTimePicker_EndDate.TabIndex = 4;
            // 
            // dataGridView_OHLCV
            // 
            this.dataGridView_OHLCV.AllowUserToOrderColumns = true;
            this.dataGridView_OHLCV.AutoGenerateColumns = false;
            this.dataGridView_OHLCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OHLCV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dataGridView_OHLCV.DataSource = this.candlestickBindingSource;
            this.dataGridView_OHLCV.Location = new System.Drawing.Point(28, 95);
            this.dataGridView_OHLCV.Name = "dataGridView_OHLCV";
            this.dataGridView_OHLCV.RowHeadersWidth = 51;
            this.dataGridView_OHLCV.RowTemplate.Height = 24;
            this.dataGridView_OHLCV.Size = new System.Drawing.Size(1038, 100);
            this.dataGridView_OHLCV.TabIndex = 5;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "Open";
            this.openDataGridViewTextBoxColumn.HeaderText = "Open";
            this.openDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            this.openDataGridViewTextBoxColumn.Width = 125;
            // 
            // highDataGridViewTextBoxColumn
            // 
            this.highDataGridViewTextBoxColumn.DataPropertyName = "High";
            this.highDataGridViewTextBoxColumn.HeaderText = "High";
            this.highDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.highDataGridViewTextBoxColumn.Name = "highDataGridViewTextBoxColumn";
            this.highDataGridViewTextBoxColumn.Width = 125;
            // 
            // lowDataGridViewTextBoxColumn
            // 
            this.lowDataGridViewTextBoxColumn.DataPropertyName = "Low";
            this.lowDataGridViewTextBoxColumn.HeaderText = "Low";
            this.lowDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lowDataGridViewTextBoxColumn.Name = "lowDataGridViewTextBoxColumn";
            this.lowDataGridViewTextBoxColumn.Width = 125;
            // 
            // closeDataGridViewTextBoxColumn
            // 
            this.closeDataGridViewTextBoxColumn.DataPropertyName = "Close";
            this.closeDataGridViewTextBoxColumn.HeaderText = "Close";
            this.closeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.closeDataGridViewTextBoxColumn.Name = "closeDataGridViewTextBoxColumn";
            this.closeDataGridViewTextBoxColumn.Width = 125;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.Width = 125;
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(Project001.Candlestick);
            // 
            // chart_Candlestick
            // 
            chartArea1.AxisY.Title = "Price";
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_Candlestick.ChartAreas.Add(chartArea1);
            this.chart_Candlestick.ChartAreas.Add(chartArea2);
            this.chart_Candlestick.DataSource = this.candlestickBindingSource;
            legend1.Name = "Legend1";
            this.chart_Candlestick.Legends.Add(legend1);
            this.chart_Candlestick.Location = new System.Drawing.Point(28, 201);
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
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "Volume";
            this.chart_Candlestick.Series.Add(series1);
            this.chart_Candlestick.Series.Add(series2);
            this.chart_Candlestick.Size = new System.Drawing.Size(1038, 332);
            this.chart_Candlestick.TabIndex = 6;
            this.chart_Candlestick.Text = "chart_OHLCV";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(315, 18);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(150, 61);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 545);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.chart_Candlestick);
            this.Controls.Add(this.dataGridView_OHLCV);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.button_LoadTicker);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OHLCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlestick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LoadTicker;
        private System.Windows.Forms.OpenFileDialog openFileDialog_LoadTicker;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.DataGridView dataGridView_OHLCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource candlestickBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Candlestick;
        private System.Windows.Forms.Button button_Refresh;
    }
}

