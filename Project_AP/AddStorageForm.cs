using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Project_AP
{
    public partial class AddStorageForm : Form
    {
        string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
        string apiUrlLoc = "https://helow19274.ru/aip/api/location";
        string apiUrlRack = "https://helow19274.ru/aip/api/rack";
        string apiUrlStock = "https://helow19274.ru/aip/api/stock";

        int locationWidth;
        int locationHeight;
        string locationName;
        int locationId;
        List<Rack> racks;
        public AddStorageForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void AddStorageForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void AddStorageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        GetRightSizes getRightSizes = new();
        bool flag = false;
        private async void AddStorageForm_Load(object sender, EventArgs e)
        {
            AddLocationInfo popupForm = new()
            {
                Size = new Size(600, 500),
            };
            popupForm.ShowDialog();
            if (popupForm.DialogResult == DialogResult.OK)
            {
                locationName = popupForm.GetLocName();
                locationWidth = popupForm.GetLocWidth();
                locationHeight = popupForm.GetLocHeight();
            }
            else
            {
                StorageListForm newForm = new()
                {
                    Size = this.Size
                };
                this.Hide();
                newForm.ShowDialog();
                this.Close();
            }

            LocationService curLocation = new(apiUrlLoc, authorizationToken);
            Location location = new()
            {
                width = locationWidth,
                height = locationHeight,
                name = locationName
            };
            locationId = await curLocation.CreateNewLocationApi(location);

            int locWidth = Math.Max(location.width, location.height);
            int locHeight = Math.Min(location.width, location.height);

            if (locWidth == location.height)
            {
                flag = true;
            }

            label11.Text = location.name + " (" + ((double)location.width / 100).ToString("F2") + "x" + ((double)location.height / 100).ToString("F2") + "м)";
            List<int> property = getRightSizes.FindNeededSizes((panel2.Width - 20), (panel2.Height - 20), locWidth, locHeight);

            panel4.Size = new(property[0], property[1]);
            int pointX = (int)((panel2.Width - property[0]) / 2);
            int pointY = (int)((panel2.Height - property[1]) / 2);
            panel4.Location = new Point(pointX, pointY);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Padding = new(4);

        }

        private async void RackPanel_Click(object? sender, EventArgs e)
        {

        }
        private void oneHardwarePanel_Click(object sender, EventArgs e)
        {

        }
        private void panel3_Click(object sender, EventArgs e)
        {
            StorageListForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
        private void CreatRack_Click(object sender, EventArgs e)
        {
            AddRackInfo popupForm = new()
            {
                Size = new Size(600, 500),
            };
            popupForm.ShowDialog();
            popupForm.locWidth = locationWidth;
            popupForm.locHeight = locationHeight;

            if (popupForm.DialogResult == DialogResult.OK)
            {
                Rack newRack = new()
                {
                    x = popupForm.GetRackX(),
                    y = popupForm.GetRackY(),
                    width = popupForm.GetRackWidth(),
                    height = popupForm.GetRackHeight(),
                };
                racks.Add(newRack);
                Panel rackPanel = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new(newRack.x, newRack.y),
                    Tag = newRack.id,
                };
                List<int> property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, locationWidth, locationHeight, newRack.width, newRack.height, flag);
                rackPanel.Size = new(property[0], property[1]);

                property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, locationWidth, locationHeight, newRack.x, newRack.y, flag);
                rackPanel.Location = new(property[0], property[1]);
                rackPanel.Click += RackPanel_Click;

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(rackPanel, $"Стеллаж: {newRack.id} ({newRack.width}x{newRack.height}см)");

                panel4.Controls.Add(rackPanel);
            }
        }
        private void CreatRack_MouseEnter(object sender, EventArgs e)
        {
            CreatRack.BackColor = Color.FromArgb(255, 122, 114);
        }
        private void CreatRack_MouseLeave(object sender, EventArgs e)
        {
            CreatRack.BackColor = Color.FromArgb(143, 142, 191);
        }
        private void createHardware_MouseEnter(object sender, EventArgs e)
        {
            createHardware.BackColor = Color.FromArgb(255, 122, 114);
        }

        private void createHardware_MouseLeave(object sender, EventArgs e)
        {
            createHardware.BackColor = Color.FromArgb(143, 142, 191);
        }
    }
}
