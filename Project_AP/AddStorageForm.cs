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
        private List<int> FindNeededSizes(int parentWidth, int parentHeight, int childWidth, int childHeight)
        {
            List<int> properties = new();

            double width = ((double)parentWidth / childWidth);
            double height = ((double)parentHeight / childHeight);
            double minValue = Math.Min(width, height);
            int widthLoc = (int)Math.Round(childWidth * minValue);
            int heightLoc = (int)Math.Round(childHeight * minValue);
            properties.Add(widthLoc);
            properties.Add(heightLoc);
            return properties;
        }
        private List<int> FindNeededSizes2(int panelWidth, int panelHeight, int truepanelWidth, int truepanelHeight, int rW, int rH, bool flag)
        {
            int rackWidth;
            int rackHeight;
            if (flag == true)
            {
                rackWidth = rH;
                rackHeight = rW;
            }
            else
            {
                rackWidth = rW;
                rackHeight = rH;
            }
            int width1 = (int)(((double)rackWidth / truepanelWidth) * panelWidth);
            int height1 = (int)(((double)rackHeight / truepanelHeight) * panelHeight);
            List<int> prop = new();
            prop.Add(width1);
            prop.Add(height1);
            return prop;
        }

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
                Width = locationWidth,
                Height = locationHeight,
                Name = locationName
            };
            locationId = await curLocation.CreateNewLocationApi(location);

            int locWidth = Math.Max(location.Width, location.Height);
            int locHeight = Math.Min(location.Width, location.Height);
            bool flag = false;
            if (locWidth == location.Height)
            {
                flag = true;
            }

            label11.Text = location.Name + " (" + ((double)location.Width / 100).ToString("F2") + "x" + ((double)location.Height / 100).ToString("F2") + "м)";
            List<int> property = FindNeededSizes((panel2.Width - 20), (panel2.Height - 20), locWidth, locHeight);

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
            if (popupForm.DialogResult == DialogResult.OK)
            {
                Rack newRack = new()
                {
                    X = popupForm.GetRackX(),
                    Y = popupForm.GetRackY(),
                    Width = popupForm.GetRackWidth(),
                    Height = popupForm.GetRackHeight(),
                };
                racks.Add(newRack);

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
            CreatRack.BackColor = Color.FromArgb(255, 122, 114);
        }

        private void createHardware_MouseLeave(object sender, EventArgs e)
        {
            CreatRack.BackColor = Color.FromArgb(143, 142, 191);
        }
    }
}
