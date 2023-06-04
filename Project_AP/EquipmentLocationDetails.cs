using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Project_AP
{
    public partial class EquipmentLocationDetails : Form
    {
        public Hardware hardware = new();
        public Stock hardwareStock = new();
        public Rack hardwareRack = new();
        public Location hardwareLocation = new();
        GetRightSizes getRightSizes = new();
        public EquipmentLocationDetails()
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
        private void EquipmentLocationDetails_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void EquipmentLocationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        bool flag = false;
        private async void EquipmentLocationDetails_Load(object sender, EventArgs e)
        {
            RackService rackService = new("https://helow19274.ru/aip/api/rack", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
            List<Rack> racks = await rackService.GetRackByLocationIdApi(hardwareLocation.id);
            int locWidth = Math.Max(hardwareLocation.width, hardwareLocation.height);
            int locHeight = Math.Min(hardwareLocation.width, hardwareLocation.height);


            if (locWidth == hardwareLocation.height)
            {
                flag = true;
            }
            label10.Text = hardware.name;
            label14.Text = hardwareLocation.name + " (" + ((double)hardwareLocation.width / 100).ToString("F2") + "x" + ((double)hardwareLocation.height / 100).ToString("F2") + "м)";

            List<int> property = getRightSizes.FindNeededSizes((panel1.Width - 20), (panel1.Height - 20), locWidth, locHeight);

            panel6.Size = new(property[0], property[1]);
            int pointX = (int)((panel1.Width - property[0]) / 2);
            int pointY = (int)((panel1.Height - property[1]) / 2);
            panel6.Location = new Point(pointX, pointY);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Padding = new(4);

            int number = 1;
            foreach (Rack rack in racks)
            {
                Panel rackPanel = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new(rack.x, rack.y),
                };
                if (rack.id == hardwareRack.id)
                {
                    rackPanel.BackColor = Color.FromArgb(255, 122, 114);
                    label15.Text = $"{number} ({rack.width}x{rack.height} см)";
                }
                property.Clear();
                property = getRightSizes.FindNeededSizes2(panel6.Width, panel6.Height, locWidth, locHeight, rack.width, rack.height, flag);
                rackPanel.Size = new(property[0], property[1]);

                property = getRightSizes.FindNeededSizes2(panel6.Width, panel6.Height, locWidth, locHeight, rack.x, rack.y, flag);
                rackPanel.Location = new(property[0], property[1]);
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(rackPanel, $"Стеллаж: {number} ({rack.width}x{rack.height}см)");

                panel6.Controls.Add(rackPanel);
                number++;
            }
            foreach (Control c in tableLayoutPanel6.Controls)
            {
                if (int.Parse(c.Text) == hardwareStock.rack_position)
                {
                    c.BackColor = Color.FromArgb(255, 122, 114);
                    break;
                }
            }
            label16.Text = hardwareStock.rack_position + " (Кол-во: " + hardwareStock.count + ")";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
