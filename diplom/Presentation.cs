using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace diplom
{
    public partial class Presentation : MaterialForm
    {
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

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            listView1.Items.Add("Slide " + countSlides);
            comboBox1.SelectedItem = null;
            comboBox1.Text = "Слайд";
            Panel pSlide = new Panel()
            {
                Name = "pSlide" + Convert.ToString(countSlides),
                BackColor = Color.Red,
                Dock = DockStyle.Fill,
                Parent = splitContainer3.Panel2,
            };
            pSlides.Add(pSlide);
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked == true)
                {
                    activeSlide = i;
                    pSlides[activeSlide].Visible = true;
                    Console.WriteLine("### " + activeSlide + " $$$ " + pSlides[i].Name);
                }
                else pSlides[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = new RichTextBox()
            {
                Name = "richTextBox" + Convert.ToString(activeSlide),
                Text = "Текущий слайд: " + activeSlide,
                Parent = pSlides[activeSlide],
            };
            //splitContainer3.Panel2.Controls["pSlide" + activeSlide].Controls.Add(richTextBox);
            //Controls["pSlide" + activeSlide].Controls.Add(Controls["richTextBox" + activeSlide]);
        }
    }
}
