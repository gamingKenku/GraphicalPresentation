namespace GraphicalPresentationLab3
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            типЛинииToolStripMenuItem = new ToolStripMenuItem();
            толщинаToolStripMenuItem = new ToolStripMenuItem();
            цветФонаToolStripMenuItem = new ToolStripMenuItem();
            цветЛинииОбводкиToolStripMenuItem = new ToolStripMenuItem();
            непрерывнаяToolStripMenuItem = new ToolStripMenuItem();
            пунктирнаяToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            comboBox1 = new ComboBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { типЛинииToolStripMenuItem, толщинаToolStripMenuItem, цветФонаToolStripMenuItem, цветЛинииОбводкиToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(188, 114);
            // 
            // типЛинииToolStripMenuItem
            // 
            типЛинииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { непрерывнаяToolStripMenuItem, пунктирнаяToolStripMenuItem });
            типЛинииToolStripMenuItem.Name = "типЛинииToolStripMenuItem";
            типЛинииToolStripMenuItem.Size = new Size(187, 22);
            типЛинииToolStripMenuItem.Text = "Тип линии";
            // 
            // толщинаToolStripMenuItem
            // 
            толщинаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            толщинаToolStripMenuItem.Name = "толщинаToolStripMenuItem";
            толщинаToolStripMenuItem.Size = new Size(187, 22);
            толщинаToolStripMenuItem.Text = "Толщина";
            // 
            // цветФонаToolStripMenuItem
            // 
            цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
            цветФонаToolStripMenuItem.Size = new Size(187, 22);
            цветФонаToolStripMenuItem.Text = "Цвет фона";
            цветФонаToolStripMenuItem.Click += цветФонаToolStripMenuItem_Click;
            // 
            // цветЛинииОбводкиToolStripMenuItem
            // 
            цветЛинииОбводкиToolStripMenuItem.Name = "цветЛинииОбводкиToolStripMenuItem";
            цветЛинииОбводкиToolStripMenuItem.Size = new Size(187, 22);
            цветЛинииОбводкиToolStripMenuItem.Text = "Цвет линии обводки";
            цветЛинииОбводкиToolStripMenuItem.Click += цветЛинииОбводкиToolStripMenuItem_Click;
            // 
            // непрерывнаяToolStripMenuItem
            // 
            непрерывнаяToolStripMenuItem.Name = "непрерывнаяToolStripMenuItem";
            непрерывнаяToolStripMenuItem.Size = new Size(180, 22);
            непрерывнаяToolStripMenuItem.Text = "Непрерывная";
            непрерывнаяToolStripMenuItem.Click += непрерывнаяToolStripMenuItem_Click;
            // 
            // пунктирнаяToolStripMenuItem
            // 
            пунктирнаяToolStripMenuItem.Name = "пунктирнаяToolStripMenuItem";
            пунктирнаяToolStripMenuItem.Size = new Size(180, 22);
            пунктирнаяToolStripMenuItem.Text = "Пунктирная";
            пунктирнаяToolStripMenuItem.Click += пунктирнаяToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(180, 22);
            toolStripMenuItem2.Text = "5";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "10";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(180, 22);
            toolStripMenuItem4.Text = "15";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(248, 171);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 319);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem типЛинииToolStripMenuItem;
        private ToolStripMenuItem непрерывнаяToolStripMenuItem;
        private ToolStripMenuItem пунктирнаяToolStripMenuItem;
        private ToolStripMenuItem толщинаToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem цветФонаToolStripMenuItem;
        private ToolStripMenuItem цветЛинииОбводкиToolStripMenuItem;
        private ComboBox comboBox1;
    }
}