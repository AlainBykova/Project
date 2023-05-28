using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_AP
{
    public partial class UserDetailsForm : Form
    {
        public UserDetailsForm()
        {
            InitializeComponent();
        }
        private void UserDetailsForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }

        private async void UserDetailsForm_Load(object sender, EventArgs e)
        {
            // Получение данных из Tag и использование их
            if (Tag != null)
            {
                int user_id = (int)Tag;

                string apiUrl = "https://helow19274.ru/aip/api/user/" + user_id;
                string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
                UserService userService = new(apiUrl, authorizationToken);

                try
                {
                    User user = await userService.GetUserByIdApi();
                    int height = (int)(flowLayoutPanel1.Height / 8);
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
                                label.Text = user.First_name + " " + user.Last_name + " " + user.Patronymic;
                                label.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                            case 2:
                                label.Text = user.Email;
                                label.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                                label.ForeColor = Color.FromArgb(143, 142, 191);
                                break;
                            case 3:
                                if (string.IsNullOrEmpty(user.PhoneNumber))
                                {
                                    label.Text = "Номера телефона нет в базе данных";
                                }
                                else
                                {
                                    label.Text = user.PhoneNumber;
                                }
                                label.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                            case 4:
                                if (string.IsNullOrEmpty(user.Type))
                                {
                                    label.Text = "Необходимых данных о состоянии пользователя нет";
                                }
                                else
                                {
                                    label.Text = user.Type;
                                }
                                label.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
                                break;
                        }
                        panel.Controls.Add(label);

                        flowLayoutPanel1.Controls.Add(panel);

                    }

                    if (!string.IsNullOrEmpty(user.Image_link))
                    {

                        if (Uri.TryCreate(user.Image_link, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    byte[] imageData = client.DownloadData(uri);
                                    using (var stream = new System.IO.MemoryStream(imageData))
                                    {
                                        Image image = Image.FromStream(stream);

                                        pictureBox1.Image = image;
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
                                }
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
        private void EquipmentLabel_MouseEnter(object sender, EventArgs e)
        {
            Label EquipmentLabel = (Label)sender;
            EquipmentLabel.BackColor = Color.FromArgb(172, 171, 221);
            EquipmentLabel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void EquipmentLabel_MouseLeave(object sender, EventArgs e)
        {
            Label EquipmentLabel = (Label)sender;
            EquipmentLabel.BackColor = Color.FromArgb(143, 142, 191);
            EquipmentLabel.BorderStyle = BorderStyle.None;
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

        private void EquipmentLabel_Click(object sender, EventArgs e)
        {
            openNewForm();
        }

        private void StorageLabel_Click(object sender, EventArgs e)
        {
            openNewForm();
        }

        private void openNewForm()
        {
            ///
        }

        private void UserDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
