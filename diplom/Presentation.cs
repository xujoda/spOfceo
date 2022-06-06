using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace diplom
{
    public partial class Presentation : MaterialForm
    {
        bool mouseDown;
        int x1;
        int y1;
        int countSlides = 0;
        int activeSlide = 0;
        List<Panel> pSlides = new List<Panel>();

        public Presentation()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey600, Primary.Grey500,
                Primary.Grey400, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                newSlide();
            }
        }

        public void newSlide()
        {
            countSlides++;
            listBox1.Items.Add("Slide " + countSlides);
            comboBox1.SelectedItem = null;
            BufferedPanel pSlide = new BufferedPanel()
            {
                Name = "pSlide" + Convert.ToString(countSlides),
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Parent = splitContainer3.Panel2,
            };
            pSlides.Add(pSlide);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeSlide = listBox1.SelectedIndex + 1;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string note = "Slide " + activeSlide;
                if (listBox1.Items[i].ToString() == note)
                {
                    activeSlide = i;
                    pSlides[activeSlide].Visible = true;
                }
                else pSlides[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = new RichTextBox()
            {
                Name = "richTextBox" + Convert.ToString(activeSlide),
                Text = "Введите ваш текст",
                BackColor = Color.WhiteSmoke,
                Parent = pSlides[activeSlide],
                Location = new Point(2,3),
            };
            richTextBox.MouseMove += RichTextBox_MouseMove;
            richTextBox.MouseUp += RichTextBox_MouseUp;
            richTextBox.MouseDown += RichTextBox_MouseDown;
            /*Label label = new Label()
            {
                Name = "x" + Convert.ToString(activeSlide),
                Text = "x", 
                Parent = pSlides[activeSlide].Controls["richTextBox" + Convert.ToString(activeSlide)],
                Location = new Point(86,80),
                BackColor = Color.White,
            };*/
        }

        private void RichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            mouseDown = true;
            x1 = e.X;
            y1 = e.Y;
        }

        private void RichTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            mouseDown = false;
        }

        private void RichTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (mouseDown)
            {
                x1 = e.X;
                y1 = e.Y;
                RichTextBox richTextBox = sender as RichTextBox;
                richTextBox.Location = new Point(x1, y1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox picture = new PictureBox()
                {
                    Image = Image.FromFile(openFileDialog1.FileName),
                    Name = "pictureBox" + Convert.ToString(activeSlide),
                    Parent = pSlides[activeSlide],
                };
            }
        }
    }
}
