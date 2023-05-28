﻿using System;
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
    public partial class EquipmentListForm : Form
    {
        public EquipmentListForm()
        {
            InitializeComponent();
            tableLayoutPanel5.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        }

        private void UsersListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UsersListForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text;

            string apiUrl = "https://helow19274.ru/aip/api/user";
            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            UserService userService = new(apiUrl, authorizationToken);

            try
            {
                // Call GetUsersByName method and provide the search string
                List<User> list = await userService.GetUsersNameApi(searchQuery);

                UsersList.Controls.Clear();
                // Do something with the filtered users
                if (list.Count > 0)
                {
                    foreach (User item in list)
                    {
                        int width = (int)(UsersList.Width * 0.9);
                        int height = (int)(UsersList.Height * 0.2);
                        Panel ManyUsers = new()
                        {
                            BackColor = Color.White,
                            Margin = new Padding(20),
                            Size = new Size(width, height),
                            Location = new Point((UsersList.Width - width) / 2, height + 10),
                            Anchor = AnchorStyles.None,
                            Dock = DockStyle.None
                        };

                        int checkWidth = (int)(height * 0.8);
                        CheckBox checkBox = new()
                        {
                            Size = new Size(checkWidth, checkWidth),
                            Dock = DockStyle.Left
                        };
                        ManyUsers.Controls.Add(checkBox);

                        int buttonWidth = (int)(width * 0.2);
                        Button detailsButton = new()
                        {
                            Text = "Подробнее",
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(buttonWidth, checkWidth),
                            BackColor = Color.FromArgb(143, 142, 191),
                            Dock = DockStyle.Right,
                            Tag = item,
                        };
                        detailsButton.Click += DetailsButton_Click;
                        ManyUsers.Controls.Add(detailsButton);

                        Label nameLabel = new()
                        {
                            Text = item.First_name + " " + item.Last_name + " " + item.Patronymic,
                            Margin = new Padding(10),
                            TextAlign = ContentAlignment.MiddleCenter,
                            //AutoSize = true,
                            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point),
                            Dock = DockStyle.Fill
                        };
                        ManyUsers.Controls.Add(nameLabel);

                        UsersList.Controls.Add(ManyUsers);
                    }
                }
                else
                {
                    int width = (int)(UsersList.Width * 0.9);
                    int height = (int)(UsersList.Height * 0.2);
                    int loc = (int)((UsersList.Width - width) / 2);
                    Panel noUsers = new()
                    {
                        BackColor = Color.White,
                        Padding = new Padding(10),
                        Size = new Size(width, height),
                        Location = new Point(loc, height + 10)
                    };

                    Label noUsersLabel = new()
                    {
                        Text = "По вашему запросу ничего не найдено",
                        Margin = new Padding(10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point),
                        Dock = DockStyle.Fill
                    };
                    noUsers.Controls.Add(noUsersLabel);

                    UsersList.Controls.Add(noUsers);
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
            User participant = (User)button.Tag;

            /// открывается окно с инфо
        }
        private void EquipmentListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
