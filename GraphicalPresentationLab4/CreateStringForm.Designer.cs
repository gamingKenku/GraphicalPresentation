namespace GraphicalPresentationLab4
{
    partial class CreateStringForm
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
            groupBox1 = new GroupBox();
            stringTextBox = new TextBox();
            coordinatesTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            createButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
            tableLayoutPanel1.Controls.Add(createButton, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(392, 495);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stringTextBox);
            groupBox1.Controls.Add(coordinatesTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(23, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 194);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // stringTextBox
            // 
            stringTextBox.Location = new Point(126, 144);
            stringTextBox.Name = "stringTextBox";
            stringTextBox.Size = new Size(100, 23);
            stringTextBox.TabIndex = 11;
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
            label3.Location = new Point(154, 111);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Строка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 31);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 0;
            label2.Text = "Координаты строки";
            // 
            // createButton
            // 
            createButton.Dock = DockStyle.Fill;
            createButton.Location = new Point(120, 322);
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
        private TextBox stringTextBox;
        private TextBox coordinatesTextBox;
    }
}