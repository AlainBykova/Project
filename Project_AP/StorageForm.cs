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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Project_AP;

namespace Project_AP
{
    public partial class StorageForm : Form
    {
        public StorageForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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

                int locWidth = Math.Max(location.Width, location.Height);
                int locHeight = Math.Min(location.Width, location.Height);

                bool flag = false;
                if(locWidth == location.Height)
                {
                    flag = true;
                }

                label11.Text = location.Name + " (" + ((double)location.Width/100).ToString("F2") + "x" + ((double)location.Height/100).ToString("F2") + "м)";
                List<int> property = FindNeededSizes((panel2.Width-20), (panel2.Height-20), locWidth, locHeight);

                panel4.Size = new(property[0], property[1]);
                int pointX = (int)((panel2.Width - property[0]) / 2);
                int pointY = (int)((panel2.Height - property[1]) / 2);
                panel4.Location = new Point(pointX, pointY);
                panel4.BorderStyle = BorderStyle.FixedSingle;
                panel4.Padding = new(4);

                string apiUrlRack = "https://helow19274.ru/aip/api/rack";
                string apiUrlStock = "https://helow19274.ru/aip/api/stock";

                RackService rackService = new RackService(apiUrlRack, authorizationToken);
                try
                {
                    List<Rack> racks = await rackService.GetRackInfoUsingLocationIdApi(loc_id);
                    int height = (int)(flowLayoutPanel1.Height / 6);
                    if (racks.Count == 0)
                    {
                        Panel noHardware = new()
                        {
                            BackColor = Color.FromArgb(172, 171, 221),
                            Width = (int)(flowLayoutPanel1.Width * 0.8),
                            Height = (flowLayoutPanel1.Height / 4),
                            Font = new Font("Segoe UI",20F,FontStyle.Regular,GraphicsUnit.Point),
                        };
                        Label noRack = new()
                        {
                            Text = "Оборудования нет",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                        };
                        noHardware.Controls.Add(noRack);
                        flowLayoutPanel1.Controls.Add(noHardware);
                        return;
                    }
                    foreach (Rack rack in racks)
                    {
                        Panel rackPanel = new()
                        {
                            BackColor = Color.FromArgb(172, 171, 221),
                            BorderStyle = BorderStyle.FixedSingle,
                            Location = new(rack.X, rack.Y),
                            Tag = rack.Id,
                        };
                        property.Clear();
                        property = FindNeededSizes2(panel4.Width, panel4.Height, locWidth, locHeight, rack.Width, rack.Height, flag);
                        rackPanel.Size = new(property[0], property[1]);

                        property = FindNeededSizes2(panel4.Width, panel4.Height, locWidth, locHeight, rack.X, rack.Y, flag);
                        rackPanel.Location = new(property[0], property[1]);
                        rackPanel.Click += RackPanel_Click;

                        ToolTip toolTip = new ToolTip();
                        toolTip.SetToolTip(rackPanel, $"Стеллаж: {rack.Id} ({rack.Width}x{rack.Height}см)");

                        panel4.Controls.Add(rackPanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }
        }

        private async void RackPanel_Click(object? sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            int rack_id = (int)panel.Tag;
            API api = new();
            List<Hardware> allHardware = await api.GetHardwareByRackIdApi(rack_id);
            flowLayoutPanel1.Controls.Clear();
            if(allHardware.Count == 0)
            {
                Panel noHardware = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    Width = (int)(flowLayoutPanel1.Width * 0.8),
                    Height = (flowLayoutPanel1.Height / 4),
                    Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point),
                };
                Label noRack = new()
                {
                    Text = "Оборудования нет",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                noHardware.Controls.Add(noRack);
                flowLayoutPanel1.Controls.Add(noHardware);
            }
            else
            {
                foreach (Hardware item in allHardware)
                {
                    int width = (int)(flowLayoutPanel1.Width * 0.9);
                    int height = (int)(flowLayoutPanel1.Height * 0.2);
                    Panel oneHardware = new()
                    {
                        BackColor = Color.White,
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(width, height),
                        Location = new Point((flowLayoutPanel1.Width - width) / 2, height),
                        Tag = item.Id
                    };
                    oneHardware.Click += oneHardwarePanel_Click;

                    Label nameLabel = new()
                    {
                        Text = item.Name + "  (" + item.Count + ")",
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                        Dock = DockStyle.Fill
                    };
                    oneHardware.Controls.Add(nameLabel);

                    flowLayoutPanel1.Controls.Add(oneHardware);
                }
            }
        }
        private void oneHardwarePanel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            EquipmentForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.Tag = (int)panel.Tag;
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }
        bool flag = false;
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if(flag == false)
            {
                label.BackColor = Color.FromArgb(172, 171, 221);
            }
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if(flag == false)
            {
                label.BackColor = Color.White;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (flag == false)
            {
                label.BackColor = Color.FromArgb(255, 122, 114);
                flag = true;
            }
            else
            {
                label.BackColor = Color.White;
                flag = false;
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
