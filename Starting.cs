using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PhotoManipulation
{
    public partial class Starting : Form
    {

        public Starting()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //    int i = 0;
            //    DialogResult result = folderBrowserDialog1.ShowDialog();
            //    textBox1.Text = folderBrowserDialog1.SelectedPath;
            //    String[] array2 = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            //    foreach (string Nam in array2) FileSort ( Name = array2[i] );
            //    i++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog2.ShowDialog();
            textBox2.Text = folderBrowserDialog2.SelectedPath;
        }

        private void imageScraperToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Scraper form2 = new Scraper();
            form2.Show();
        }

        private void memeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form4 = new About();
            form4.Show();
        }
    }
}
