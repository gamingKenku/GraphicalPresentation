namespace GraphicalPresentationLab4
{
    partial class CreateObjectForm
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
            panel1 = new Panel();
            objectTypeComboBox = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            sizeTextBox = new TextBox();
            coordinatesTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            createButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 2);
            tableLayoutPanel1.Controls.Add(createButton, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(392, 495);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(objectTypeComboBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(23, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 94);
            panel1.TabIndex = 0;
            // 
            // objectTypeComboBox
            // 
            objectTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            objectTypeComboBox.FormattingEnabled = true;
            objectTypeComboBox.Items.AddRange(new object[] { "Точка", "Линия", "Прямоугольник", "Эллипс" });
            objectTypeComboBox.Location = new Point(76, 48);
            objectTypeComboBox.Name = "objectTypeComboBox";
            objectTypeComboBox.Size = new Size(200, 23);
            objectTypeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(136, 10);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Тип объекта";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(sizeTextBox);
            groupBox1.Controls.Add(coordinatesTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(23, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 194);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // sizeTextBox
            // 
            sizeTextBox.Location = new Point(126, 144);
            sizeTextBox.Name = "sizeTextBox";
            sizeTextBox.Size = new Size(100, 23);
            sizeTextBox.TabIndex = 11;
            // 
            // coordinatesTextBox
            // 
            coordinatesTextBox.Location = new Point(126, 64);
            coordinatesTextBox.Name = "coordinatesTextBox";
            coordinatesTextBox.Size = new Size(100, 23);
            coordinatesTextBox.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 109);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 2;
            label3.Text = "Размеры объекта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 29);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 0;
            label2.Text = "Координаты объекта";
            // 
            // createButton
            // 
            createButton.Dock = DockStyle.Fill;
            createButton.Location = new Point(120, 372);
            createButton.Margin = new Padding(100, 25, 100, 25);
            createButton.Name = "createButton";
            createButton.RightToLeft = RightToLeft.Yes;
            createButton.Size = new Size(152, 50);
            createButton.TabIndex = 2;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 495);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(408, 534);
            Name = "CreateForm";
            Text = "Создание объекта";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private ComboBox objectTypeComboBox;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Button createButton;
        private TextBox sizeTextBox;
        private TextBox coordinatesTextBox;
    }
}