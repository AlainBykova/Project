namespace Project_AP
{
    partial class EquipmentListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentListForm));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            StorageLabel = new Label();
            EquipmentLabel = new Label();
            UsersLabel = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            IconPanel = new Panel();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            AddButton = new Button();
            DeleteButton = new Button();
            HardwareList = new FlowLayoutPanel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(215, 214, 255);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(172, 171, 221);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 3);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.Size = new Size(800, 45);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(StorageLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(EquipmentLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(UsersLabel, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 9);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(280, 36);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // StorageLabel
            // 
            StorageLabel.BackColor = Color.FromArgb(143, 142, 191);
            StorageLabel.Dock = DockStyle.Fill;
            StorageLabel.Location = new Point(186, 0);
            StorageLabel.Margin = new Padding(0);
            StorageLabel.Name = "StorageLabel";
            StorageLabel.Size = new Size(94, 36);
            StorageLabel.TabIndex = 4;
            StorageLabel.Text = "Место Хранения";
            StorageLabel.TextAlign = ContentAlignment.MiddleCenter;
            StorageLabel.Click += StorageLabel_Click;
            StorageLabel.MouseEnter += StorageLabel_MouseEnter;
            StorageLabel.MouseLeave += StorageLabel_MouseLeave;
            // 
            // EquipmentLabel
            // 
            EquipmentLabel.BackColor = Color.FromArgb(215, 214, 255);
            EquipmentLabel.Dock = DockStyle.Fill;
            EquipmentLabel.Location = new Point(93, 0);
            EquipmentLabel.Margin = new Padding(0);
            EquipmentLabel.Name = "EquipmentLabel";
            EquipmentLabel.Size = new Size(93, 36);
            EquipmentLabel.TabIndex = 3;
            EquipmentLabel.Text = "Оборудование";
            EquipmentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsersLabel
            // 
            UsersLabel.BackColor = Color.FromArgb(143, 142, 191);
            UsersLabel.Dock = DockStyle.Fill;
            UsersLabel.Location = new Point(4, 0);
            UsersLabel.Margin = new Padding(4, 0, 0, 0);
            UsersLabel.Name = "UsersLabel";
            UsersLabel.Size = new Size(89, 36);
            UsersLabel.TabIndex = 1;
            UsersLabel.Text = "Пользователи";
            UsersLabel.TextAlign = ContentAlignment.MiddleCenter;
            UsersLabel.Click += UsersLabel_Click;
            UsersLabel.MouseEnter += UsersLabel_MouseEnter;
            UsersLabel.MouseLeave += UsersLabel_MouseLeave;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel4.ColumnCount = 6;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 1, 1);
            tableLayoutPanel4.Controls.Add(AddButton, 1, 3);
            tableLayoutPanel4.Controls.Add(DeleteButton, 3, 3);
            tableLayoutPanel4.Controls.Add(HardwareList, 1, 5);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(63, 70);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 7;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.Size = new Size(674, 354);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel4.SetColumnSpan(tableLayoutPanel5, 4);
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.Controls.Add(IconPanel, 0, 0);
            tableLayoutPanel5.Controls.Add(SearchButton, 2, 0);
            tableLayoutPanel5.Controls.Add(SearchTextBox, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(33, 17);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(605, 26);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // IconPanel
            // 
            IconPanel.BackgroundImage = (Image)resources.GetObject("IconPanel.BackgroundImage");
            IconPanel.BackgroundImageLayout = ImageLayout.Zoom;
            IconPanel.Dock = DockStyle.Fill;
            IconPanel.Location = new Point(5, 5);
            IconPanel.Margin = new Padding(5);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(26, 16);
            IconPanel.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(143, 142, 191);
            SearchButton.Dock = DockStyle.Fill;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Location = new Point(483, 0);
            SearchButton.Margin = new Padding(0);
            SearchButton.Name = "SearchButton";
            SearchButton.Padding = new Padding(3, 0, 0, 0);
            SearchButton.Size = new Size(122, 26);
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
            SearchTextBox.Location = new Point(36, 0);
            SearchTextBox.Margin = new Padding(0);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(447, 40);
            SearchTextBox.TabIndex = 1;
            SearchTextBox.WordWrap = false;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(143, 142, 191);
            AddButton.Dock = DockStyle.Fill;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Location = new Point(33, 60);
            AddButton.Margin = new Padding(0);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(101, 26);
            AddButton.TabIndex = 7;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = false;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.FromArgb(214, 215, 255);
            DeleteButton.Dock = DockStyle.Fill;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Location = new Point(150, 60);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(101, 26);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = false;
            // 
            // HardwareList
            // 
            HardwareList.AutoScroll = true;
            HardwareList.AutoSize = true;
            HardwareList.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel4.SetColumnSpan(HardwareList, 4);
            HardwareList.Dock = DockStyle.Fill;
            HardwareList.FlowDirection = FlowDirection.TopDown;
            HardwareList.Location = new Point(33, 103);
            HardwareList.Margin = new Padding(0);
            HardwareList.Name = "HardwareList";
            HardwareList.Size = new Size(605, 230);
            HardwareList.TabIndex = 9;
            HardwareList.WrapContents = false;
            // 
            // EquipmentListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "EquipmentListForm";
            ShowIcon = false;
            FormClosed += EquipmentListForm_FormClosed;
            Paint += EquipmentListForm_Paint;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label StorageLabel;
        private Label EquipmentLabel;
        private Label UsersLabel;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel IconPanel;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private Button AddButton;
        private Button DeleteButton;
        private FlowLayoutPanel HardwareList;
    }
}