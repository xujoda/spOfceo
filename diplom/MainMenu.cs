using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;

namespace diplom
{
    public partial class MainMenu : MaterialForm
    {
        public string subject;
        public MainMenu()
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

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) //library

        {
            Library library = new Library();
            this.Hide();
            if (this.folderBrowserDialog1.SelectedPath != "")
            {
                library.materialLabel2.Text = this.folderBrowserDialog1.SelectedPath;
                library.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(this.folderBrowserDialog1.SelectedPath);
                foreach (var file in dir.GetFiles())
                {
                    library.listBox1.Items.Add(file.Name);
                }
            }
            //library.folderBrowserDialog1.SelectedPath = path;
            library.Show();
        }

        public string path;

        private void materialRaisedButton2_Click(object sender, EventArgs e) //paint
        {
            Paint paint = new Paint();
            paint.saveFileDialog1.InitialDirectory = this.folderBrowserDialog1.SelectedPath;
            paint.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            this.Hide();
            paint.Show();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e) //tests
        {
            Test test = new Test();
            test.subject = subject;
            test.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            this.Hide();
            test.Show();
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e) // logout
        {
            this.Hide();
            AuthForm auth = new AuthForm();
            auth.Show();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e) // personalPage
        {
            PersonalPage pp = new PersonalPage();
            this.Hide();
            pp.Show();
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e) // courses
        {
            Courses cours = new Courses();
            this.Hide();
            cours.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            cours.Show();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            Process avs = new Process();
            avs.StartInfo.FileName = @"C:\Program Files (x86)\AVS4YOU\AVSVideoEditor\AVSVideoEditor.exe";
            avs.Start();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            Presentation presentation = new Presentation();
            this.Hide();
            presentation.Show();
        }
    }
}
