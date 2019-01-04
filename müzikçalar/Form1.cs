using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace müzikçalar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }






        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int i = listBox2.SelectedIndex;

            if (i != 0)
            {
                axWindowsMediaPlayer1.URL = listBox2.Items[i - 1].ToString();

                listBox1.SelectedIndex = i - 1;

            }
        }









        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox5.Visible = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();
           
        }







        private void pictureBox4_Click(object sender, EventArgs e)
        {

            int i = listBox2.SelectedIndex;
            int mSayısı = listBox1.Items.Count;
            if (i + 1 < mSayısı)
            {
                axWindowsMediaPlayer1.URL = listBox2.Items[i + 1].ToString();

                listBox1.SelectedIndex = i + 1;

            }
          
        }







        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();

            pictureBox3.Visible = true;
            pictureBox5.Visible = false;

            



        }







        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }







        private void button1_Click(object sender, EventArgs e)
        {
               openFileDialog1.Title = "Müzik Seç";
            openFileDialog1.Filter = " (*.mp3)|*.mp3| (*.WMA)|*.WMA| (*.WAV)|*.WAV| (*.AAC)|*.AAC| (*.AMR)|*.AMR| (*.mp4)|*.mp4";
            openFileDialog1.ShowDialog();

            for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
            {
                listBox1.Items.Add(openFileDialog1.SafeFileNames[i].ToString());
                listBox2.Items.Add(openFileDialog1.FileNames[i].ToString());
               
            }
        }











        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox2.SelectedIndex = listBox1.SelectedIndex;
            axWindowsMediaPlayer1.URL = listBox2.SelectedItem.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
            label1.Text = listBox1.SelectedItem.ToString();

            pictureBox3.Visible = false;
            pictureBox5.Visible = true;




            timer1.Enabled = true;
        }












        

        private void timer1_Tick(object sender, EventArgs e)
        {
            string süre = axWindowsMediaPlayer1.currentMedia.duration.ToString();
            int süreint = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration - (axWindowsMediaPlayer1.currentMedia.duration % 1));

            string süre1 = axWindowsMediaPlayer1.Ctlcontrols.currentPosition.ToString();
            int süreint1 = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition - (axWindowsMediaPlayer1.Ctlcontrols.currentPosition % 1));
            int mSayısı = listBox1.Items.Count;
            label3.Text = axWindowsMediaPlayer1.currentMedia.durationString;
            label4.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;

            if (label3.Text != "0.00")
            {
                trackBar2.Maximum = süreint;
                trackBar2.Value = süreint1;

            }
           
                if (label3.Text == label4.Text && (label4.Text != "0.00" || label3.Text==""))
                {
                    int i = listBox2.SelectedIndex;

                    if (i + 1 < mSayısı)
                    {
                        axWindowsMediaPlayer1.URL = listBox2.Items[i + 1].ToString();

                        listBox1.SelectedIndex = i + 1;

                    }
                }

            if(pictureBox5.Visible==true && listBox1.SelectedItem != null)
            {
                pictureBox7.Visible = false;
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox7.Visible = true;
                pictureBox1.Visible = false;
            }


            
        }






       

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
                  axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar2.Value;

        }






        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
          
        }



        



        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }




        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }



        private void parçaBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MessageBox.Show(listBox2.SelectedItem.ToString()+"\n"+listBox1.SelectedItem.ToString(),"Parça Bilgileri",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen listeden parça seçin", "Parça Bilgileri ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kaldır = listBox1.SelectedIndex;
            if (listBox1.SelectedItem != listBox2.SelectedItem)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox2.Items.Remove(listBox2.Items[kaldır]);

            }
            else
            {
                MessageBox.Show("Yürütülen Parçayı kaldıramazsınız...", "Hata !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }







        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
