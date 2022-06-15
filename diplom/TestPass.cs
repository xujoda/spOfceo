using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;

namespace diplom
{

    public partial class TestPass : MaterialForm
    {
        class Question
        {
            public int id_question { get; set; }
            public int ID_theme { get; set; }
            public string question { get; set; }
            public int typeQue { get; set; }

            public Question()
            {
                id_question = 0;
                ID_theme = 0;
                question = "Unknown question";
                typeQue = 0;
            }
            public Question(int id, int id_theme, string quest, int typeQ)
            {
                id_question = id;
                ID_theme = id_theme;
                question = quest;
                typeQue = typeQ;
            }
        }

        class Answer
        {
            public int id_ans { get; set; }
            public int ID_question { get; set; }
            public string answer { get; set; }
            public bool result { get; set; }

            public Answer(int id, int id_quest, string ans, bool res)
            {
                id_ans = id;
                ID_question = id_quest;
                answer = ans;
                result = res;
            }
        }


        int numberQue = 0;
        double rightAns = 0;
        List<Question> questions = new List<Question>();
        List<Answer> answers = new List<Answer>();

        public TestPass()
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
            using (SqlConnection connection = new SqlConnection())  // Выбор предмета
            {
                connection.ConnectionString = diplom.Properties.Settings.Default.connectDB;
                connection.Open();
                using (SqlCommand dataDb = new SqlCommand("SELECT * from users", connection))
                {
                    using (SqlDataReader dataReader = dataDb.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            string subj = (string)dataReader["subject"];
                            comboBox1.Items.Add(subj);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Заполнение тем
        {
            listBox1.Items.Clear();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = diplom.Properties.Settings.Default.connectDB;
                connection.Open();
                string note = Convert.ToString(comboBox1.SelectedItem);
                using (SqlCommand dataDb = new SqlCommand("SELECT * from Themes where subject = '" +
                    note + "'", connection)) // Заполнение тем
                {
                    using (SqlDataReader dataReader = dataDb.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            listBox1.Items.Add((string)dataReader["theme"]);
                        }
                    }
                }
                connection.Close();
            }
        }

        public void questDB(string theme) // заполнение листа вопросами из бд
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = diplom.Properties.Settings.Default.connectDB;
                connection.Open();
                string note = theme;
                using (SqlCommand dataDb = new SqlCommand("SELECT * from Questions where id_theme = (select id from Themes " +
                "where theme like '" + note + "')", connection))
                {
                    using (SqlDataReader dataReader = dataDb.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            questions.Add(new Question(
                                dataReader.GetInt32(dataReader.GetOrdinal("id")),
                                dataReader.GetInt32(dataReader.GetOrdinal("id_theme")),
                                dataReader.GetString(dataReader.GetOrdinal("question")),
                                dataReader.GetInt32(dataReader.GetOrdinal("typeQue"))
                                ));
                        }
                    }
                }
                connection.Close();
            }
        }

        public void answerDB()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = diplom.Properties.Settings.Default.connectDB;
                for (int i = 0; i < questions.Count; i++)
                {
                    int note = questions[i].id_question;
                    using (SqlCommand dataDb = new SqlCommand("SELECT * from Answers where id_question = " + note + "", connection))
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = dataDb.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                answers.Add(new Answer(
                                    dataReader.GetInt32(dataReader.GetOrdinal("id")),
                                    dataReader.GetInt32(dataReader.GetOrdinal("id_question")),
                                    dataReader.GetString(dataReader.GetOrdinal("answer")),
                                    dataReader.GetBoolean(dataReader.GetOrdinal("result"))
                                    ));
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }  // заполнение листа ответами из БД по выбранной теме

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // Заполнение вопросов в форму
        {
            listBox2.Items.Clear();
            string note = Convert.ToString(listBox1.SelectedItem);
            questDB(note);
            foreach (Question quest in questions)
            {
                listBox2.Items.Add(quest.question);
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e) // Pass the selected test
        {
            panel1.Visible = false;
            materialLabel1.Text = Convert.ToString(comboBox1.SelectedItem); // subject
            materialLabel2.Text = Convert.ToString(listBox1.SelectedItem); // theme
            materialLabel3.Text = questions[numberQue].question;
            panel2.Visible = true;
            answerDB();
            if (questions[numberQue].typeQue == 0)
            {
                textBox2.Focus();
                panel3.Visible = true;
            }
            else panel3.Visible = false;
            if (questions[numberQue].typeQue == 1)
            {
                OneAnswer();
                panel4.Visible = true;
            }
            else panel4.Visible = false;
            if (questions[numberQue].typeQue == 2)
            {
                FewAnswers();
                panel5.Visible = true;
            }
            else panel5.Visible = false;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) // next question 
        {
            numberQue++;
            if (numberQue <= questions.Count - 1)
            {
                materialLabel3.Text = questions[numberQue].question;
                if (questions[numberQue].typeQue == 0)     // Открытый вопрос
                {
                    textBox2.Clear();
                    textBox2.Enabled = true;
                    textBox2.Focus();
                    panel3.Visible = true;
                }
                else panel3.Visible = false;
                if (questions[numberQue].typeQue == 1) // One Answer
                {
                    materialRadioButton1.Checked = false;
                    materialRadioButton2.Checked = false;
                    materialRadioButton3.Checked = false;
                    materialRadioButton4.Checked = false;
                    materialRadioButton1.Enabled = true;
                    materialRadioButton2.Enabled = true;
                    materialRadioButton3.Enabled = true;
                    materialRadioButton4.Enabled = true;
                    OneAnswer();
                    panel4.Visible = true;
                }
                else panel4.Visible = false;
                if (questions[numberQue].typeQue == 2)     // Few answer
                {
                    FewAnswers();
                    materialCheckBox1.Checked = false;
                    materialCheckBox2.Checked = false;
                    materialCheckBox3.Checked = false;
                    materialCheckBox4.Checked = false;
                    materialCheckBox1.Enabled = true;
                    materialCheckBox2.Enabled = true;
                    materialCheckBox3.Enabled = true;
                    materialCheckBox4.Enabled = true;
                    panel5.Visible = true;
                }
                else panel5.Visible = false;
            }
            else
            {
                MessageBox.Show("Тест завершён! Набранный балл: " + rightAns + "/" + questions.Count);
                saveStat();
                TestPass test = new TestPass();
                test.Show();
                this.Hide();
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e) // check answer
        {
            if (questions[numberQue].typeQue == 0)
            {
                checkOpenQue();
                textBox2.Enabled = false;
            }
            if (questions[numberQue].typeQue == 1)
            {
                checkOneAns();
                materialRadioButton1.Enabled = false;
                materialRadioButton2.Enabled = false;
                materialRadioButton3.Enabled = false;
                materialRadioButton4.Enabled = false;
            }
            if (questions[numberQue].typeQue == 2)
            {
                checkFewAnswers();
                materialCheckBox1.Enabled = false;
                materialCheckBox2.Enabled = false;
                materialCheckBox3.Enabled = false;
                materialCheckBox4.Enabled = false;
            }
            MessageBox.Show("Ответ сохранён! Перейдите к следующему вопросу!"); // добавить блок замены ответа чтоб не абузить
        }


        private void checkOpenQue()
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].ID_question == questions[numberQue].id_question)
                {
                    if (textBox2.Text == answers[i].answer && answers[i].result == true)
                        rightAns++;
                }
            }
        }

        int rightOneAnswer;
        private void OneAnswer()
        {
            int i = 0;
            for (int j = 1; j <= 4; j++)
                for (; i < answers.Count; i++)
                {
                    if (answers[i].ID_question == questions[numberQue].id_question)
                    {
                        panel4.Controls["materialRadioButton" + Convert.ToString(j)].Text = answers[i].answer;
                        if (answers[i].result == true) rightOneAnswer = j;
                        i++;
                        break;
                    }
                }
        }

        private void checkOneAns()
        {
            if (materialRadioButton1.Checked == true && rightOneAnswer == 1) rightAns++;
            if (materialRadioButton2.Checked == true && rightOneAnswer == 2) rightAns++;
            if (materialRadioButton3.Checked == true && rightOneAnswer == 3) rightAns++;
            if (materialRadioButton4.Checked == true && rightOneAnswer == 4) rightAns++;
        }

        int[] rightFewAnswer = new int[4] { 0, 0, 0, 0 };
        int countRoa = 0;
        private void FewAnswers()
        {
            int i = 0;
            for (int j = 1; j <= 4; j++)
                for (; i < answers.Count; i++)
                {
                    if (answers[i].ID_question == questions[numberQue].id_question)
                    {
                        panel5.Controls["materialCheckBox" + Convert.ToString(j)].Text = answers[i].answer;
                        if (answers[i].result == true)
                        {
                            rightFewAnswer[j] = 1;
                            countRoa++;
                        }
                        i++;
                        break;
                    }
                }
        }

        private void checkFewAnswers()
        {
            double score = 1;
            if (countRoa == 2) score = 0.5;
            if (countRoa == 3) score = 0.33;
            if (countRoa == 4) score = 0.25;
            if (materialCheckBox1.Checked == true && rightFewAnswer[1] == 1) rightAns += score;
            if (materialCheckBox2.Checked == true && rightFewAnswer[2] == 1) rightAns += score;
            if (materialCheckBox3.Checked == true && rightFewAnswer[3] == 1) rightAns += score;
            if (materialCheckBox4.Checked == true && rightFewAnswer[4] == 1) rightAns += score;
        }


        private void saveStat()
        {
            SqlConnection connection = new SqlConnection(diplom.Properties.Settings.Default.connectDB);
            SqlCommand addStat = new SqlCommand();
            addStat.CommandType = System.Data.CommandType.Text;
            addStat.CommandText = "INSERT INTO Statistic(name, subject, theme, score, maxScore, class) values ('" + textBox1.Text + "','"
                + comboBox1.SelectedItem + "','" + listBox1.SelectedItem + "'," + rightAns + "," + questions.Count + 
                ",'"+textBox3.Text+"')";
            addStat.Connection = connection;
            connection.Open();
            addStat.ExecuteNonQuery();
            connection.Close();
        }

        private void Courses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // MainMenu
        {
            Test test = new Test();
            this.Hide();
            test.Show();
        }
    }
}
