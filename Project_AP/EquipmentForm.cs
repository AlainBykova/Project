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
    public partial class EquipmentForm : Form
    {
        RackService rackService = new("https://helow19274.ru/aip/api/rack", "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk");
        public EquipmentForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void EquipmentForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }

        private async void EquipmentForm_Load(object sender, EventArgs e)
        {
            // Получение данных из Tag и использование их
            if (Tag != null)
            {
                int hardware_id = (int)Tag;
                API api = new API();
                try
                {
                    Hardware hardware = await api.GetAllInfoHardware(hardware_id);
                    int height = (int)(flowLayoutPanel1.Height / 7);
                    for (int i = 1; i < 4; i++)
                    {
                        Panel panel = new()
                        {
                            BackColor = Color.White,
                            Margin = new Padding(10),
                            Size = new Size(flowLayoutPanel1.Width, height),
                            Tag = i
                        };

                        Label label = new()
                        {
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill,
                        };
                        switch (panel.Tag)
                        {
                            case 1:
                                label.Text = hardware.name;
                                label.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                            case 2:
                                label.Text = "Тип оборудования: " + hardware.type;
                                label.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
                                label.ForeColor = Color.FromArgb(143, 142, 191);
                                break;
                            case 3:
                                if (string.IsNullOrEmpty(hardware.description))
                                {
                                    label.Text = "Описания нет в базе данных";
                                }
                                else
                                {
                                    label.Text = "Описание: " + hardware.description;
                                }
                                label.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                        }
                        
                        panel.Controls.Add(label);

                        
                        flowLayoutPanel1.Controls.Add(panel);

                    }
                    Button specificationButton = new()
                    {
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.FromArgb(143, 142, 191),
                            Text = "Спецификация",
                            Size = new Size(flowLayoutPanel1.Width, height),
                    };
                    specificationButton.Click += (sender, e) =>
                    {
                        Form popupForm = new Form();
                        popupForm.Size = new System.Drawing.Size(450, 450);
                        popupForm.ShowIcon = false;
                        List<string> specificationItems = new List<string>();
                        if(hardware.specifications != null)
                        {
                            foreach (KeyValuePair<string, int> pair in hardware.specifications)
                            {
                            string key = pair.Key;
                            int value = pair.Value;
                            specificationItems.Add($"{key}: {value}");
                            }
                        }
                        else
                        {
                            specificationItems.Add("Созданной спецификации: 0");
                        }
                        
                        ListBox listBox = new ListBox();
                        listBox.Items.AddRange(specificationItems.ToArray());
                        listBox.Dock = DockStyle.Fill;

                        popupForm.Controls.Add(listBox);

                        // Отображение выплывающей формы над кнопкой
                        popupForm.StartPosition = FormStartPosition.Manual;
                        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                        int popupLeft = (screenWidth - popupForm.Width) / 2;
                        int popupTop = (screenHeight - popupForm.Height) / 2;

                        // Установка координат для расположения посередине экрана
                        popupForm.Left = popupLeft;
                        popupForm.Top = popupTop;
                        popupForm.Show();
                    };
                    flowLayoutPanel1.Controls.Add(specificationButton);
                    Button locationButton = new()
                    {
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(143, 142, 191),
                        Text = "Место положение",
                        Size = new Size(flowLayoutPanel1.Width, height),
                    };
                    flowLayoutPanel1.Controls.Add(locationButton);
                    locationButton.Click += async (sender, e) =>
                    {
                        EquipmentAllLocations newForm = new()
                        {
                            Size = new Size(520, 390)
                        };
                        newForm.hardware = hardware;
                        newForm.Show();
                    };

                    if (!string.IsNullOrEmpty(hardware.image_link))
                    {

                        if (Uri.TryCreate(hardware.image_link, UriKind.Absolute, result: out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                        {
                            using WebClient client = new();
                            try
                            {
                                byte[] imageData = client.DownloadData(uri);
                                using MemoryStream stream = new(imageData);
                                
                                    Image image = Image.FromStream(stream);

                                    pictureBox1.Image = image;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    pictureBox1.BackColor = Color.White;
                                    panel3.BackColor = Color.White;
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }

        }

        private void UsersLabel_MouseEnter(object sender, EventArgs e)
        {
            Label UsersLabel = (Label)sender;
            UsersLabel.BackColor = Color.FromArgb(172, 171, 221);
            UsersLabel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void UsersLabel_MouseLeave(object sender, EventArgs e)
        {
            Label UsersLabel = (Label)sender;
            UsersLabel.BackColor = Color.FromArgb(143, 142, 191);
            UsersLabel.BorderStyle = BorderStyle.None;
        }

        private void StorageLabel_MouseEnter(object sender, EventArgs e)
        {
            Label StorageLabel = (Label)sender;
            StorageLabel.BackColor = Color.FromArgb(172, 171, 221);
            StorageLabel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StorageLabel_MouseLeave(object sender, EventArgs e)
        {
            Label StorageLabel = (Label)sender;
            StorageLabel.BackColor = Color.FromArgb(143, 142, 191);
            StorageLabel.BorderStyle = BorderStyle.None;
        }

        private void UsersLabel_Click(object sender, EventArgs e)
        {
            OpenNewForm();
        }

        private void StorageLabel_Click(object sender, EventArgs e)
        {
            OpenNewForm();
        }

        private static void OpenNewForm()
        {
            ///
        }

        private void EquipmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    Application.Exit();
            //}
        }

        private void Panel2_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
