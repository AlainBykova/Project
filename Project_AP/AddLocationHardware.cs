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

    public partial class AddLocationHardware : Form
    {
        public List<Rack> allRacks = new();
        string hardware_name;
        Stock newStock = new();
        List<Hardware> allHardware = new();

        public AddLocationHardware()
        {
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int popupLeft = (screenWidth - this.Width) / 2;
            int popupTop = (screenHeight - this.Height) / 2;

            // Установка координат для расположения посередине экрана
            this.Left = popupLeft;
            this.Top = popupTop;
        }
        private void AddLocationHardware_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void AddLocationHardware_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private async void AddLocationHardware_Load(object sender, EventArgs e)
        {
            HardwareService hardwareService = new("https://helow19274.ru/aip/api/hardware", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
            allHardware = await hardwareService.GetAllHardwareInfoApi();
            foreach (Hardware hd in allHardware)
            {
                comboBox1.Items.Add(hd.name);
            }
            int number = 1;
            foreach (Rack rk in allRacks)
            {
                comboBox2.Items.Add($"Стеллаж {number} ({rk.width}x{rk.height}см)");
                number++;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hardware_name = comboBox1.SelectedItem.ToString();
            Hardware had = allHardware.Single(hardware => (hardware.name == hardware_name));
            newStock.hardware = had.id;
            int k = comboBox2.SelectedIndex;
            newStock.rack = allRacks[k].id;
            int rackPosit = new();
            int rackCount = new();
            bool v = int.TryParse(textBox1.Text, out rackPosit);
            bool p = int.TryParse(textBox1.Text, out rackCount);
            if (!v || !p)
            {
                MessageBox.Show("Вы ввели некорректные данные");
            }
            else
            {
                newStock.rack_position = rackPosit;
                newStock.count = rackCount;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public Stock ReturnNewStock()
        {
            return newStock;
        }
    }
}
