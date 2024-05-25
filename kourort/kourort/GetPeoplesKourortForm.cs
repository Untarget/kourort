using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class GetPeoplesKourortForm : Form
    {
        public GetPeoplesKourortForm()
        {
            InitializeComponent();
        }

        private void GetPeoplesKourortForm_Load(object sender, EventArgs e)
        {
            AddDataGridTable();
        }
        private List<Int32> queryID = new List<Int32>();
        private List<Int32> userID = new List<Int32>();
        private List<Int32> kourortID = new List<Int32>();
        private List<String> queryProcess = new List<String>();
        private List<String> queryText = new List<String>();
        private int userIDInt=0;
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
                queryID.Clear();    
                queryProcess.Clear();
                queryText.Clear();
                userID.Clear();
                kourortID.Clear();
                conn.Open();
                using (var query = conn.CreateCommand())
                {
                    query.CommandText = "SELECT `ID`, `process`, `query`, `children_ID`, `kourort_ID` FROM `kourort-queries` WHERE `kourort_ID`=@id;";
                    query.Parameters.AddWithValue("@id", Cookies.kourort_ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            queryID.Add(reader.GetInt32(0));
                            queryProcess.Add(reader.GetString(1));
                            queryText.Add(reader.GetString(2));
                            userID.Add(reader.GetInt32(3));
                            kourortID.Add(reader.GetInt32(4));
                        }
                    }
                    for (int i = 0; i < userID.Count; i++)
                    {
                        query.Parameters.Clear();
                        query.CommandText = "SELECT `secondname`, `firstname`, `lastname` from `children` WHERE ID=@id";
                        query.Parameters.AddWithValue("@id", userID[i]);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var index = dataGridView1.Rows.Add();
                                dataGridView1.Rows[index].Cells[0].Value = queryID[i];
                                dataGridView1.Rows[index].Cells[1].Value = queryProcess[i];
                                dataGridView1.Rows[index].Cells[2].Value = queryText[i];
                                dataGridView1.Rows[index].Cells[3].Value = reader.GetString(0) +" "+ reader.GetString(1)+" " + reader.GetString(2);
                            }

                        }

                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(ID_TextBox.Text.Trim(), out int ID))
            {
                if (ID_Exist(in ID))
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
                            query.CommandText = "SELECT count(*) FROM `kourort-queries` WHERE `kourort_ID`=@id;";
                            query.Parameters.AddWithValue("@id", Cookies.kourort_ID);
                            using(var reader = query.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if(reader.GetInt32(0)==0)
                                    {
                                        MessageBox.Show("Выберите доступный вам ID");
                                        return;
                                    }
                                }
                            }
                            query.Parameters.Clear();
                            query.CommandText = "SELECT * FROM `kourort-user-list` WHERE `kourort_ID`=@kourortid AND `children_ID`=@id ";
                            query.Parameters.AddWithValue("@id", userID[userIDInt]);
                            query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                            using (var reader = query.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetInt32(0) >0)
                                    {
                                        return;
                                    }
                                }
                            }
                            query.Parameters.Clear();
                            query.CommandText = "UPDATE `kourort`.`kourort-queries` SET `process` = 'Принято' WHERE (`ID` = @id);";
                            query.Parameters.AddWithValue("@id", ID);
                            query.ExecuteNonQuery();
                            query.Parameters.Clear();
                            int maxValue = 0;
                            query.CommandText = "SELECT max(`ID`) FROM `kourort-user-list`;";
                                using(var reader = query.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    try
                                    {
                                        maxValue = reader.GetInt32(0) + 1;
                                    }
                                    catch
                                    {
                                        maxValue = 1;
                                    }

                                }
                            }
                            query.CommandText = "INSERT INTO `kourort`.`kourort-user-list` (`kourort_ID`, `children_ID`, `ID`) VALUES (@kourortid, @id, @maxvalue);";
                            query.Parameters.AddWithValue("@id", userID[userIDInt]);
                            query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                            query.Parameters.AddWithValue("@maxvalue", maxValue);
                            query.ExecuteNonQuery();
                        }
                    }
                    AddDataGridTable();
                }
                else
                {
                    MessageBox.Show("Такого ID не существует");
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
        }
        private bool ID_Exist(in int ID)
        {
            for (int i = 0; i < queryID.Count; i++)
            {
                if (queryID[i] == ID)
                {
                    userIDInt = i;
                    return true;
                }

            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(ID_TextBox.Text.Trim(), out int ID))
            {
                if (ID_Exist(in ID))
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
                            query.CommandText = "UPDATE `kourort`.`kourort-queries` SET `process` = 'Отказано' WHERE (`ID` = @id);";
                            query.Parameters.AddWithValue("@id", ID);
                            query.ExecuteNonQuery();
                            query.Parameters.Clear();
                            query.CommandText = "DELETE FROM `kourort`.`kourort-user-list` WHERE (`kourort_ID` = @kourortid) and (`children_ID` = @id);";
                            query.Parameters.AddWithValue("@id", userID[userIDInt]);
                            query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                            query.ExecuteNonQuery();
                        }
                    }
                    AddDataGridTable();
                }
                else
                {
                    MessageBox.Show("Такого ID не существует");
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
        }
    }
}