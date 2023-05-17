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
    public partial class UsersListForm : Form
    {

        public UsersListForm()
        {
            InitializeComponent();
            UsersLabel.Size = new Size(MenuPanel.Width / 3, MenuPanel.Height);
            StorageLabel.Size = EquipmentLabel.Size = UsersLabel.Size;

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text;

            var results = SearchUsersApi(searchQuery);
            if (results == null)
            {
                UsersList.Text = string.Empty;
            }
            else
            {
                UsersList.Items.Clear();
                UsersList.Items.AddRange(results.ToArray());
            }
        }

        private static void SearchUsersApi(string searchQuery)
        {
            // Implement your API request logic here
            // Use an HTTP client to make a request to the API
            // Parse the response and extract the search results
            // Return the search results as a list of strings
            // For demonstration purposes, let's assume we get a list of strings from the API
            await Task.Delay(1000); // Simulating API request delay
            return new List<string> { "Result 1", "Result 2", "Result 3" };
        }
        
    }
    public class User
        {
            public int Id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string patronymic { get; set; }
            public string type { get; set; }
            public bool active { get; set; }
            
            public string PhoneNumber { get; set; }
        }
}
