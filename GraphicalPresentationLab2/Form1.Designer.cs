namespace GraphicalPresentationLab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lineTypeLabel = new Label();
            lineTypeTextBox = new TextBox();
            lineTypeButton = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            lineTypeListLabel = new Label();
            lineTypeListBox = new ListBox();
            geometryObjectsLabel = new Label();
            geometryObjectsComboBox = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            yourChoiceButton = new Button();
            yourChoiceLabel = new Label();
            yourChoiceTextBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(314, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lineTypeLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(lineTypeTextBox, 0, 1);
            tableLayoutPanel2.Controls.Add(lineTypeButton, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(23, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(3);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(268, 94);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lineTypeLabel
            // 
            lineTypeLabel.AutoSize = true;
            lineTypeLabel.Dock = DockStyle.Fill;
            lineTypeLabel.Location = new Point(6, 6);
            lineTypeLabel.Margin = new Padding(3);
            lineTypeLabel.Name = "lineTypeLabel";
            lineTypeLabel.Size = new Size(256, 14);
            lineTypeLabel.TabIndex = 0;
            lineTypeLabel.Text = "Тип линии";
            lineTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineTypeTextBox
            // 
            lineTypeTextBox.Dock = DockStyle.Fill;
            lineTypeTextBox.Location = new Point(6, 26);
            lineTypeTextBox.Name = "lineTypeTextBox";
            lineTypeTextBox.PlaceholderText = "Введите тип линии";
            lineTypeTextBox.Size = new Size(256, 23);
            lineTypeTextBox.TabIndex = 1;
            // 
            // lineTypeButton
            // 
            lineTypeButton.Dock = DockStyle.Fill;
            lineTypeButton.Location = new Point(6, 56);
            lineTypeButton.Name = "lineTypeButton";
            lineTypeButton.Size = new Size(256, 32);
            lineTypeButton.TabIndex = 2;
            lineTypeButton.Text = "Добавить";
            lineTypeButton.UseVisualStyleBackColor = true;
            lineTypeButton.Click += lineTypeButton_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(lineTypeListLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(lineTypeListBox, 0, 1);
            tableLayoutPanel3.Controls.Add(geometryObjectsLabel, 0, 2);
            tableLayoutPanel3.Controls.Add(geometryObjectsComboBox, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(23, 163);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(3);
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(268, 185);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // lineTypeListLabel
            // 
            lineTypeListLabel.AutoSize = true;
            lineTypeListLabel.Dock = DockStyle.Fill;
            lineTypeListLabel.Location = new Point(6, 6);
            lineTypeListLabel.Margin = new Padding(3);
            lineTypeListLabel.Name = "lineTypeListLabel";
            lineTypeListLabel.Size = new Size(256, 14);
            lineTypeListLabel.TabIndex = 0;
            lineTypeListLabel.Text = "Список типов для линии";
            lineTypeListLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineTypeListBox
            // 
            lineTypeListBox.Dock = DockStyle.Fill;
            lineTypeListBox.FormattingEnabled = true;
            lineTypeListBox.ItemHeight = 15;
            lineTypeListBox.Location = new Point(6, 26);
            lineTypeListBox.Name = "lineTypeListBox";
            lineTypeListBox.Size = new Size(256, 103);
            lineTypeListBox.TabIndex = 1;
            lineTypeListBox.SelectedIndexChanged += lineTypeListBox_SelectedIndexChanged;
            // 
            // geometryObjectsLabel
            // 
            geometryObjectsLabel.AutoSize = true;
            geometryObjectsLabel.Dock = DockStyle.Fill;
            geometryObjectsLabel.Location = new Point(6, 135);
            geometryObjectsLabel.Margin = new Padding(3);
            geometryObjectsLabel.Name = "geometryObjectsLabel";
            geometryObjectsLabel.Size = new Size(256, 14);
            geometryObjectsLabel.TabIndex = 0;
            geometryObjectsLabel.Text = "Список видов геометрических фигур";
            geometryObjectsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // geometryObjectsComboBox
            // 
            geometryObjectsComboBox.Dock = DockStyle.Fill;
            geometryObjectsComboBox.FormattingEnabled = true;
            geometryObjectsComboBox.Location = new Point(6, 155);
            geometryObjectsComboBox.Name = "geometryObjectsComboBox";
            geometryObjectsComboBox.Size = new Size(256, 23);
            geometryObjectsComboBox.TabIndex = 2;
            geometryObjectsComboBox.SelectedIndexChanged += geometryObjectsComboBox_SelectedIndexChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(yourChoiceButton, 0, 2);
            tableLayoutPanel4.Controls.Add(yourChoiceLabel, 0, 0);
            tableLayoutPanel4.Controls.Add(yourChoiceTextBox, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(23, 394);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel4.Size = new Size(268, 144);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // yourChoiceButton
            // 
            yourChoiceButton.Dock = DockStyle.Fill;
            yourChoiceButton.Location = new Point(3, 117);
            yourChoiceButton.Name = "yourChoiceButton";
            yourChoiceButton.Size = new Size(262, 24);
            yourChoiceButton.TabIndex = 0;
            yourChoiceButton.Text = "Посмотреть";
            yourChoiceButton.UseVisualStyleBackColor = true;
            yourChoiceButton.Click += yourChoiceButton_Click;
            // 
            // yourChoiceLabel
            // 
            yourChoiceLabel.AutoSize = true;
            yourChoiceLabel.Dock = DockStyle.Fill;
            yourChoiceLabel.Location = new Point(3, 0);
            yourChoiceLabel.Name = "yourChoiceLabel";
            yourChoiceLabel.Size = new Size(262, 20);
            yourChoiceLabel.TabIndex = 1;
            yourChoiceLabel.Text = "Ваш выбор";
            yourChoiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yourChoiceTextBox
            // 
            yourChoiceTextBox.Dock = DockStyle.Fill;
            yourChoiceTextBox.Location = new Point(3, 23);
            yourChoiceTextBox.Multiline = true;
            yourChoiceTextBox.Name = "yourChoiceTextBox";
            yourChoiceTextBox.ReadOnly = true;
            yourChoiceTextBox.Size = new Size(262, 88);
            yourChoiceTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 561);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(330, 600);
            Name = "Form1";
            Text = "Лабораторная работа №2";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lineTypeLabel;
        private TextBox lineTypeTextBox;
        private Button lineTypeButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lineTypeListLabel;
        private ListBox lineTypeListBox;
        private Label geometryObjectsLabel;
        private ComboBox geometryObjectsComboBox;
        private TableLayoutPanel tableLayoutPanel4;
        private Button yourChoiceButton;
        private Label yourChoiceLabel;
        private TextBox yourChoiceTextBox;
    }
}