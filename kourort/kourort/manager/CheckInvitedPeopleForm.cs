using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class CheckInvitedPeopleForm : Form
    {
        public CheckInvitedPeopleForm()
        {
            InitializeComponent();
        }
        private void CheckInvitedPeopleForm_Load(object sender, EventArgs e)
        {
            AddDataGridTable();
        }
        private List<Int32> ID = new List<Int32>();
        private List<Int32> ChildrenID = new List<Int32>();
        private List<String> ChildrenFirstname = new List<String>();
        private List<String> ChildrenSecondname = new List<String>();
        private List<String> ChildrenLastname = new List<String>();
        private List<Int32> ChildrenAge = new List<Int32>();
        private List<Int32> PersonID = new List<Int32>();
        private List<String> PersonFirstname = new List<String>();
        private List<String> PersonSecondname = new List<String>();
        private List<String> PersonLastname = new List<String>();
        private int children_ID;
        private void AddDataGridTable()
        {
            dataGridView1.Rows.Clear();
            ID.Clear();
            ChildrenID.Clear();
            ChildrenFirstname.Clear();
            ChildrenSecondname.Clear();
            ChildrenLastname.Clear();
            ChildrenAge.Clear();
            PersonID.Clear();
            PersonFirstname.Clear();
            PersonSecondname.Clear();
            PersonLastname.Clear();
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
                    query.Parameters.Clear();
                    query.CommandText = "SELECT `children_ID`, `ID` FROM `kourort-user-list` WHERE `kourort_ID` = @id";
                    query.Parameters.AddWithValue("@id", Cookies.kourort_ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChildrenID.Add(reader.GetInt32(0));
                            ID.Add(reader.GetInt32(1));
                        }
                    }
                    for (int i = 0; i < ChildrenID.Count; i++)
                    {
                        query.Parameters.Clear();
                        query.CommandText = "SELECT `firstname`, `secondname`, `lastname`, `age`, `user_ID` FROM `children` WHERE `ID` = @id";
                        query.Parameters.AddWithValue("@id", ChildrenID[i]);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChildrenFirstname.Add(reader.GetString(0));
                                ChildrenSecondname.Add(reader.GetString(0));
                                ChildrenLastname.Add(reader.GetString(0));
                                ChildrenAge.Add(reader.GetInt32(0));
                                PersonID.Add(reader.GetInt32(0));
                            }
                        }
                    }
                    for (int i = 0; i < PersonID.Count; i++)
                    {
                        query.Parameters.Clear();
                        query.CommandText = "SELECT `firstname`, `secondname`, `lastname` FROM `user` WHERE `ID` = @id";
                        query.Parameters.AddWithValue("@id", PersonID[i]);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonFirstname.Add(reader.GetString(0));
                                PersonSecondname.Add(reader.GetString(0));
                                PersonLastname.Add(reader.GetString(0));
                            }
                        }
                    }
                    for (int i = 0; i < ChildrenID.Count; i++)
                    {
                        var index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells[0].Value = ID[i];
                        dataGridView1.Rows[index].Cells[1].Value = ChildrenSecondname[i];
                        dataGridView1.Rows[index].Cells[2].Value = ChildrenFirstname[i];
                        dataGridView1.Rows[index].Cells[3].Value = ChildrenLastname[i];
                        dataGridView1.Rows[index].Cells[4].Value = ChildrenAge[i];
                        dataGridView1.Rows[index].Cells[5].Value = PersonSecondname[i];
                        dataGridView1.Rows[index].Cells[6].Value = PersonFirstname[i];
                        dataGridView1.Rows[index].Cells[7].Value = PersonLastname[i];
                    }
                    ChildrenSecondname.Clear();
                    ChildrenFirstname.Clear();
                    ChildrenLastname.Clear();
                    ChildrenAge.Clear();
                    PersonSecondname.Clear();
                    PersonFirstname.Clear();
                    PersonLastname.Clear();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(ID_TextBox.Text.Trim(), out int ID))
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
                        query.CommandText = "SELECT `children_ID` FROM `kourort-user-list` WHERE `ID` = @id AND kourort_ID = @kourortid";
                        query.Parameters.AddWithValue("@id", ID);
                        query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                children_ID = reader.GetInt32(0);
                            }
                        }
                        query.Parameters.Clear();
                        query.CommandText = "DELETE FROM `kourort`.`kourort-user-list` WHERE `ID` = @id AND kourort_ID = @kourortid";
                        query.Parameters.AddWithValue("@id", ID);
                        query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                        query.ExecuteNonQuery();
                        query.Parameters.Clear();
                        query.CommandText = "UPDATE `kourort`.`kourort-queries` SET `process` = 'Отказано' WHERE (`kourort_ID` = @kourortid) and (`children_ID` = @childrenid);";
                        query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                        query.Parameters.AddWithValue("@childrenid", children_ID);
                        query.ExecuteNonQuery();
                        AddDataGridTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }

        }

    }
}
