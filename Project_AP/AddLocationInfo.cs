using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_AP
{
    public partial class AddLocationInfo : Form
    {
        int LocWidth = 0;
        int LocHeight = 0;
        string LocName = null;
        public AddLocationInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int popupLeft = (screenWidth - this.Width) / 2;
            int popupTop = (screenHeight - this.Height) / 2;

            // Установка координат для расположения посередине экрана
            this.Left = popupLeft;
            this.Top = popupTop;
        }
        private void AddLocationInfoForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void AddLocationInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                LocName = textBox1.Text;
                bool k = int.TryParse(textBox2.Text, out LocWidth);
                bool v = int.TryParse(textBox3.Text, out LocHeight);
                if(k && v)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели некорректные данные");
                }
            }
            else
            {
                MessageBox.Show("Вы ввели не все данные");
            }
        }
        public string GetLocName()
        {
            return LocName;
        }
        public int GetLocWidth()
        {
            return LocWidth;
        }
        public int GetLocHeight()
        {
            return LocHeight;
        }
    }
}
