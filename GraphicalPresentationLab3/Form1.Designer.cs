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
            lineTypeToolStripMenuItem = new ToolStripMenuItem();
            uninterruptedToolStripMenuItem = new ToolStripMenuItem();
            dottedToolStripMenuItem = new ToolStripMenuItem();
            lineWeightToolStripMenuItem = new ToolStripMenuItem();
            fiveWeightToolStripMenuItem = new ToolStripMenuItem();
            tenWeightToolStripMenuItem = new ToolStripMenuItem();
            fifteenWeightToolStripMenuItem = new ToolStripMenuItem();
            backgroundColorToolStripMenuItem = new ToolStripMenuItem();
            lineColorToolStripMenuItem = new ToolStripMenuItem();
            brushColorDialog = new ColorDialog();
            penColorDialog = new ColorDialog();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { lineTypeToolStripMenuItem, lineWeightToolStripMenuItem, backgroundColorToolStripMenuItem, lineColorToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(223, 100);
            // 
            // lineTypeToolStripMenuItem
            // 
            lineTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uninterruptedToolStripMenuItem, dottedToolStripMenuItem });
            lineTypeToolStripMenuItem.Name = "lineTypeToolStripMenuItem";
            lineTypeToolStripMenuItem.Size = new Size(222, 24);
            lineTypeToolStripMenuItem.Text = "Тип линии";
            // 
            // uninterruptedToolStripMenuItem
            // 
            uninterruptedToolStripMenuItem.Name = "uninterruptedToolStripMenuItem";
            uninterruptedToolStripMenuItem.Size = new Size(190, 26);
            uninterruptedToolStripMenuItem.Text = "Непрерывная";
            uninterruptedToolStripMenuItem.Click += uninterruptedToolStripMenuItem_Click;
            // 
            // dottedToolStripMenuItem
            // 
            dottedToolStripMenuItem.Name = "dottedToolStripMenuItem";
            dottedToolStripMenuItem.Size = new Size(190, 26);
            dottedToolStripMenuItem.Text = "Пунктирная";
            dottedToolStripMenuItem.Click += dottedToolStripMenuItem_Click;
            // 
            // lineWeightToolStripMenuItem
            // 
            lineWeightToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fiveWeightToolStripMenuItem, tenWeightToolStripMenuItem, fifteenWeightToolStripMenuItem });
            lineWeightToolStripMenuItem.Name = "lineWeightToolStripMenuItem";
            lineWeightToolStripMenuItem.Size = new Size(222, 24);
            lineWeightToolStripMenuItem.Text = "Толщина";
            // 
            // fiveWeightToolStripMenuItem
            // 
            fiveWeightToolStripMenuItem.Name = "fiveWeightToolStripMenuItem";
            fiveWeightToolStripMenuItem.Size = new Size(108, 26);
            fiveWeightToolStripMenuItem.Text = "5";
            fiveWeightToolStripMenuItem.Click += fiveWeightToolStripMenuItem_Click;
            // 
            // tenWeightToolStripMenuItem
            // 
            tenWeightToolStripMenuItem.Name = "tenWeightToolStripMenuItem";
            tenWeightToolStripMenuItem.Size = new Size(108, 26);
            tenWeightToolStripMenuItem.Text = "10";
            tenWeightToolStripMenuItem.Click += tenWeightToolStripMenuItem_Click;
            // 
            // fifteenWeightToolStripMenuItem
            // 
            fifteenWeightToolStripMenuItem.Name = "fifteenWeightToolStripMenuItem";
            fifteenWeightToolStripMenuItem.Size = new Size(108, 26);
            fifteenWeightToolStripMenuItem.Text = "15";
            fifteenWeightToolStripMenuItem.Click += fifteenWeightToolStripMenuItem_Click;
            // 
            // backgroundColorToolStripMenuItem
            // 
            backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            backgroundColorToolStripMenuItem.Size = new Size(222, 24);
            backgroundColorToolStripMenuItem.Text = "Цвет фона";
            backgroundColorToolStripMenuItem.Click += backgroundColorToolStripMenuItem_Click;
            // 
            // lineColorToolStripMenuItem
            // 
            lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            lineColorToolStripMenuItem.Size = new Size(222, 24);
            lineColorToolStripMenuItem.Text = "Цвет линии обводки";
            lineColorToolStripMenuItem.Click += lineColorToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 425);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Лабораторная работа №3";
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem lineTypeToolStripMenuItem;
        private ToolStripMenuItem uninterruptedToolStripMenuItem;
        private ToolStripMenuItem dottedToolStripMenuItem;
        private ToolStripMenuItem lineWeightToolStripMenuItem;
        private ToolStripMenuItem fiveWeightToolStripMenuItem;
        private ToolStripMenuItem tenWeightToolStripMenuItem;
        private ToolStripMenuItem fifteenWeightToolStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem lineColorToolStripMenuItem;
        private ColorDialog brushColorDialog;
        private ColorDialog penColorDialog;
    }
}