using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace Project_AP
{
    public partial class UsersListForm : Form
    {

        public UsersListForm()
        {
            InitializeComponent();
            int width = MenuPanel.Width / 3;
            UsersLabel.Size = new Size(width, MenuPanel.Height);
            StorageLabel.Size = EquipmentLabel.Size = UsersLabel.Size;
            StorageLabel.Location = new Point(0, 0);
            EquipmentLabel.Location = new Point(width, 0);
            UsersLabel.Location = new Point(2 * width, 0);

            IconPanel.Height = IconPanel.Width = SearchPanel.Height;
            SearchButton.Width = AddButton.Width = DeleteButton.Width = SearchPanel.Width / 5;

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
                List<User> list = await userService.GetUsersApi(searchQuery);

                UsersList.Controls.Clear();
                // Do something with the filtered users
                if (list.Count > 0)
                {
                    foreach (User item in list)
                    {
                        int width = (int)(UsersList.Width * 0.8);
                        int height = UsersList.Height / 4;
                        Panel panel = new()
                        {
                            BackColor = UsersList.BackColor,
                            Margin = new Padding(5),
                            Size = new Size(width, height),
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right)
                        };
                        UsersList.Controls.Add(panel);

                        CheckBox check = new();
                        Panel userDataPanel = new();
                        panel.Controls.Add(userDataPanel);
                        panel.Controls.Add(check);
                        check.Dock = DockStyle.Left;
                        userDataPanel.Dock = DockStyle.Fill;

                        Button userDataButton = new()
                        {
                            BackColor = Color.FromArgb(143, 142, 191),
                        };
                        userDataPanel.Controls.Add(userDataButton);
                        userDataButton.Dock = DockStyle.Right;

                        Label nameLabel = new()
                        {
                            Text = item.First_name + " " + item.Last_name + " " + item.Patronymic,
                            AutoSize = true
                        };
                        userDataPanel.Controls.Add(nameLabel);
                        nameLabel.Dock = DockStyle.Fill;
                    }
                }
                else
                {
                    Panel noUsers = new()
                    {
                        BackColor = Color.White
                    };
                    UsersList.Controls.Add(noUsers);

                    Label noUsersLabel = new()
                    {
                        Text = "По вашему запросу ничего не найдено",
                        Margin = new Padding(10),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    noUsers.Controls.Add(noUsersLabel);
                    noUsersLabel.Dock = DockStyle.Fill;

                    int width = (int)(UsersList.Width * 0.8);
                    int height = UsersList.Height / 4;
                    noUsers.Size = new Size(width, height);
                    //noUsers.Location = new Point((UsersList.Width - noUsers.Width) / 2, UsersList.Height / 4);
                    //noUsers.Dock = DockStyle.Fill;

                    noUsersLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public class UserService
        {
            private readonly HttpClient httpClient;
            private readonly string apiUrl;
            private readonly string authorizationToken;

            public UserService(string apiUrl, string authorizationToken)
            {
                httpClient = new HttpClient();
                this.apiUrl = apiUrl;
                this.authorizationToken = authorizationToken;
            }

            public async Task<List<User>> GetUsersApi(string searchString)
            {
                // Set the authorization header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));

                // Make the API request to retrieve all users
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse the response and extract the list of users
                    List<User> allUsers = ParseUserResponse(responseBody);

                    // Filter the users based on the search string
                    List<User> filteredUsers = allUsers.FindAll(user => (user.First_name.Contains(searchString)));

                    return filteredUsers;
                }
                else
                {
                    // Handle the case when the API request fails
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
                }
            }

            private static List<User> ParseUserResponse(string responseBody)
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

                List<User> users = new();

                foreach (dynamic userJson in responseJson)
                {
                    string f_name = userJson.first_name;
                    string l_name = userJson.last_name;
                    string patronymic = userJson.patronymic;

                    User user = new()
                    {
                        First_name = f_name,
                        Last_name = l_name,
                        Patronymic = patronymic
                    };

                    users.Add(user);
                }

                return users;
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchButton_Click(sender, e);
        }
    }
    public class User
    {
        public bool Active { get; set; }
        public string Type { get; set; }

        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Patronymic { get; set; }
        public string Image_link { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Card_id { get; set; }
        public string Card_key { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
    }
}
