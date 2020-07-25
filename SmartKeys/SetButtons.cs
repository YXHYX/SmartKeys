using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

namespace SmartKeys
{
    public partial class SetButtons : Form
    {
        static public string[] buttonsPath = new string[9] {
            "", "", "", "", "", "", "", "", ""};
        
        public SetButtons()
        {
            InitializeComponent();
            setButtons();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.Multiselect = false;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
        }

        void setButtons() 
        {
            button1.Text = buttonsPath[0].Split('.')[0];
            button2.Text = buttonsPath[1].Split('.')[0];
            button3.Text = buttonsPath[2].Split('.')[0];
            button4.Text = buttonsPath[3].Split('.')[0];
            button5.Text = buttonsPath[4].Split('.')[0];
            button6.Text = buttonsPath[5].Split('.')[0];
            button7.Text = buttonsPath[6].Split('.')[0];
            button8.Text = buttonsPath[7].Split('.')[0];
            button9.Text = buttonsPath[8].Split('.')[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[0] = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[1] = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[2] = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button4.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[3] = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button5.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[4] = openFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button6.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[5] = openFileDialog1.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button7.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[6] = openFileDialog1.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button8.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[7] = openFileDialog1.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button9.Text = openFileDialog1.SafeFileName.Split('.')[0];
                buttonsPath[8] = openFileDialog1.FileName;
            }
        }
    }
}
