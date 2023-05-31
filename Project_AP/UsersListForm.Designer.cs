namespace Project_AP
{
    partial class UsersListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersListForm));
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            AddButton = new Button();
            DeleteButton = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            IconPanel = new Panel();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            panel2 = new Panel();
            UsersList = new FlowLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            EquipmentLabel = new Label();
            StorageLabel = new Label();
            UsersLabel = new Label();
            MainPanel = new Panel();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel2.BackgroundImageLayout = ImageLayout.None;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.Size = new Size(880, 485);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.76190472F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.38095236F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.52381F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.76190472F));
            tableLayoutPanel1.Controls.Add(AddButton, 1, 3);
            tableLayoutPanel1.Controls.Add(DeleteButton, 3, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(66, 72);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(748, 388);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(143, 142, 191);
            AddButton.Dock = DockStyle.Fill;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Location = new Point(35, 67);
            AddButton.Margin = new Padding(0);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(106, 29);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = false;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.FromArgb(214, 215, 255);
            DeleteButton.Dock = DockStyle.Fill;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Location = new Point(158, 67);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(106, 29);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel5, 4);
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.Controls.Add(IconPanel, 0, 0);
            tableLayoutPanel5.Controls.Add(SearchButton, 2, 0);
            tableLayoutPanel5.Controls.Add(SearchTextBox, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(35, 19);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(674, 29);
            tableLayoutPanel5.TabIndex = 5;
            // 
            // IconPanel
            // 
            IconPanel.BackgroundImage = (Image)resources.GetObject("IconPanel.BackgroundImage");
            IconPanel.BackgroundImageLayout = ImageLayout.Zoom;
            IconPanel.Dock = DockStyle.Fill;
            IconPanel.Location = new Point(5, 5);
            IconPanel.Margin = new Padding(5);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(30, 19);
            IconPanel.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(143, 142, 191);
            SearchButton.Dock = DockStyle.Fill;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Location = new Point(538, 0);
            SearchButton.Margin = new Padding(0);
            SearchButton.Name = "SearchButton";
            SearchButton.Padding = new Padding(3, 0, 0, 0);
            SearchButton.Size = new Size(136, 29);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BorderStyle = BorderStyle.None;
            SearchTextBox.Dock = DockStyle.Fill;
            SearchTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SearchTextBox.Location = new Point(40, 0);
            SearchTextBox.Margin = new Padding(0);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(498, 40);
            SearchTextBox.TabIndex = 1;
            SearchTextBox.WordWrap = false;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            // 
            // panel2
            // 
            tableLayoutPanel1.SetColumnSpan(panel2, 4);
            panel2.Controls.Add(UsersList);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(38, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(668, 246);
            panel2.TabIndex = 7;
            // 
            // UsersList
            // 
            UsersList.AutoScroll = true;
            UsersList.AutoSize = true;
            UsersList.BackColor = Color.FromArgb(215, 214, 255);
            UsersList.Dock = DockStyle.Fill;
            UsersList.FlowDirection = FlowDirection.TopDown;
            UsersList.Location = new Point(0, 0);
            UsersList.Name = "UsersList";
            UsersList.Size = new Size(668, 246);
            UsersList.TabIndex = 4;
            UsersList.WrapContents = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(172, 171, 221);
            tableLayoutPanel3.BackgroundImageLayout = ImageLayout.None;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel3, 3);
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel3.Size = new Size(880, 48);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(EquipmentLabel, 1, 0);
            tableLayoutPanel4.Controls.Add(StorageLabel, 2, 0);
            tableLayoutPanel4.Controls.Add(UsersLabel, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 9);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(308, 39);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // EquipmentLabel
            // 
            EquipmentLabel.BackColor = Color.FromArgb(143, 142, 191);
            EquipmentLabel.Dock = DockStyle.Fill;
            EquipmentLabel.Location = new Point(102, 0);
            EquipmentLabel.Margin = new Padding(0);
            EquipmentLabel.Name = "EquipmentLabel";
            EquipmentLabel.Size = new Size(102, 39);
            EquipmentLabel.TabIndex = 2;
            EquipmentLabel.Text = "Оборудование";
            EquipmentLabel.TextAlign = ContentAlignment.MiddleCenter;
            EquipmentLabel.Click += EquipmentLabel_Click;
            EquipmentLabel.MouseEnter += EquipmentLabel_MouseEnter;
            EquipmentLabel.MouseLeave += EquipmentLabel_MouseLeave;
            // 
            // StorageLabel
            // 
            StorageLabel.BackColor = Color.FromArgb(143, 142, 191);
            StorageLabel.Dock = DockStyle.Fill;
            StorageLabel.Location = new Point(204, 0);
            StorageLabel.Margin = new Padding(0);
            StorageLabel.Name = "StorageLabel";
            StorageLabel.Size = new Size(104, 39);
            StorageLabel.TabIndex = 3;
            StorageLabel.Text = "Место Хранения";
            StorageLabel.TextAlign = ContentAlignment.MiddleCenter;
            StorageLabel.Click += StorageLabel_Click;
            StorageLabel.MouseEnter += StorageLabel_MouseEnter;
            StorageLabel.MouseLeave += StorageLabel_MouseLeave;
            // 
            // UsersLabel
            // 
            UsersLabel.BackColor = Color.FromArgb(215, 214, 255);
            UsersLabel.Dock = DockStyle.Fill;
            UsersLabel.Location = new Point(4, 0);
            UsersLabel.Margin = new Padding(4, 0, 0, 0);
            UsersLabel.Name = "UsersLabel";
            UsersLabel.Size = new Size(98, 39);
            UsersLabel.TabIndex = 0;
            UsersLabel.Text = "Пользователи";
            UsersLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(214, 215, 255);
            MainPanel.Controls.Add(tableLayoutPanel2);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(880, 485);
            MainPanel.TabIndex = 1;
            // 
            // UsersListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(880, 485);
            Controls.Add(MainPanel);
            Name = "UsersListForm";
            ShowIcon = false;
            FormClosed += UsersListForm_FormClosed;
            Paint += UsersListForm_Paint;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Panel IconPanel;
        private Button AddButton;
        private Button DeleteButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Label EquipmentLabel;
        private Label UsersLabel;
        private Panel MainPanel;
        private Label StorageLabel;
        private FlowLayoutPanel UsersList;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel2;
    }
}