using Microsoft.VisualBasic.Logging;
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
    public partial class EquipmentAllLocations : Form
    {
        public Hardware hardware = new();
        public EquipmentAllLocations()
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
        private void EquipmentAllLocations_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void EquipmentAllLocations_Load(object sender, EventArgs e)
        {
            if ((hardware.location == null) || (hardware.rack == null) || (hardware.stock == null))
            {
                Panel locPanel = new()
                {
                    Size = new Size(480, 80),
                    BackColor = Color.White,
                };
                NewLabel newPanel = new()
                {
                    Dock = DockStyle.Fill,
                    Text = $"Мест хранения нет",
                    Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                };
                locPanel.Controls.Add(newPanel);
                flowLayoutPanel1.Controls.Add(locPanel);
            }
            else
            {
                foreach (Location loc in hardware.location)
                {
                    int rack_num = 1;
                    List<Rack> racks = hardware.rack;
                    List<Rack> filteredRacks = racks.FindAll(rack => (rack.location == loc.id));
                    foreach (Rack rk in filteredRacks)
                    {
                        List<Stock> stocks = hardware.stock;
                        List<Stock> filteredStocks = stocks.FindAll(stock => (stock.rack == rk.id));
                        foreach (Stock st in filteredStocks)
                        {
                            Panel locPanel = new()
                            {
                                Size = new Size(480, 80),
                                BackColor = Color.White,
                                Location = new Point(0, 0),
                            };
                            NewLabel newPanel = new()
                            {
                                Dock = DockStyle.Fill,
                                Text = $"{loc.name}, стеллаж: {rack_num}, область: {st.rack_position}",
                                Tag1 = hardware.location.IndexOf(loc),
                                Tag2 = hardware.rack.IndexOf(rk),
                                Tag3 = hardware.stock.IndexOf(st)
                            };
                            newPanel.Click += ViewLocationInfo;
                            locPanel.Controls.Add(newPanel);
                            flowLayoutPanel1.Controls.Add(locPanel);
                        }
                        rack_num++;
                    }
                }
            }
        }
        private async void ViewLocationInfo(object sender, EventArgs e)
        {
            NewLabel label = (NewLabel)sender;
            int loc_id = (int)label.Tag1;
            int rk_id = (int)label.Tag2;
            int st_id = (int)label.Tag3;

            EquipmentLocationDetails newForm = new()
            {
                Size = new Size(800, 550)
            };
            this.Hide();

            newForm.hardware = hardware;
            newForm.hardwareStock = hardware.stock[st_id];
            newForm.hardwareLocation = hardware.location[loc_id];
            newForm.hardwareRack = hardware.rack[rk_id];
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

    }
    class NewLabel : Label
    {
        public int Tag1 { get; set; }
        public int Tag2 { get; set; }
        public int Tag3 { get; set; }
    }
}
