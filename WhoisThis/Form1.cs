using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoisThis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            seleziona();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seleziona();
        }


        public void seleziona()
        {
            var request = WebRequest.Create("https://thispersondoesnotexist.com/image");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG Image|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }
    }
}
