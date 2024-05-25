using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class RegistrateChildForm : Form
    {
        public RegistrateChildForm()
        {
            InitializeComponent();
            getListBox();
        }
        private List<Int32> ChildrenID = new List<Int32>();
        /*
        private void addDataGridView()
        {
            ChildrenID.Clear();
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "kourort",
                UserID = "root",
                Password = "QwertY1234",
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (var query = conn.CreateCommand())
                {
                    query.CommandText = "SELECT `ID`, `firstname`, `secondname`, `lastname`, `age` FROM `children` WHERE `user_ID` = @user";
                    query.Parameters.AddWithValue("@user", Cookies.ID);
                    int i = 0;
                    using(var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32(0).ToString();
                            dataGridView1.Rows[index].Cells[0].Style.Format = "";
                            dataGridView1.Rows[index].Cells[1].Value = reader.GetString(0);
                            dataGridView1.Rows[index].Cells[2].Value = reader.GetString(1);
                            dataGridView1.Rows[index].Cells[3].Value = reader.GetString(2);
                            dataGridView1.Rows[index].Cells[4].Value = reader.GetValue(3).ToString();
                        }
                    }
                }
            }
        }
        */
        private List<string> kourorts = new List<string>();
        private void getListBox()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "kourort",
                UserID = "root",
                Password = "QwertY1234",
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (var query = conn.CreateCommand())
                {
                    query.CommandText = "SELECT name FROM `kourort`;";
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kourorts.Add(reader.GetString(0));
                        }
                    }
                }
            }
            listBox1.Items.AddRange(kourorts.ToArray());

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = "localhost",
                    Database = "kourort",
                    UserID = "root",
                    Password = "QwertY1234",
                };
                using (var conn = new MySqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    using (var query = conn.CreateCommand())
                    {
                        int childrenID = 0;
                        query.CommandText = "SELECT max(`ID`) FROM `children`;";
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    childrenID = reader.GetInt32(0) + 1;
                                }
                                catch
                                {
                                    childrenID = 1;
                                }
                            }
                        }
                        int maxValue = 0;
                        query.CommandText = "INSERT INTO `kourort`.`children` (`ID`, `firstname`, `secondname`, `lastname`, `age`, `user_ID`) VALUES (@id, @firstname, @secondname, @lastname, @age, @user);";
                        query.Parameters.AddWithValue("@user", Cookies.ID);
                        query.Parameters.AddWithValue("@id", childrenID);
                        query.Parameters.AddWithValue("@firstname", firstNameTextBox.Text.Trim());
                        query.Parameters.AddWithValue("@secondname", secondNameTextBox.Text.Trim());
                        query.Parameters.AddWithValue("@lastname", lastNameTextBox.Text.Trim());
                        query.Parameters.AddWithValue("@age", ageTextBox.Text.Trim());
                        query.ExecuteNonQuery();
                        query.CommandText = "SELECT max(`ID`) FROM `kourort-queries`;";
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    maxValue = reader.GetInt32(0);
                                }
                                catch
                                {
                                    maxValue = 1;
                                }
                            }
                        }
                        query.Parameters.Clear();
                        query.CommandText = "INSERT INTO `kourort`.`kourort-queries` (`ID`, `process`, `query`, `kourort_ID`, `children_ID`) VALUES (@id, @process, @query, @kourortid, @childrenid);";
                        query.Parameters.AddWithValue("@id", maxValue);
                        query.Parameters.AddWithValue("@process", "На рассмотрении");
                        query.Parameters.AddWithValue("@kourortid", listBox1.SelectedIndex+1);
                        query.Parameters.AddWithValue("@childrenid", childrenID);
                        query.Parameters.AddWithValue("@query", $"Прошу зачислить моего сына,{secondNameTextBox.Text.Trim()}  {firstNameTextBox.Text.Trim()} {lastNameTextBox.Text.Trim()}, возраста {ageTextBox.Text.Trim()} лет");
                        query.ExecuteNonQuery ();
                    }
                }
            }
        }

        private bool validation()
        {

            if (firstNameTextBox.Text.Trim().Length > 0)
            {
                if (secondNameTextBox.Text.Trim().Length > 0)
                {
                    if (lastNameTextBox.Text.Trim().Length > 0)
                    {
                        if (Int32.TryParse(ageTextBox.Text.Trim(), out int age))
                        {
                            if (listBox1.SelectedIndex >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Выберите детский лагерь");
                            }

                            return true;

                        }
                        else
                        {
                            MessageBox.Show("Введите возраст");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите отчество");
                    }
                }
                else
                {
                    MessageBox.Show("Введите фамилию.");
                }
            }
            else
            {
                MessageBox.Show("Введите имя");
            }
            return false;
        }


        private void RegistrateChildForm_Load(object sender, EventArgs e)
        {

        }
    }
}
