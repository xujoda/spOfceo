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
    public partial class Test : MaterialForm
    {
        public string subject;
        public Test()
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

        private void Test_FormClosed(object sender, FormClosedEventArgs e)
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
            TestCreator creator = new TestCreator();
            creator.subject = this.subject;
            this.Hide();
            creator.Show();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            TestPass passTest = new TestPass();
            this.Hide();
            passTest.Show();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "diplomDBDataSet.Statistic". При необходимости она может быть перемещена или удалена.
            this.statisticTableAdapter.Fill(this.diplomDBDataSet.Statistic);

        }
    }
}
