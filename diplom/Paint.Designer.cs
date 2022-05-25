
namespace diplom
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Line = new System.Windows.Forms.ToolStripButton();
            this.Rectangle = new System.Windows.Forms.ToolStripButton();
            this.Pencil = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel12 = new diplom.BufferedPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.colorsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(77, 20);
            this.toolStripMenuItem1.Text = "MainMenu";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editColorToolStripMenuItem});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // editColorToolStripMenuItem
            // 
            this.editColorToolStripMenuItem.Name = "editColorToolStripMenuItem";
            this.editColorToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.editColorToolStripMenuItem.Text = "Edit Color";
            this.editColorToolStripMenuItem.Click += new System.EventHandler(this.editColorToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Line,
            this.Rectangle,
            this.Pencil});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Line
            // 
            this.Line.CheckOnClick = true;
            this.Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Line.Image = ((System.Drawing.Image)(resources.GetObject("Line.Image")));
            this.Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(23, 22);
            this.Line.Text = "toolStripButton1";
            this.Line.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.CheckOnClick = true;
            this.Rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rectangle.Image = ((System.Drawing.Image)(resources.GetObject("Rectangle.Image")));
            this.Rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(23, 22);
            this.Rectangle.Text = "toolStripButton2";
            this.Rectangle.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Pencil
            // 
            this.Pencil.CheckOnClick = true;
            this.Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pencil.Image = ((System.Drawing.Image)(resources.GetObject("Pencil.Image")));
            this.Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(23, 22);
            this.Pencil.Text = "toolStripButton3";
            this.Pencil.ToolTipText = "toolStripButton1";
            this.Pencil.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ptToolStripMenuItem,
            this.ptToolStripMenuItem1,
            this.pointToolStripMenuItem,
            this.toolStripMenuItem2});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(86, 22);
            this.toolStripSplitButton1.Text = "Line Weigth";
            // 
            // ptToolStripMenuItem
            // 
            this.ptToolStripMenuItem.CheckOnClick = true;
            this.ptToolStripMenuItem.Name = "ptToolStripMenuItem";
            this.ptToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.ptToolStripMenuItem.Text = "1 point";
            this.ptToolStripMenuItem.Click += new System.EventHandler(this.ptToolStripMenuItem_Click);
            // 
            // ptToolStripMenuItem1
            // 
            this.ptToolStripMenuItem1.Checked = true;
            this.ptToolStripMenuItem1.CheckOnClick = true;
            this.ptToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ptToolStripMenuItem1.Name = "ptToolStripMenuItem1";
            this.ptToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.ptToolStripMenuItem1.Text = "2 point";
            this.ptToolStripMenuItem1.Click += new System.EventHandler(this.ptToolStripMenuItem_Click);
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.CheckOnClick = true;
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.pointToolStripMenuItem.Text = "4 point";
            this.pointToolStripMenuItem.Click += new System.EventHandler(this.ptToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem2.Text = "8 point";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ptToolStripMenuItem_Click);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 74);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(800, 376);
            this.panel12.TabIndex = 3;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Paint_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Line;
        private System.Windows.Forms.ToolStripButton Rectangle;
        private System.Windows.Forms.ToolStripButton Pencil;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private BufferedPanel panel12;
    }
}