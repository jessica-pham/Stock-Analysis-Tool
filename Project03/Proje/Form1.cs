using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button_LoadStock;
            
        }

        private void button_LoadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_LoadTicker.ShowDialog();
        }

        private void openFileDialog_LoadTicker_FileOk(object sender, CancelEventArgs e)
        {
            foreach (var filename in openFileDialog_LoadTicker.FileNames)
            {
                Form_ChartDisplay f = new Form_ChartDisplay(filename, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
                f.Text = filename;
                f.Show();
            }


            //var g = new Form_ChartDisplay();
            //g.Show();
        }








    }
}





