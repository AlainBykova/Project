using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_AP
{
    public partial class StorageForm : Form
    {
        public StorageForm()
        {
            InitializeComponent();
        }
        private void StorageForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void StorageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    Application.Exit();
            //}
        }

        private async void StorageForm_Load(object sender, EventArgs e)
        {
            // Получение данных из Tag и использование их
            if (Tag != null)
            {
                int loc_id = (int)Tag;

                string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
                string apiUrlLoc = "https://helow19274.ru/aip/api/location";
                LocationService curLocation = new(apiUrlLoc, authorizationToken);
                Location location = await curLocation.GetLocationByIdApi(loc_id);
                label11.Text = location.Name;
                int width = (int)((panel2.Width / location.Width) * 300);
                int height = (int)((panel2.Height / location.Height) * 300);

                panel4.Size = new(width, height);
                int pointX = (int)((panel2.Width - width) / 2);
                int pointY = (int)((panel2.Height - height) / 2);
                panel4.Location = new Point(pointX, pointY);

                string apiUrlRack = "https://helow19274.ru/aip/api/rack";
                string apiUrlStock = "https://helow19274.ru/aip/api/stock";

                RackService rackService = new RackService(apiUrlRack, authorizationToken);
                try
                {
                    List<Rack> racks = await rackService.GetRackInfoUsingLocationIdApi(loc_id);
                    height = (int)(flowLayoutPanel1.Height / 6);
                    if (racks == null)
                    {
                        Panel noHardware = new()
                        {
                            Text = "Оборудования нет",
                            Width = (int)(flowLayoutPanel1.Width * 0.8),
                            Height = (int)(flowLayoutPanel1.Height / 4)
                        };
                        flowLayoutPanel1.Controls.Add(noHardware);
                        return;
                    }
                    foreach (Rack rack in racks)
                    {
                        Panel rackPanel = new()
                        {
                            BackColor = Color.FromArgb(172, 171, 221),
                            BorderStyle = BorderStyle.FixedSingle,
                            Width = rack.Width,
                            Height = rack.Height,
                            Location = new(rack.X, rack.Y),
                            Tag = rack.Id,
                        };
                        panel4.Controls.Add(rackPanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.FromArgb(172, 171, 221);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.White;
        }

        bool isLabelClicked = false;
        private void label1_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (isLabelClicked)
            {
                label.BackColor = Color.White;
                isLabelClicked = false;
            }
            else
            {
                label.BackColor = Color.FromArgb(255, 122, 114);
                isLabelClicked = true;
            }
            //int rack_position = label.Tag;
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

    }
}
