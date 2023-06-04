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
        List<Hardware> allHardware = new();
        public List<Rack> allRacks = new();
        public List<Stock> allStocks = new();
        GetRightSizes getRightSizes = new();
        Location location = new();
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

        }
        StockService stockService = new("https://helow19274.ru/aip/api/stocks", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        RackService rackService = new("https://helow19274.ru/aip/api/rack", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        LocationService curLocation = new("https://helow19274.ru/aip/api/location", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        private async void StorageForm_Load(object sender, EventArgs e)
        {
            // Получение данных из Tag и использование их
            if (this.Tag != null)
            {
                int loc_id = (int)this.Tag;

                location = await curLocation.GetLocationByIdApi(loc_id);

                int locWidth = Math.Max(location.width, location.height);
                int locHeight = Math.Min(location.width, location.height);

                bool flag = false;
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

                try
                {
                    allRacks = await rackService.GetRackByLocationIdApi(loc_id);
                    int height = (int)(flowLayoutPanel1.Height / 6);
                    int number = 1;
                    if (allRacks.Count == 0)
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
                        return;
                    }
                    else
                    {
                        API api = new();
                        foreach (Rack rack in allRacks)
                        {
                        Panel rackPanel = new()
                        {
                            BackColor = Color.FromArgb(172, 171, 221),
                            BorderStyle = BorderStyle.FixedSingle,
                            Location = new(rack.x, rack.y),
                            Tag = rack.id,
                        };
                        property.Clear();
                        property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, locWidth, locHeight, rack.width, rack.height, flag);
                        rackPanel.Size = new(property[0], property[1]);

                        property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, locWidth, locHeight, rack.x, rack.y, flag);
                        rackPanel.Location = new(property[0], property[1]);
                        rackPanel.Click += RackPanel_Click;

                        ToolTip toolTip = new ToolTip();
                        toolTip.SetToolTip(rackPanel, $"Стеллаж: {number} ({rack.width}x{rack.height}см)");

                        panel4.Controls.Add(rackPanel);
                        number++;
                        }
                    allHardware = await api.GetHardwareByLocationIdApi(loc_id);
                    CreateHardwareListInPanel(allHardware);
                    CreateRackListInPanel(allRacks);
                    allStocks = await api.GetStocksForRackList(allRacks);
                    if(allStocks.Count == 0)
                        {
                            MessageBox.Show($"Данные не получены");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
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
                Label noRack = new()
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
                    checkBox.Click += CheckBox_Click;

                    Label nameLabel = new()
                    {
                        Text = $"Стеллаж: {number} ({item.width}x{item.height})",
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                        Dock = DockStyle.Fill,
                        Tag = item.id
                    };
                    oneRack.Controls.Add(nameLabel);
                    nameLabel.Click += NameLabel_Click;

                    flowLayoutPanel2.Controls.Add(oneRack);
                    number++;
                }
            }
        }

        private void NameLabel_Click(object? sender, EventArgs e)
        {
            Label label = (Label)sender;
            int rack_id = (int)label.Tag;
            List<Hardware> hardwares = new();
            foreach (Hardware hardware in allHardware)
            {
                foreach (Rack item in hardware.rack)
                {
                    if (item.id == rack_id)
                    {
                        hardwares.Add(hardware);
                    }
                }
            }
            CreateHardwareListInPanel(hardwares);
        }

        private void RackPanel_Click(object? sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            int rack_id = (int)panel.Tag;
            List<Hardware> hardwares = new();
            foreach (Hardware hardware in allHardware)
            {
                foreach (Rack item in hardware.rack)
                {
                    if (item.id == rack_id)
                    {
                        hardwares.Add(hardware);
                    }
                }
            }
            CreateHardwareListInPanel(hardwares);
        }

        private void CheckBox_Click(object? sender, EventArgs e)
        {
            //
        }

        private async void CreateHardwareListInPanel(List<Hardware> allHardware)
        {
            flowLayoutPanel1.Controls.Clear();
            if (allHardware.Count == 0)
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
                    foreach (Stock st in item.stock)
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
                        };

                        Label nameLabel = new()
                        {
                            Text = item.name + "  (" + st.count + ")",
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
        }
        private async void oneHardwarePanel_Click(object sender, EventArgs e)
        {
            //Label label = (Label)sender;
            //int stock_id = (int)label.Tag;
            //EquipmentLocationDetails newForm = new()
            //{
            //    Size = new Size(800, 550)
            //};
            //this.Hide();

            //Stock neededStock = new();
            //neededStock = await stockService.GetStockByIdApi(stock_id);

            //Rack neededRack = new();
            //neededRack = allRacks.SingleOrDefault(rack => (rack.id == neededStock.rack));
            //if (neededRack == null)
            //{
            //    MessageBox.Show($"Данные не получены neededRack");
            //    return;
            //}
            //API api = new API();
            //Hardware newHardware = await api.GetAllInfoHardware(neededStock.hardware);
            //if(newHardware == null)
            //{
            //    MessageBox.Show($"Данные не получены newHardware");
            //    return;
            //}
            //Location loc = location;
            //newForm.hardware = newHardware;
            //newForm.hardwareLocation = loc;
            //newForm.hardwareStock = neededStock;
            //newForm.hardwareRack = neededRack;
            //newForm.ShowDialog();

            //if (newForm.DialogResult == DialogResult.OK)
            //{
            //    newForm.Close();
            //}
        }
        bool flag = false;
        private void panel3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            AddRackInfo popupForm = new()
            {
                Size = new Size(600, 500),
            };
            popupForm.ShowDialog();
            popupForm.locWidth = location.width;
            popupForm.locHeight = location.height;

            if (popupForm.DialogResult == DialogResult.OK)
            {
                Rack newRack = new()
                {
                    x = popupForm.GetRackX(),
                    y = popupForm.GetRackY(),
                    width = popupForm.GetRackWidth(),
                    height = popupForm.GetRackHeight(),
                    location = location.id
                };
                Panel rackPanel = new()
                {
                    BackColor = Color.FromArgb(172, 171, 221),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new(newRack.x, newRack.y),
                    Tag = newRack.id,
                };
                List<int> property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, location.width, location.height, newRack.width, newRack.height, flag);
                rackPanel.Size = new(property[0], property[1]);

                property = getRightSizes.FindNeededSizes2(panel4.Width, panel4.Height, location.width, location.height, newRack.x, newRack.y, flag);
                rackPanel.Location = new(property[0], property[1]);
                rackPanel.Click += RackPanel_Click;

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(rackPanel, $"Стеллаж: {newRack.id} ({newRack.width}x{newRack.height}см)");

                panel4.Controls.Add(rackPanel);
                int k = await rackService.CreateNewRackApi(newRack);
                newRack.id = k;
                allRacks.Add(newRack);
                CreateRackListInPanel(allRacks);
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if(allRacks.Count != 0)
            {
            AddLocationHardware newForm = new()
            {
                Size = new Size(560, 430)
            };
            newForm.ShowDialog();
            newForm.allRacks = allRacks;
            if(newForm.DialogResult == DialogResult.OK)
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
