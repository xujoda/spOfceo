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
    public partial class TestCreator : MaterialForm
    {
        public string subject;
        public int count = 1;
        public int numQue = 1;
        int note = 0;

        public TestCreator()
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
            materialLabel5.Text = Convert.ToString(numQue);
        }

        private void TestCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e) // завершить создание теста
        {
            MessageBox.Show("Тест успешно создан и сохранён!");
            Test test = new Test();
            this.Hide();
            test.Show();
        }

        private void materialFlatButton4_Click(object sender, EventArgs e) // Сохранение вопроса, внесение в бд
        {
            numericUpDown1.Enabled = false;
            int tQ = comboBox1.SelectedIndex;
            note++;
            SqlConnection connection = new SqlConnection(diplom.Properties.Settings.Default.connectDB);
            SqlCommand addTh = new SqlCommand();
            SqlCommand addQue = new SqlCommand();
            SqlCommand addAns = new SqlCommand();

            addTh.CommandType = System.Data.CommandType.Text;
            addTh.CommandText = "INSERT INTO Themes(subject, theme, countQ) values ('" + subject +
                "','" + richTextBox1.Text + "','" + numericUpDown1.Value + "')";
            addTh.Connection = connection;

            addQue.CommandType = System.Data.CommandType.Text;
            addQue.CommandText = "INSERT INTO Questions(id_theme, question, typeQue) values " + "((select id " +
                "from Themes where theme = '" + richTextBox1.Text + "'),'" + richTextBox2.Text + "', " + tQ + ")";
            addQue.Connection = connection;
            connection.Open();
            if (numQue == 1) addTh.ExecuteNonQuery();
            addQue.ExecuteNonQuery();
            connection.Close();
            addAnswer();
            MessageBox.Show("Вопрос успешно сохранён!");
        }

        private void materialFlatButton2_Click(object sender, EventArgs e) // следующий вопрос
        {
            count = Convert.ToInt32(numericUpDown1.Value);
            if (numQue == count) MessageBox.Show("Это последний вопрос. Завершите тест!");
            else
            {
                if (note == 0) MessageBox.Show("Сохраните текущий вопрос, преждем чем продолжить!");
                else
                {
                    numQue++;
                    materialLabel5.Text = Convert.ToString(numQue);
                    openQ.Visible = false;
                    oneAns.Visible = false;
                    fewAns.Visible = false;
                    materialRadioButton1.Checked = false;
                    materialRadioButton2.Checked = false;
                    materialRadioButton3.Checked = false;
                    materialRadioButton4.Checked = false;
                    materialCheckBox1.Checked = false;
                    materialCheckBox2.Checked = false;
                    materialCheckBox3.Checked = false;
                    materialCheckBox4.Checked = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    richTextBox2.Clear();
                    comboBox1.Text = "Тип вопроса";
                }
                note = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Открытый вопрос")
                openQ.Visible = true;
            else openQ.Visible = false;
            if (comboBox1.SelectedItem == "Один ответ")
                oneAns.Visible = true;
            else oneAns.Visible = false;
            if (comboBox1.SelectedItem == "Несколько ответов")
                fewAns.Visible = true;
            else fewAns.Visible = false;

        }

        private void addAnswer()
        {
            SqlConnection connection = new SqlConnection(diplom.Properties.Settings.Default.connectDB);
            SqlCommand addAns = new SqlCommand();
            addAns.CommandType = System.Data.CommandType.Text;
            addAns.Connection = connection;
            connection.Open();
            if (comboBox1.SelectedIndex == 0) // Открытый вопрос
            {
                addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox5.Text + "', 1)";
                addAns.ExecuteNonQuery();
            }
            if (comboBox1.SelectedIndex == 1) // Один вариант ответа
            {
                if (materialRadioButton1.Checked == true) // 1
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox1.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox1.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialRadioButton2.Checked == true) //2
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox2.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox2.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialRadioButton3.Checked == true) //3
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox3.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox3.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialRadioButton4.Checked == true) //4
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox4.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox4.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }
            }

            if (comboBox1.SelectedIndex == 2) // Несколько вариантов ответа
            {
                if (materialCheckBox1.Checked == true) // 1
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox6.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox6.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialCheckBox2.Checked == true) //2
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox7.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox7.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialCheckBox3.Checked == true) //3
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox8.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox8.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }

                if (materialCheckBox4.Checked == true) //4
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox9.Text + "', 1)";
                    addAns.ExecuteNonQuery();
                }
                else
                {
                    addAns.CommandText = "INSERT INTO Answers(id_question, answer, result) values " +
                "((select id from Questions where question = '" + richTextBox2.Text + "'),'" + textBox9.Text + "', 0)";
                    addAns.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }


    }
}
