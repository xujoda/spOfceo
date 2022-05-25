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
    public partial class Courses : MaterialForm
    {
        public Courses()
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

        private void Courses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            this.Hide();
            menu.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
    }
}
