using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Reflection.Emit;

namespace Project_AP
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Inter-Regular.ttf", 12F, FontStyle.Regular, GraphicsUnit.Point);

            Screen screen = Screen.PrimaryScreen;
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            this.Size = new Size(screenWidth, screenHeight);

        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.WrongPasswordLabel.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && LoginField.Text == "Admin123")
            {
                UsersListForm newForm = new UsersListForm();
                newForm.Size = this.Size;
                newForm.Show();
                this.Hide();
            }
            else
            {
                this.WrongPasswordLabel.Visible = true;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginField.Text == "Admin123")
            {
                UsersListForm newForm = new UsersListForm();
                newForm.Size = this.Size;
                newForm.Show();
                this.Hide();
            }
            else
            {
                this.WrongPasswordLabel.Visible = true;
            }
        }
    }
}
