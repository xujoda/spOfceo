using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace diplom
{
    public partial class PersonalPage : MaterialForm
    {
        public PersonalPage()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey600, Primary.Grey500,
                Primary.Grey400, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void PP_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            AuthForm auth = new AuthForm();
            this.Hide();
            auth.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("+79821504328; xujoda@gmail.com Avdeev Vadim");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
