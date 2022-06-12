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
        bool pickedPictureBox;
        bool pickedRichTextBox;
        string pickedPB;
        string pickedRTB;
        List<Panel> pSlides = new List<Panel>();
        List<int> textBoxElements = new List<int>();
        List<int> pictureElements = new List<int>();

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

        private void Presentation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            if (comboBox1.SelectedIndex == 1)
            {
                deleteSlide();
            }
        }

        public void newSlide()
        {
            countSlides++;
            listBox1.Items.Add("Slide " + countSlides);
            comboBox1.SelectedItem = null;
            Panel pSlide = new Panel()
            {
                Name = "pSlide" + Convert.ToString(countSlides),
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Parent = splitContainer3.Panel2,
            };
            pSlides.Add(pSlide);
        }

        public void deleteSlide()
        {
            if (countSlides > 0)
            {
                if (activeSlide == (countSlides - 1))
                {
                    clearPanel();
                    pSlides.Remove(pSlides[activeSlide]);
                }
                listBox1.Items.Remove(listBox1.Items[activeSlide]);
                countSlides--;
            }
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
            if (countSlides > 0)
            {
                var k = 1;
                textBoxElements.Add(k);
                RichTextBox richTextBox = new RichTextBox()
                {
                    Name = "richTextBox" + Convert.ToString(activeSlide) + Convert.ToString(textBoxElements.Count),
                    Text = "Введите ваш текст",
                    BackColor = Color.WhiteSmoke,
                    Parent = pSlides[activeSlide],
                    Location = new Point(2, 3),
                };
                richTextBox.MouseMove += RichTextBox_MouseMove;
                richTextBox.MouseUp += RichTextBox_MouseUp;
                richTextBox.MouseDown += RichTextBox_MouseDown;
                richTextBox.ContextMenuStrip = materialContextMenuStrip1;
            }
            else MessageBox.Show("Сначала создайте слайд!");
        }

        private void RichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (e.Button == MouseButtons.Right) // Сохранение имени выбранного элемента для изменения
            {
                RichTextBox textBox = sender as RichTextBox;
                pickedRTB = textBox.Name;
            }
        }

        private void RichTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void RichTextBox_MouseMove(object sender, MouseEventArgs e)
        {
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
            if (countSlides > 0)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var k = 1;
                    pictureElements.Add(k);
                    PictureBox picture = new PictureBox()
                    {
                        Image = Image.FromFile(openFileDialog1.FileName),
                        Name = "pictureBox" + Convert.ToString(activeSlide) + Convert.ToString(pictureElements.Count),
                        Parent = pSlides[activeSlide],
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };
                    picture.MouseDown += Picture_MouseDown;
                    picture.MouseUp += Picture_MouseUp;
                    picture.MouseMove += Picture_MouseMove;
                    picture.ContextMenuStrip = materialContextMenuStrip2;
                }
            }
            else MessageBox.Show("Сначала создайте слайд!");
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (e.Button == MouseButtons.Right) // Сохранение имени выбранного элемента для изменения
            {
                PictureBox picture = sender as PictureBox;
                pickedPB = picture.Name;
                Console.WriteLine(pickedPB);
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                x1 = e.X;
                y1 = e.Y;
                PictureBox picture = sender as PictureBox;
                picture.Location = new Point(x1, y1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearPanel();
        }

        private void clearPanel()
        {
            pSlides[activeSlide].Controls.Clear();
            pickedRTB = "";
            pickedPB = "";
            pickedPictureBox = false;
            pickedRichTextBox = false;
            trackBar1.Value = 26;
            trackBar1.Visible = false;
        }

        private void changeSizeElement()
        {
            var k = 1;
            Size startSize;
            if (trackBar1.Value < 26) k = -1;
            if (pickedPictureBox == true)
            {
                startSize = pSlides[activeSlide].Controls[pickedPB].Size;
                pSlides[activeSlide].Controls[pickedPB].Width = startSize.Width + trackBar1.Value * k;
                pSlides[activeSlide].Controls[pickedPB].Height = startSize.Height + trackBar1.Value * k;
            }
            if (pickedRichTextBox == true)
            {
                startSize = pSlides[activeSlide].Controls[pickedRTB].Size;
                pSlides[activeSlide].Controls[pickedRTB].Width = startSize.Width + trackBar1.Value * k;
                pSlides[activeSlide].Controls[pickedRTB].Height = startSize.Height + trackBar1.Value * k;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            changeSizeElement();
        }
        
        private void выбратьЭлементToolStripMenuItem_Click(object sender, EventArgs e) // выбор текстбокса
        {
            pickedRichTextBox = true;
            trackBar1.Visible = true;
        }

        private void снятьВыделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pickedRTB = "";
            pickedRichTextBox = false;
            trackBar1.Visible = false;
            trackBar1.Value = 26;
        }
        
        private void выделитьЭлементToolStripMenuItem_Click(object sender, EventArgs e) // выбор картинки
        {
            pickedPictureBox = true;
            trackBar1.Visible = true;
        }

        private void снятьВыделениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pickedPB = "";
            pickedPictureBox = false;
            trackBar1.Visible = false;
            trackBar1.Value = 26;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pickedRichTextBox == true)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    pSlides[activeSlide].Controls[pickedRTB].Font = fontDialog1.Font;
                }
            }
            else MessageBox.Show("Выделите текстовое поле!");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                savePresentation();
        }

        private void savePresentation()
        {
            
        }
    }
}
