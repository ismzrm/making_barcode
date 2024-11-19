using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
namespace _2024._10._22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("BARKODLANACAK VERİYİ ALANA YAZINIZ!!");
                textBox1.Focus();
            }
            else
            {
                Barcode barkod_olustur = new Barcode();
                barkod_olustur.IncludeLabel = true;
                Color yazı = Color.Black;
                Color arka = Color.White;
                pictureBox1.Image = barkod_olustur.Encode(TYPE.CODE128,
                    textBox1.Text, yazı, arka, (int)(pictureBox1.Width * 0.9),
                    (int)(pictureBox1.Height * 0.9));
            }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = char.IsLetter(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("QR kod oluşturunuz!!");
                return;
            }
            var resim = pictureBox1.Image;
            resim.Save(Application.StartupPath + "\\" + DateTime.Now.ToShortDateString() +
                DateTime.Now.ToFileTime() + ".png");
            MessageBox.Show("QR CODE başarıyla kaydedildi!!");
            pictureBox1.Image = null;
            textBox1.Text = "";
            
        }
    }
}
