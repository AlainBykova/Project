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
    public partial class EquipmentAddForm : Form
    {
        public EquipmentAddForm()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            HardwareJson newHardware = new()
            {
                name = textBox1.Text,
                description = textBox3.Text,
                image_link = textBox2.Text,
                type = comboBox1.SelectedItem.ToString()
            };
            newHardware.specifications = new Dictionary<string, int>();
            string spefic = textBox4.Text;
            int k = 0;
            int Value;
            while (!String.IsNullOrEmpty(spefic))
            {
                k = spefic.IndexOf(": ");
                if (k == -1)
                {
                    break;
                }
                string Name = spefic.Substring(0, k);
                spefic = spefic.Substring(k + 2);
                k = spefic.IndexOf(", ");

                if (k == -1)
                {
                    Value = int.Parse(spefic);
                }
                else
                {
                    Value = int.Parse(spefic.Substring(0, k));
                }
                spefic = spefic.Substring(k + 2);
                newHardware.specifications.Add(Name, Value);
            }
            HardwareService hardwareService = new("https://helow19274.ru/aip/api/hardware", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
            int index = await hardwareService.CreateNewHardwareApi(newHardware);
            MessageBox.Show("Оборудование успешно создано");
            this.Close();
        }
    }
}
