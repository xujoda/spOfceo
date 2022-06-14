using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.IO;
using System.Xml.Serialization;

namespace diplom
{
    public partial class Presentation : MaterialForm
    {
        Slides slides = new Slides();
        AttributesSlides attributesSlides = new AttributesSlides();
        richTB richTextBox = new richTB();
        bool mouseDown;
        int x1;
        int y1;
        int countSlides = 0;
        int activeSlide = 0;
        bool pickedPictureBox;
        bool pickedRichTextBox;
        string pickedPB;
        string pickedRTB;

        private void deserialization(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(AttributesSlides));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                AttributesSlides? atrSlds = deserializer.Deserialize(fs) as AttributesSlides;
                if (atrSlds != null)
                {
                    attributesSlides = atrSlds;
                }
            }
            XmlSerializer deserializer2 = new XmlSerializer(typeof(richTB));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                richTB? rtb = deserializer.Deserialize(fs) as richTB;
                if (rtb!= null)
                {
                    richTextBox = rtb;
                }
            }
            uploadSlides();
        }

        private void uploadSlides()
        {
            countSlides = 0;
            listBox1.Items.Clear();
            if (activeSlide != 0)
            {
                clearPanel();
            }
            checkOff();
            for (int i = 0; i < attributesSlides.attributesEl.Count; i++)
            {
                string note = "pSlide" + Convert.ToString(i + 1);
                if (attributesSlides.attributesEl[i].ToString() == note)
                {
                    newSlide();
                }
                note = attributesSlides.attributesEl[i].ToString();
                Console.WriteLine(note);
                if (note == "System.Windows.Forms.RichTextBox")
                {
                    newTextBox();
                }
            }
        }

        private void serialization(string path)
        {
            setAttributesSlides();
            XmlSerializer serializer = new XmlSerializer(typeof(AttributesSlides));
            using (FileStream fs = new FileStream("presentation1.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, attributesSlides);
            }
            XmlSerializer serializer2 = new XmlSerializer(typeof(richTB));
            // diplom.Presentation+richTB недоступен в силу его уровня защиты. Возможна обработка только общих типов."
            using (FileStream fs = new FileStream("presentation1.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, richTextBox);
            }
            MessageBox.Show("Презентация успешно сохранена!");
        }

        [Serializable]
        public class AttributesSlides
        {
            public List<string> attributesEl { get; set; } // SlideName, type, Element Name, location, text, font

            public AttributesSlides()
            {
                attributesEl = new List<string>();
            }

            public AttributesSlides(List<string> atrbtEl)
            {
                attributesEl = atrbtEl;
            }
        }

        [Serializable]
        class richTB : RichTextBox // попробовать без наследования, создавать отдельно РТБ и сохранять параметры, которые потом буду передавать
            // для создания этого же РТБ
        {
            public RichTextBox rtb { get; set; }

            public richTB() { }

            public richTB(string name, Control parent)
            {
                Name = name;
                Text = "Введите ваш текст";
                BackColor = Color.WhiteSmoke;
                Parent = parent;
                Location = new Point(2, 3);
            }

            public richTB(string name, string text, Control parent, Point location, Font font)
            {
                Name = name;
                Text = text;
                BackColor = Color.WhiteSmoke;
                Parent = parent;
                Location = location;
                Font = font;
            }
        }

        private void setAttributesSlides()
        {
            for (int i = 0; i < countSlides; i++)
            {
                attributesSlides.attributesEl.Add(slides.pSlides[i].Name.ToString());
                for (int j = 0; j < slides.pSlides[i].Controls.Count; j++)
                {
                    string note = slides.pSlides[i].Controls[j].GetType().ToString();
                    attributesSlides.attributesEl.Add(note);
                    if (note == "System.Windows.Forms.RichTextBox")
                    {
                        attributesSlides.attributesEl.Add(slides.pSlides[i].Controls[j].Name.ToString());
                        attributesSlides.attributesEl.Add(slides.pSlides[i].Controls[j].Location.ToString());
                        attributesSlides.attributesEl.Add(slides.pSlides[i].Controls[j].Text.ToString());
                        attributesSlides.attributesEl.Add(slides.pSlides[i].Controls[j].Font.ToString());
                    }
                }
            }
        }

        class Slides
        {
            public List<Panel> pSlides = new List<Panel>();
            public List<int> textBoxElements = new List<int>();
            public List<int> pictureElements = new List<int>();
        }

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
            slides.pSlides.Add(pSlide);
        }

        public void deleteSlide()
        {
            if (countSlides > 0)
            {
                if (activeSlide == (countSlides - 1))
                {
                    clearPanel();
                    slides.pSlides.Remove(slides.pSlides[activeSlide]);
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
                    slides.pSlides[activeSlide].Visible = true;
                }
                else slides.pSlides[i].Visible = false;
            }
            checkOff();
        }

        private void newTextBox()
        {
            if (countSlides > 0)
            {
                var k = 1;
                slides.textBoxElements.Add(k);
                string Name = "richTextBox" + Convert.ToString(activeSlide) + Convert.ToString(slides.textBoxElements.Count);
                Control Parent = slides.pSlides[activeSlide];
                Console.WriteLine(Name);
                richTB richTextBox = new richTB(Name,Parent);
                richTextBox.MouseMove += RichTextBox_MouseMove;
                richTextBox.MouseUp += RichTextBox_MouseUp;
                richTextBox.MouseDown += RichTextBox_MouseDown;
                richTextBox.ContextMenuStrip = materialContextMenuStrip1;
            }
            else MessageBox.Show("Сначала создайте слайд!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newTextBox();
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
                    slides.pictureElements.Add(k);
                    PictureBox picture = new PictureBox()
                    {
                        Image = Image.FromFile(openFileDialog1.FileName),
                        Name = "pictureBox" + Convert.ToString(activeSlide) + Convert.ToString(slides.pictureElements.Count),
                        Parent = slides.pSlides[activeSlide],
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
            slides.pSlides[activeSlide].Controls.Clear();
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
                startSize = slides.pSlides[activeSlide].Controls[pickedPB].Size;
                slides.pSlides[activeSlide].Controls[pickedPB].Width = startSize.Width + trackBar1.Value * k;
                slides.pSlides[activeSlide].Controls[pickedPB].Height = startSize.Height + trackBar1.Value * k;
            }
            if (pickedRichTextBox == true)
            {
                startSize = slides.pSlides[activeSlide].Controls[pickedRTB].Size;
                slides.pSlides[activeSlide].Controls[pickedRTB].Width = startSize.Width + trackBar1.Value * k;
                slides.pSlides[activeSlide].Controls[pickedRTB].Height = startSize.Height + trackBar1.Value * k;
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
            checkOff();
        }

        private void выделитьЭлементToolStripMenuItem_Click(object sender, EventArgs e) // выбор картинки
        {
            pickedPictureBox = true;
            trackBar1.Visible = true;
        }

        private void снятьВыделениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkOff();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pickedRichTextBox == true)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    slides.pSlides[activeSlide].Controls[pickedRTB].Font = fontDialog1.Font;
                }
            }
            else MessageBox.Show("Выделите текстовое поле!");
        }

        private void checkOff()
        {
            pickedRTB = "";
            pickedPB = "";
            pickedRichTextBox = false;
            pickedPictureBox = false;
            trackBar1.Visible = false;
            trackBar1.Value = 26;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Презентация (*.xml)|*.xml|Все файлы (*.*)|*.*";
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                serialization(saveFileDialog1.FileName);
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Презентация (*.xml)|*.xml|Все файлы (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                deserialization(openFileDialog1.FileName);
        }
    }
}
