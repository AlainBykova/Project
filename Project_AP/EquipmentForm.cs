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

                //string apiUrl = "https://helow19274.ru/aip/api/hardware";
                //string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
                //HardwareService hardwareService = new(apiUrl, authorizationToken);
                API api = new API();
                try
                {
                    Hardware hardware = await api.GetAllInfoHardware(hardware_id);
                    int height = (int)(flowLayoutPanel1.Height / 6);
                    for (int i = 1; i < 5; i++)
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
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill,
                        };
                        switch (panel.Tag)
                        {
                            case 1:
                                label.Text = hardware.Name;
                                label.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                            case 2:
                                label.Text = hardware.Type;
                                label.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                                label.ForeColor = Color.FromArgb(143, 142, 191);
                                break;
                            case 3:
                                if (string.IsNullOrEmpty(hardware.Description))
                                {
                                    label.Text = "Описания нет в базе данных";
                                }
                                else
                                {
                                    label.Text = hardware.Description;
                                }
                                label.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                            case 4:
                                label.Text = hardware.Rack + " " + hardware.Stock + " " + hardware.Location;
                                label.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                                label.ForeColor = Color.FromArgb(143, 142, 191);
                                break;
                        }
                        panel.Controls.Add(label);

                        flowLayoutPanel1.Controls.Add(panel);

                    }

                    if (!string.IsNullOrEmpty(hardware.Image_link))
                    {

                        if (Uri.TryCreate(hardware.Image_link, UriKind.Absolute, result: out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
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
