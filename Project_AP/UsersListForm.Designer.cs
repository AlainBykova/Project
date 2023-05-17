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
            SearchPanel = new Panel();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            IconPanel = new Panel();
            AddButton = new Button();
            DeleteButton = new Button();
            UsersList = new CheckedListBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            MenuPanel = new Panel();
            StorageLabel = new Label();
            EquipmentLabel = new Label();
            UsersLabel = new Label();
            MainPanel = new Panel();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SearchPanel.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            MenuPanel.SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(SearchPanel, 1, 1);
            tableLayoutPanel1.Controls.Add(AddButton, 1, 3);
            tableLayoutPanel1.Controls.Add(DeleteButton, 3, 3);
            tableLayoutPanel1.Controls.Add(UsersList, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(69, 75);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(742, 382);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SearchPanel
            // 
            SearchPanel.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(SearchPanel, 4);
            SearchPanel.Controls.Add(SearchTextBox);
            SearchPanel.Controls.Add(SearchButton);
            SearchPanel.Controls.Add(IconPanel);
            SearchPanel.Dock = DockStyle.Fill;
            SearchPanel.Location = new Point(38, 22);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(664, 22);
            SearchPanel.TabIndex = 0;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BorderStyle = BorderStyle.None;
            SearchTextBox.Dock = DockStyle.Fill;
            SearchTextBox.Font = new Font("Segoe UI", 14.2F, FontStyle.Regular, GraphicsUnit.Point);
            SearchTextBox.Location = new Point(49, 0);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(452, 32);
            SearchTextBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(143, 142, 191);
            SearchButton.Dock = DockStyle.Right;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Location = new Point(501, 0);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(161, 20);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // IconPanel
            // 
            IconPanel.BackgroundImage = (Image)resources.GetObject("IconPanel.BackgroundImage");
            IconPanel.BackgroundImageLayout = ImageLayout.Zoom;
            IconPanel.Dock = DockStyle.Left;
            IconPanel.Location = new Point(0, 0);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(49, 20);
            IconPanel.TabIndex = 4;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(143, 142, 191);
            AddButton.Dock = DockStyle.Fill;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Location = new Point(38, 69);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(100, 22);
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
            DeleteButton.Location = new Point(161, 69);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(100, 22);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = false;
            // 
            // UsersList
            // 
            UsersList.AccessibleRole = AccessibleRole.ScrollBar;
            UsersList.BackColor = Color.FromArgb(215, 214, 255);
            UsersList.BorderStyle = BorderStyle.None;
            tableLayoutPanel1.SetColumnSpan(UsersList, 4);
            UsersList.Dock = DockStyle.Fill;
            UsersList.FormattingEnabled = true;
            UsersList.Items.AddRange(new object[] { "Ничего", "Нет", "Простите" });
            UsersList.Location = new Point(38, 116);
            UsersList.MultiColumn = true;
            UsersList.Name = "UsersList";
            UsersList.Size = new Size(664, 242);
            UsersList.TabIndex = 0;
            UsersList.ThreeDCheckBoxes = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(172, 171, 221);
            tableLayoutPanel3.BackgroundImageLayout = ImageLayout.None;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel3, 3);
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel3.Controls.Add(MenuPanel, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel3.Size = new Size(874, 42);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // MenuPanel
            // 
            MenuPanel.Controls.Add(StorageLabel);
            MenuPanel.Controls.Add(EquipmentLabel);
            MenuPanel.Controls.Add(UsersLabel);
            MenuPanel.Dock = DockStyle.Fill;
            MenuPanel.Location = new Point(3, 11);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(299, 28);
            MenuPanel.TabIndex = 2;
            // 
            // StorageLabel
            // 
            StorageLabel.AutoSize = true;
            StorageLabel.BackColor = Color.FromArgb(143, 142, 191);
            StorageLabel.Dock = DockStyle.Fill;
            StorageLabel.Location = new Point(221, 0);
            StorageLabel.Name = "StorageLabel";
            StorageLabel.Size = new Size(125, 20);
            StorageLabel.TabIndex = 3;
            StorageLabel.Text = "Место Хранения";
            StorageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EquipmentLabel
            // 
            EquipmentLabel.AutoSize = true;
            EquipmentLabel.BackColor = Color.FromArgb(143, 142, 191);
            EquipmentLabel.Dock = DockStyle.Left;
            EquipmentLabel.Location = new Point(108, 0);
            EquipmentLabel.Name = "EquipmentLabel";
            EquipmentLabel.Size = new Size(113, 20);
            EquipmentLabel.TabIndex = 2;
            EquipmentLabel.Text = "Оборудование";
            EquipmentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsersLabel
            // 
            UsersLabel.AutoSize = true;
            UsersLabel.BackColor = Color.FromArgb(215, 214, 255);
            UsersLabel.Dock = DockStyle.Left;
            UsersLabel.Location = new Point(0, 0);
            UsersLabel.Name = "UsersLabel";
            UsersLabel.Size = new Size(108, 20);
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
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            MenuPanel.ResumeLayout(false);
            MenuPanel.PerformLayout();
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel SearchPanel;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Panel IconPanel;
        private Button AddButton;
        private Button DeleteButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel MenuPanel;
        private Label EquipmentLabel;
        private Label UsersLabel;
        private Panel MainPanel;
        private Label StorageLabel;
        private CheckedListBox UsersList;
    }
}