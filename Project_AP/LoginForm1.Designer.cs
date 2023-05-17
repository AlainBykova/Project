namespace Project_AP
{
    partial class LoginForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            LoginButton = new Button();
            LoginLabel = new Label();
            PasswordLabel = new Label();
            LoginField = new TextBox();
            WrongPasswordLabel = new Label();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.1148777F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.6967983F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.8851223F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.20904F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.87022924F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42.55725F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.74046F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.8320608F));
            tableLayoutPanel1.Size = new Size(755, 524);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.SetColumnSpan(panel2, 2);
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Location = new Point(147, 38);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.MinimumSize = new Size(88, 150);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(4);
            tableLayoutPanel1.SetRowSpan(panel2, 2);
            panel2.Size = new Size(458, 422);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.Controls.Add(LoginButton, 1, 5);
            tableLayoutPanel2.Controls.Add(LoginLabel, 1, 1);
            tableLayoutPanel2.Controls.Add(PasswordLabel, 1, 2);
            tableLayoutPanel2.Controls.Add(LoginField, 1, 3);
            tableLayoutPanel2.Controls.Add(WrongPasswordLabel, 1, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 4);
            tableLayoutPanel2.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.Size = new Size(450, 414);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel2.SetColumnSpan(LoginButton, 4);
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.Dock = DockStyle.Fill;
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(143, 142, 191);
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Times New Roman", 40F, FontStyle.Regular, GraphicsUnit.Point);
            LoginButton.Location = new Point(69, 291);
            LoginButton.Margin = new Padding(2, 3, 2, 3);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(308, 56);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Войти";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginLabel
            // 
            tableLayoutPanel2.SetColumnSpan(LoginLabel, 4);
            LoginLabel.Dock = DockStyle.Fill;
            LoginLabel.Font = new Font("Times New Roman", 55F, FontStyle.Regular, GraphicsUnit.Point);
            LoginLabel.Location = new Point(69, 62);
            LoginLabel.Margin = new Padding(2, 0, 2, 0);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(308, 51);
            LoginLabel.TabIndex = 1;
            LoginLabel.Text = "Вход в систему";
            LoginLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // PasswordLabel
            // 
            tableLayoutPanel2.SetColumnSpan(PasswordLabel, 4);
            PasswordLabel.Dock = DockStyle.Fill;
            PasswordLabel.Font = new Font("Times New Roman", 48F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordLabel.Location = new Point(69, 113);
            PasswordLabel.Margin = new Padding(2, 0, 2, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(308, 51);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Пароль";
            PasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginField
            // 
            LoginField.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel2.SetColumnSpan(LoginField, 4);
            LoginField.Dock = DockStyle.Bottom;
            LoginField.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LoginField.Location = new Point(69, 170);
            LoginField.Margin = new Padding(2, 3, 2, 3);
            LoginField.Name = "LoginField";
            LoginField.PasswordChar = '*';
            LoginField.Size = new Size(308, 53);
            LoginField.TabIndex = 3;
            LoginField.UseSystemPasswordChar = true;
            LoginField.TextChanged += textBox1_TextChanged;
            LoginField.KeyDown += textBox1_KeyDown;
            // 
            // WrongPasswordLabel
            // 
            WrongPasswordLabel.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(WrongPasswordLabel, 4);
            WrongPasswordLabel.Dock = DockStyle.Top;
            WrongPasswordLabel.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            WrongPasswordLabel.ForeColor = Color.FromArgb(255, 122, 114);
            WrongPasswordLabel.Location = new Point(70, 226);
            WrongPasswordLabel.Name = "WrongPasswordLabel";
            WrongPasswordLabel.Size = new Size(306, 33);
            WrongPasswordLabel.TabIndex = 4;
            WrongPasswordLabel.Text = "Неверный пароль";
            WrongPasswordLabel.TextAlign = ContentAlignment.BottomCenter;
            WrongPasswordLabel.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(215, 214, 255);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(755, 524);
            panel1.TabIndex = 0;
            // 
            // LoginForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(755, 524);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm1";
            ShowIcon = false;
            Resize += LoginForm_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button LoginButton;
        private Label LoginLabel;
        private Label PasswordLabel;
        private TextBox LoginField;
        private Label WrongPasswordLabel;
    }
}