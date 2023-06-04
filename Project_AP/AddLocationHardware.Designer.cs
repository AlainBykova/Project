namespace Project_AP
{
    partial class AddLocationHardware
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            listBox1 = new ListBox();
            panel1 = new Panel();
            listBox2 = new ListBox();
            label2 = new Label();
            panel3 = new Panel();
            listBox3 = new ListBox();
            label4 = new Label();
            panel4 = new Panel();
            listBox4 = new ListBox();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(215, 214, 255);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(542, 383);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel4, 0, 4);
            tableLayoutPanel2.Controls.Add(panel3, 0, 3);
            tableLayoutPanel2.Controls.Add(panel1, 0, 2);
            tableLayoutPanel2.Controls.Add(panel2, 0, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(button2, 0, 6);
            tableLayoutPanel2.Controls.Add(button1, 1, 6);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(27, 19);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.Size = new Size(487, 344);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(487, 43);
            label1.TabIndex = 0;
            label1.Text = "Добавить оборудование";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            tableLayoutPanel2.SetColumnSpan(panel2, 2);
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 48);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(477, 50);
            panel2.TabIndex = 7;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(172, 171, 221);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(5, 5, 0, 5);
            label3.Name = "label3";
            label3.Size = new Size(246, 50);
            label3.TabIndex = 1;
            label3.Text = "Оборудование:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.Dock = DockStyle.Left;
            listBox1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 37;
            listBox1.Location = new Point(246, 0);
            listBox1.Margin = new Padding(0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(231, 50);
            listBox1.TabIndex = 4;
            // 
            // panel1
            // 
            tableLayoutPanel2.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(listBox2);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 108);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(477, 50);
            panel1.TabIndex = 8;
            // 
            // listBox2
            // 
            listBox2.BorderStyle = BorderStyle.FixedSingle;
            listBox2.Dock = DockStyle.Left;
            listBox2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 37;
            listBox2.Location = new Point(246, 0);
            listBox2.Margin = new Padding(0);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(231, 50);
            listBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(172, 171, 221);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(5, 5, 0, 5);
            label2.Name = "label2";
            label2.Size = new Size(246, 50);
            label2.TabIndex = 1;
            label2.Text = "Стеллаж:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            tableLayoutPanel2.SetColumnSpan(panel3, 2);
            panel3.Controls.Add(listBox3);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 168);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(477, 50);
            panel3.TabIndex = 9;
            // 
            // listBox3
            // 
            listBox3.BorderStyle = BorderStyle.FixedSingle;
            listBox3.Dock = DockStyle.Left;
            listBox3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 37;
            listBox3.Location = new Point(288, 0);
            listBox3.Margin = new Padding(0);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(189, 50);
            listBox3.TabIndex = 4;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(172, 171, 221);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(5, 5, 0, 5);
            label4.Name = "label4";
            label4.Size = new Size(288, 50);
            label4.TabIndex = 1;
            label4.Text = "Область стеллажа:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            tableLayoutPanel2.SetColumnSpan(panel4, 2);
            panel4.Controls.Add(listBox4);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(5, 228);
            panel4.Margin = new Padding(5);
            panel4.Name = "panel4";
            panel4.Size = new Size(477, 50);
            panel4.TabIndex = 10;
            // 
            // listBox4
            // 
            listBox4.BorderStyle = BorderStyle.FixedSingle;
            listBox4.Dock = DockStyle.Left;
            listBox4.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 37;
            listBox4.Location = new Point(288, 0);
            listBox4.Margin = new Padding(0);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(189, 50);
            listBox4.TabIndex = 4;
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(172, 171, 221);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(5, 5, 0, 5);
            label5.Name = "label5";
            label5.Size = new Size(288, 50);
            label5.TabIndex = 1;
            label5.Text = "Количество:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(143, 142, 191);
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(10, 300);
            button2.Margin = new Padding(10, 0, 10, 10);
            button2.Name = "button2";
            button2.Size = new Size(223, 34);
            button2.TabIndex = 11;
            button2.Text = "Отменить";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(143, 142, 191);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(253, 300);
            button1.Margin = new Padding(10, 0, 10, 10);
            button1.Name = "button1";
            button1.Size = new Size(224, 34);
            button1.TabIndex = 12;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = false;
            // 
            // AddLocationHardware
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 383);
            Controls.Add(tableLayoutPanel1);
            Name = "AddLocationHardware";
            ShowIcon = false;
            Text = "AddLocationHardware";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Panel panel2;
        private ListBox listBox1;
        private Label label3;
        private Panel panel4;
        private ListBox listBox4;
        private Label label5;
        private Panel panel3;
        private ListBox listBox3;
        private Label label4;
        private Panel panel1;
        private ListBox listBox2;
        private Label label2;
        private Button button2;
        private Button button1;
    }
}