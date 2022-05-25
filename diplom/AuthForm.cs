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
using System.Data.SqlClient;

namespace diplom
{
    public partial class AuthForm : MaterialForm
    {
        public string subject;
        public AuthForm()
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

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите логин!");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите пароль!");
            }
            if (folderBrowserDialog1.SelectedPath == "")
            {
                MessageBox.Show("Укажите путь каталога, если его нет, то создайте новый!");
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = diplom.Properties.Settings.Default.connectDB;
                connection.Open();

                using (SqlCommand dataDb = new SqlCommand("SELECT * from users", connection))
                {
                    using (SqlDataReader dataReader = dataDb.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (textBox1.Text == (string)dataReader["login"])
                            {
                                if (textBox2.Text == (string)dataReader["password"])
                                {
                                    subject = (string)dataReader["subject"];
                                    MainMenu menu = new MainMenu();
                                    this.Hide();
                                    menu.Show();
                                    menu.subject = subject;
                                    menu.folderBrowserDialog1.SelectedPath = this.folderBrowserDialog1.SelectedPath;
                                }
                                else { MessageBox.Show("Введён неверный пароль!"); break; }
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
        public string path;
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                materialLabel5.Text = folderBrowserDialog1.SelectedPath;
                path = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
