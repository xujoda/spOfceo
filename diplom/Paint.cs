using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class Paint : Form
    {
        int x1;
        int y1;
        int x2;
        int y2;
        bool mouseDown;
        Bitmap snapshot;
        Bitmap tempDraw;
        Color foreColor;
        string selectedTool;
        int lineWidth;

        public Paint()
        {
            InitializeComponent();
            snapshot = new Bitmap(panel12.ClientRectangle.Width, this.ClientRectangle.Height);
            foreColor = Color.Black;
            lineWidth = 2;
        }

        private void Paint_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            this.Hide();
            menu.Show();
        }

        private void editColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreColor = colorDialog1.Color;
            }
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            switch (selectedTool)
            {
                case "Line":
                    if (tempDraw != null)
                    {
                        tempDraw = (Bitmap)snapshot.Clone();
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(foreColor, lineWidth);
                        g.DrawLine(myPen, x1, y1, x2, y2);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                    }
                    break;

                case "Rectangle":
                    if (tempDraw != null)
                    {
                        tempDraw = (Bitmap)snapshot.Clone();
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(foreColor, lineWidth);
                        g.DrawRectangle(myPen, x1, y1, x2 - x1, y2 - y1);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                    }
                    break;

                case "Pencil":
                    if (tempDraw != null)
                    {
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(foreColor, lineWidth);
                        g.DrawLine(myPen, x1, y1, x2, y2);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                        x1 = x2;
                        y1 = y2;
                    }
                    break;

                default:
                    break;
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            x1 = e.X;
            y1 = e.Y;

            tempDraw = (Bitmap)snapshot.Clone();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            snapshot = (Bitmap)tempDraw.Clone();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                x2 = e.X;
                y2 = e.Y;
                panel12.Invalidate();
                panel12.Update();
            }
        }

        // выбор инструмента рисования
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton btn in toolStrip1.Items)
            {
                btn.Checked = false;
            }

            ToolStripButton btnClicked = sender as ToolStripButton;
            btnClicked.Checked = true;
            selectedTool = btnClicked.Name;
        }

        // Выбор толщины линии
        private void ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem itm in toolStripSplitButton1.DropDownItems)
            {
                itm.Checked = false;
            }

            ToolStripMenuItem itmClicked = sender as ToolStripMenuItem;
            itmClicked.Checked = true;

            lineWidth = int.Parse(itmClicked.Text.Remove(1));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                snapshot.Save(saveFileDialog1.FileName);
            }
            
        }
    }
}
