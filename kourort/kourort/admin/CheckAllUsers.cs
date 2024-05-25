using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace kourort.admin
{
    public partial class CheckAllUsers : Form
    {
        public CheckAllUsers()
        {
            InitializeComponent();
        }

        private void ChangeUserInfoForm_Load(object sender, EventArgs e)
        {
            addDataGridTable();
        }
        private void addDataGridTable()
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
                    query.CommandText = "SELECT `ID`, `secondname`, `firstname`, `lastname`, `age`, `post_ID`, `kourort_ID` FROM `user`;";
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32(0);
                            dataGridView1.Rows[index].Cells[1].Value = reader.GetString(1);
                            dataGridView1.Rows[index].Cells[2].Value = reader.GetString(2);
                            dataGridView1.Rows[index].Cells[3].Value = reader.GetString(3);
                            dataGridView1.Rows[index].Cells[4].Value = reader.GetInt32(4);
                            dataGridView1.Rows[index].Cells[5].Value = reader.GetInt32(5);
                            try
                            {
                                dataGridView1.Rows[index].Cells[6].Value = reader.GetInt32(6);
                            }
                            catch { }

                        }
                    }
                }
            }
        }

    }

}
