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
using Project_AP;

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
        List<Rack> racks = new();
        List<Stock> allStocks = new();
        
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
        RackService rackService = new("https://helow19274.ru/aip/api/rack", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        StockService stockService = new("https://helow19274.ru/aip/api/stocks", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        HardwareService hardwraeService = new("https://helow19274.ru/aip/api/hardware", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
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
        private async void CreatRack_Click(object sender, EventArgs e)
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
                    location = locationId,
                };

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
                int k = await rackService.CreateNewRackApi(newRack);
                newRack.id = k;
                racks.Add(newRack);
                CreateRackListInPanel(racks);
            }
        }
        private void CreateRackListInPanel(List<Rack> allRacks)
        {
            flowLayoutPanel2.Controls.Clear();
            if (allRacks.Count == 0)
            {
                Panel noRacks = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    Width = (int)(flowLayoutPanel1.Width * 0.8),
                    Height = (flowLayoutPanel1.Height / 4),
                    Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point),
                };
                System.Windows.Forms.Label noRack = new()
                {
                    Text = "Стеллажей нет",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                noRacks.Controls.Add(noRack);
                flowLayoutPanel2.Controls.Add(noRacks);
            }
            else
            {
                int number = 1;
                foreach (Rack item in allRacks)
                {
                    int width = (int)(flowLayoutPanel2.Width * 0.9);
                    int height = (int)(flowLayoutPanel2.Height * 0.2);
                    Panel oneRack = new()
                    {
                        BackColor = Color.White,
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(width, height),
                        Location = new Point((flowLayoutPanel1.Width - width) / 2, height),
                        Tag = item.id
                    };

                    MyCheckBox checkBox = new()
                    {
                        Dock = DockStyle.Left,
                        Tag = item.id,
                    };
                    oneRack.Controls.Add(checkBox);
                    //checkBox.Click += CheckBox_Click;

                    System.Windows.Forms.Label nameLabel = new()
                    {
                        Text = $"Стеллаж: {number} ({item.width}x{item.height})",
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                        Dock = DockStyle.Fill,
                        Tag = item.id
                    };
                    oneRack.Controls.Add(nameLabel);
                    //nameLabel.Click += NameLabel_Click;

                    flowLayoutPanel2.Controls.Add(oneRack);
                    number++;
                }
            }
        }
        private async void CreateHardwareListInPanel(List<Stock> allStock)
        {
            flowLayoutPanel1.Controls.Clear();
            if (allStock.Count == 0)
            {
                Panel noHardware = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    Width = (int)(flowLayoutPanel1.Width * 0.8),
                    Height = (flowLayoutPanel1.Height / 4),
                    Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point),
                };
                System.Windows.Forms.Label noRack = new()
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
               foreach (Stock st in allStock)
                    {
                        API api = new();
                        Hardware hard = await api.GetHardwareByStockIdApi(st.hardware);
                        int width = (int)(flowLayoutPanel1.Width * 0.9);
                        int height = (int)(flowLayoutPanel1.Height * 0.2);
                        Panel oneHardware = new()
                        {
                            BackColor = Color.White,
                            Margin = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle,
                            Size = new Size(width, height),
                            Location = new Point((flowLayoutPanel1.Width - width) / 2, height),
                        };

                        System.Windows.Forms.Label nameLabel = new()
                        {
                            Text = hard.name + "  (" + st.count + ")",
                            Margin = new Padding(5),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                            Dock = DockStyle.Fill,
                            Tag = st.id
                        };
                        nameLabel.Click += oneHardwarePanel_Click;
                        oneHardware.Controls.Add(nameLabel);

                        flowLayoutPanel1.Controls.Add(oneHardware);
                    }
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

        private async void createHardware_Click(object sender, EventArgs e)
        {
            if (racks.Count != 0)
            {
                AddLocationHardware newForm = new()
                {
                    Size = new Size(560, 430)
                };
                newForm.ShowDialog();
                newForm.allRacks = racks;
                if (newForm.DialogResult == DialogResult.OK)
                {
                    Stock newStock = new();
                    newStock = newForm.ReturnNewStock();
                    newForm.Close();
                    int stId = await stockService.CreateNewStockApi(newStock);
                    newStock.id = stId;
                    allStocks.Add(newStock);
                }
            }
        }
    }
}
