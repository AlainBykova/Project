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
    public partial class StorageListForm : Form
    {
        List<int> CheckBoxTag = new();
        string apiUrl = "https://helow19274.ru/aip/api/location";
        string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
        public StorageListForm()
        {
            InitializeComponent();
            tableLayoutPanel5.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        private void StorageListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void StorageListForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text;

            LocationService locationService = new(apiUrl, authorizationToken);

            try
            {
                // Call GetUsersByName method and provide the search string
                List<Location> list = await locationService.GetLocationInfoApi(searchQuery);

                LocationList.Controls.Clear();
                // Do something with the filtered users
                if (list.Count > 0)
                {
                    foreach (Location item in list)
                    {
                        int width = (int)(LocationList.Width * 0.9);
                        int height = (int)(LocationList.Height * 0.2);
                        Panel ManyLocations = new()
                        {
                            BackColor = Color.White,
                            Margin = new Padding(20),
                            Size = new Size(width, height),
                            Location = new Point((LocationList.Width - width) / 2, height + 10),
                            Anchor = AnchorStyles.None,
                            Dock = DockStyle.None
                        };

                        int checkWidth = (int)(height * 0.8);
                        MyCheckBox checkBox = new()
                        {
                            //Size = new Size(checkWidth, checkWidth),
                            Dock = DockStyle.Left,
                            Tag = item.Id,
                        };
                        ManyLocations.Controls.Add(checkBox);
                        checkBox.Click += CheckBox_Click;

                        int buttonWidth = (int)(width * 0.2);
                        Button detailsButton = new()
                        {
                            Text = "Подробнее",
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(buttonWidth, checkWidth),
                            BackColor = Color.FromArgb(143, 142, 191),
                            Dock = DockStyle.Right,
                            Tag = item.Id,
                        };
                        detailsButton.Click += DetailsButton_Click;
                        ManyLocations.Controls.Add(detailsButton);

                        Label nameLabel = new()
                        {
                            Text = item.Name,
                            Margin = new Padding(10),
                            TextAlign = ContentAlignment.MiddleCenter,
                            //AutoSize = true,
                            Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point),
                            Dock = DockStyle.Fill
                        };
                        ManyLocations.Controls.Add(nameLabel);

                        LocationList.Controls.Add(ManyLocations);
                    }
                }
                else
                {
                    int width = (int)(LocationList.Width * 0.9);
                    int height = (int)(LocationList.Height * 0.2);
                    int loc = (int)((LocationList.Width - width) / 2);
                    Panel noLoc = new()
                    {
                        BackColor = Color.White,
                        Padding = new Padding(10),
                        Size = new Size(width, height),
                        Location = new Point(loc, height + 10)
                    };

                    Label noLocLabel = new()
                    {
                        Text = "По вашему запросу ничего не найдено",
                        Margin = new Padding(10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point),
                        Dock = DockStyle.Fill
                    };
                    noLoc.Controls.Add(noLocLabel);

                    LocationList.Controls.Add(noLoc);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchButton_Click(sender, e);
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int loc_id = (int)button.Tag;

            StorageForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.Tag = loc_id;
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
            {
                this.Show();
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

        private void UsersLabel_Click(object sender, EventArgs e)
        {
            UsersListForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
        private void EquipmentLabel_Click(object sender, EventArgs e)
        {
            EquipmentListForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
        private void CheckBox_Click(object sender, EventArgs e)
        {
            MyCheckBox cb = (MyCheckBox)sender;
            int loc_id = (int)cb.Tag;
            if (cb.Checked)
            {
                cb.ForeColor = Color.FromArgb(255, 122, 114);
                CheckBoxTag.Add(loc_id);
            }
            else
            {
                cb.ForeColor = Color.White;
                CheckBoxTag.Remove(loc_id);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CheckBoxTag.Count != 0)
            {
                foreach (int id in CheckBoxTag)
                {
                    LocationService loc = new(apiUrl, authorizationToken);
                    loc.DeleteLocationApi(id);
                }
                CheckBoxTag.Clear();
                LocationList.Controls.Clear();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddStorageForm newForm = new()
            {
                Size = this.Size
            };
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
    }
    class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            this.TextAlign = ContentAlignment.MiddleRight;
        }
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int h = this.ClientSize.Height - 2;
            Rectangle rc = new Rectangle(new Point(0, 1), new Size(h, h));
            ControlPaint.DrawCheckBox(e.Graphics, rc,
                this.Checked ? ButtonState.Checked : ButtonState.Normal);
        }
    }
}
