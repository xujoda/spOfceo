using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace diplom
{
    public partial class Library : MaterialForm
    {
        PowerPoint.Application objApp;
        PowerPoint.Presentations objPresSet;
        PowerPoint._Presentation objPres;
        PowerPoint.SlideShowSettings objSSS;
        private void ShowPresentation(string filename)//открытие презентации
        {
            objApp = new PowerPoint.Application();
            objPresSet = objApp.Presentations;
            string name = filename;
            objPres = objPresSet.Open(name);// что открываем            
            objSSS = objPres.SlideShowSettings;
            objSSS.StartingSlide = 1;
            objSSS.EndingSlide = 2;
            objSSS.Run();
        }

        public Library()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                Primary.Grey600, Primary.Grey500,
                Primary.Grey400, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
            menu.Show();
        }


        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                materialLabel2.Text = folderBrowserDialog1.SelectedPath;
            }
            DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            foreach (var file in dir.GetFiles())
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            foreach (var file in dir.GetFiles())
            {
                if (listBox1.SelectedItem.ToString() == file.Name)
                {
                    string fileType = file.Extension;
                    if ((fileType == ".txt") || (fileType == ".docx"))
                    {
                        richTextBox1.Visible = true;
                        richTextBox1.Text = File.ReadAllText(file.FullName);
                    }
                    else richTextBox1.Visible = false;
                    if (fileType == ".bmp" || fileType == ".jpg" || fileType == ".png")
                    {
                        pictureBox1.Visible = true;
                        pictureBox1.Image = Image.FromFile(file.FullName);
                    }
                    else pictureBox1.Visible = false;
                    if (fileType == ".m4v" || fileType == ".mp4")
                    {
                        winMediaPlayer.Visible = true;
                        winMediaPlayer.URL = file.FullName;
                    }
                    else winMediaPlayer.Visible = false;
                    if (fileType == ".pptx")
                    {
                        materialFlatButton1.Visible = true;
                        ShowPresentation(file.FullName);
                        GC.Collect();//очистка памяти
                    }
                    else materialFlatButton1.Visible = false;
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            objPres.Close();
            objApp.Quit();//показ окончен
        }
    }
}
