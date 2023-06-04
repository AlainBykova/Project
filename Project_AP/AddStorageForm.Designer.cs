namespace Project_AP
{
    partial class AddStorageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStorageForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            UsersLabel = new Label();
            StorageLabel = new Label();
            EquipmentLabel = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel3 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            CreatRack = new Button();
            createHardware = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel2 = new Panel();
            panel4 = new Panel();
            label11 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
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
            tableLayoutPanel3.Controls.Add(UsersLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(StorageLabel, 2, 0);
            tableLayoutPanel3.Controls.Add(EquipmentLabel, 1, 0);
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
            // UsersLabel
            // 
            UsersLabel.BackColor = Color.FromArgb(143, 142, 191);
            UsersLabel.Dock = DockStyle.Fill;
            UsersLabel.Location = new Point(4, 0);
            UsersLabel.Margin = new Padding(4, 0, 0, 0);
            UsersLabel.Name = "UsersLabel";
            UsersLabel.Size = new Size(89, 36);
            UsersLabel.TabIndex = 7;
            UsersLabel.Text = "Пользователи";
            UsersLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StorageLabel
            // 
            StorageLabel.BackColor = Color.FromArgb(215, 214, 255);
            StorageLabel.Dock = DockStyle.Fill;
            StorageLabel.Location = new Point(186, 0);
            StorageLabel.Margin = new Padding(0);
            StorageLabel.Name = "StorageLabel";
            StorageLabel.Size = new Size(94, 36);
            StorageLabel.TabIndex = 5;
            StorageLabel.Text = "Место Хранения";
            StorageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EquipmentLabel
            // 
            EquipmentLabel.BackColor = Color.FromArgb(143, 142, 191);
            EquipmentLabel.Dock = DockStyle.Fill;
            EquipmentLabel.Location = new Point(93, 0);
            EquipmentLabel.Margin = new Padding(0);
            EquipmentLabel.Name = "EquipmentLabel";
            EquipmentLabel.Size = new Size(93, 36);
            EquipmentLabel.TabIndex = 6;
            EquipmentLabel.Text = "Оборудование";
            EquipmentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel4.ColumnCount = 5;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.5F));
            tableLayoutPanel4.Controls.Add(panel3, 1, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 3, 2);
            tableLayoutPanel4.Controls.Add(panel2, 2, 2);
            tableLayoutPanel4.Controls.Add(label11, 2, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(40, 67);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel4.Size = new Size(720, 360);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(18, 18);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(36, 27);
            panel3.TabIndex = 1;
            panel3.Click += panel3_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel5.Controls.Add(CreatRack, 0, 0);
            tableLayoutPanel5.Controls.Add(createHardware, 0, 2);
            tableLayoutPanel5.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(417, 48);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 42.5F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 42.5F));
            tableLayoutPanel5.Size = new Size(282, 282);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 164);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(276, 115);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // CreatRack
            // 
            CreatRack.BackColor = Color.FromArgb(143, 142, 191);
            CreatRack.BackgroundImageLayout = ImageLayout.None;
            CreatRack.Dock = DockStyle.Fill;
            CreatRack.FlatStyle = FlatStyle.Flat;
            CreatRack.Location = new Point(3, 3);
            CreatRack.Name = "CreatRack";
            CreatRack.Size = new Size(276, 15);
            CreatRack.TabIndex = 2;
            CreatRack.Text = "Создать стеллаж";
            CreatRack.UseVisualStyleBackColor = false;
            CreatRack.Click += CreatRack_Click;
            CreatRack.MouseEnter += CreatRack_MouseEnter;
            CreatRack.MouseLeave += CreatRack_MouseLeave;
            // 
            // createHardware
            // 
            createHardware.BackColor = Color.FromArgb(143, 142, 191);
            createHardware.Dock = DockStyle.Fill;
            createHardware.FlatStyle = FlatStyle.Flat;
            createHardware.Location = new Point(3, 143);
            createHardware.Name = "createHardware";
            createHardware.Size = new Size(276, 15);
            createHardware.TabIndex = 3;
            createHardware.Text = "Добавить оборудование";
            createHardware.UseVisualStyleBackColor = false;
            createHardware.MouseEnter += createHardware_MouseEnter;
            createHardware.MouseLeave += createHardware_MouseLeave;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.White;
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 24);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(276, 113);
            flowLayoutPanel2.TabIndex = 4;
            flowLayoutPanel2.WrapContents = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(215, 214, 255);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(57, 48);
            panel2.Margin = new Padding(3, 3, 10, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(347, 282);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(68, 74);
            panel4.Margin = new Padding(10);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(221, 114);
            panel4.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ImageAlign = ContentAlignment.TopCenter;
            label11.Location = new Point(57, 18);
            label11.Name = "label11";
            label11.Size = new Size(354, 27);
            label11.TabIndex = 3;
            label11.Text = "Кабинет";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddStorageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "AddStorageForm";
            ShowIcon = false;
            FormClosed += AddStorageForm_FormClosed;
            Load += AddStorageForm_Load;
            Paint += AddStorageForm_Paint;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label UsersLabel;
        private Label StorageLabel;
        private Label EquipmentLabel;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Panel panel4;
        private Label label11;
        private Button CreatRack;
        private Button createHardware;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}