using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace kourort.admin
{
    public partial class AdminQueriesType2Form : Form
    {
        public AdminQueriesType2Form()
        {
            InitializeComponent();
            AddDataGridTable();
        }
        /// <summary>
        /// Обновление таблицы
        /// </summary>
        private void AddDataGridTable()
        {
            dataGridView1.Rows.Clear();
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
                    query.CommandText = "SELECT `ID`, `process`, `query`, `user_ID` FROM `admin-queries` WHERE `type` = 2;";
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32(0).ToString();
                            dataGridView1.Rows[index].Cells[1].Value = reader.GetString(1).ToString();
                            dataGridView1.Rows[index].Cells[2].Value = reader.GetString(2).ToString();
                            dataGridView1.Rows[index].Cells[3].Value = reader.GetInt32(3).ToString();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Кнопка принять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(ID_TextBox.Text, out int ID))
            {
                if (kourortNameTextBox.Text.Length > 0)
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
                            int userID = 0;
                            int kourortID = 0;
                            query.CommandText = "SELECT count(*) FROM `admin-queries` WHERE `ID` = @id AND `type`=2";
                            query.Parameters.AddWithValue("@id", ID);
                            using (var reader = query.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetInt32(0) == 0)
                                    {
                                        MessageBox.Show("Такого ID не существует");
                                        return;
                                    }
                                }
                            }
                            query.Parameters.Clear();
                            query.CommandText = "UPDATE `kourort`.`admin-queries` SET `process` = 'Принято' WHERE (`ID` = @id)";
                            query.Parameters.AddWithValue("@id", ID);
                            query.ExecuteNonQuery();
                            query.Parameters.Clear();
                            query.CommandText = "SELECT max(`ID`) FROM `kourort`.`kourort`;";
                            query.Parameters.AddWithValue("@id", ID);
                            using (var reader = query.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    try
                                    {
                                        kourortID = reader.GetInt32(0) + 1;
                                    }
                                    catch
                                    {
                                        kourortID = 1;
                                    }
                                }
                            }
                            query.ExecuteNonQuery();
                            query.Parameters.Clear();
                            query.CommandText = "INSERT INTO `kourort`.`kourort` (`ID`, `age-10-people-count`, `age-11-people-count`, `age-12-people-count`, `age-13-people-count`, `age-14-people-count`, `age-15-people-count`, `age-16-people-count`, `age-17-people-count`, `Name`) VALUES (@kourortid, '0', '0', '0', '0', '0', '0', '0', '0', @kourortname);";
                            query.Parameters.AddWithValue("@kourortid", kourortID);
                            query.Parameters.AddWithValue("@kourortname", kourortNameTextBox.Text.Trim());
                            query.ExecuteNonQuery();
                            query.Parameters.Clear();//
                            query.CommandText = "SELECT `user_ID` FROM `kourort`.`admin-queries` WHERE (`ID` = @id)";
                            query.Parameters.AddWithValue("@id", ID);
                            using (var reader = query.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    userID = reader.GetInt32(0);
                                }
                            }
                            query.Parameters.Clear();
                            query.CommandText = "UPDATE `kourort`.`user` SET `kourort_ID` = @kourort WHERE (`ID` = @id);";
                            query.Parameters.AddWithValue("@id", userID);
                            query.Parameters.AddWithValue("@kourort", kourortID);
                            query.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите название лагеря");
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
            AddDataGridTable();
        }
        /// <summary>
        /// Кнопка отказать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(ID_TextBox.Text, out int ID))
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
                        query.CommandText = "SELECT count(*) FROM `admin-queries` WHERE `ID` = @id AND `type`=2";
                        query.Parameters.AddWithValue("@id", ID);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) == 0)
                                {
                                    MessageBox.Show("Такого ID не существует");
                                    return;
                                }
                            }
                        }
                        query.CommandText = "UPDATE `kourort`.`admin-queries` SET `process` = 'Отклонено' WHERE (`ID` = @id)";
                        query.Parameters.AddWithValue("@id", ID);
                        query.ExecuteNonQuery();
                    }
                }
            }
            AddDataGridTable();
        }
    }
}
