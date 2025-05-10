namespace Project2
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
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.button_LoadStock = new System.Windows.Forms.Button();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.openFileDialog_LoadTicker = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(40, 65);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker_StartDate.TabIndex = 0;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2021, 2, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(424, 65);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker_EndDate.TabIndex = 1;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2021, 2, 28, 0, 0, 0, 0);
            // 
            // button_LoadStock
            // 
            this.button_LoadStock.Location = new System.Drawing.Point(307, 64);
            this.button_LoadStock.Name = "button_LoadStock";
            this.button_LoadStock.Size = new System.Drawing.Size(102, 23);
            this.button_LoadStock.TabIndex = 2;
            this.button_LoadStock.Text = "Load Stock";
            this.button_LoadStock.UseVisualStyleBackColor = true;
            this.button_LoadStock.Click += new System.EventHandler(this.button_LoadStock_Click);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(78, 26);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(69, 16);
            this.label_StartDate.TabIndex = 3;
            this.label_StartDate.Text = "Start Date:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(526, 26);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(66, 16);
            this.label_EndDate.TabIndex = 4;
            this.label_EndDate.Text = "End Date:";
            // 
            // openFileDialog_LoadTicker
            // 
            this.openFileDialog_LoadTicker.DefaultExt = "CSV";
            this.openFileDialog_LoadTicker.FileName = "ABBV-Day.csv";
            this.openFileDialog_LoadTicker.Filter = "All|*.csv|Month|*-Month.csv|Week|*-Week.csv|Day|*-Day.csv|Start with A|A*.csv";
            this.openFileDialog_LoadTicker.InitialDirectory = "C:\\Users\\jesph\\Desktop\\Jessica\'s folder\\Jessica\\USF\\SPRING 2025\\COP 4365 Spring 2" +
    "025\\Stock Data";
            this.openFileDialog_LoadTicker.Multiselect = true;
            this.openFileDialog_LoadTicker.ReadOnlyChecked = true;
            this.openFileDialog_LoadTicker.ShowReadOnly = true;
            this.openFileDialog_LoadTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_LoadTicker_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 317);
            this.Controls.Add(this.button_LoadStock);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Button button_LoadStock;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog_LoadTicker;
    }
}

