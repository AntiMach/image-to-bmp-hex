using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public string HEXofBitmap(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Bmp);
            byte[] hexarray = stream.ToArray();
            string hex = BitConverter.ToString(hexarray);
            return hex.Replace("-"," ");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "PNG Files|*.png|JPEG Files|*.jpeg|GIF Files|*.gif|BMP Files|*.bmp";
            img.Title = "Open an image file to get the hex data from";

            if (img.ShowDialog() == DialogResult.OK)
            {
                output.Text = HEXofBitmap(Image.FromFile(img.FileName));
            }
        }
    }
}
