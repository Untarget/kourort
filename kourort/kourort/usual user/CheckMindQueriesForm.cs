using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class CheckMindQueriesForm : Form
    {
        public CheckMindQueriesForm()
        {
            InitializeComponent();
        }
        private List<Int32> ID = new List<Int32>();
        private List<String> firstname = new List<String>();
        private List<String> secondname = new List<String>();
        private List<String> lastname = new List<String>();
        private void CheckMindQueriesForm_Load(object sender, EventArgs e)
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
                    query.CommandText = "SELECT `ID`, `firstname`, `secondname`, `lastname` FROM `children` WHERE `user_id` = @id";
                    query.Parameters.AddWithValue("@id", Cookies.ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID.Add(reader.GetInt32(0));
                            firstname.Add(reader.GetString(1));
                            secondname.Add(reader.GetString(2));
                            lastname.Add(reader.GetString(3));
                        }
                    }
                    for (int i = 0; i < ID.Count; i++)
                    {
                        query.Parameters.Clear();
                        query.CommandText = "SELECT `process`, `query` FROM `kourort-queries` WHERE `children_ID` = @childrenid";
                        query.Parameters.AddWithValue("@childrenid", ID[i]);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    if (reader.GetString(0).Length > 0)
                                    {
                                        var index = dataGridView1.Rows.Add();
                                        dataGridView1.Rows[index].Cells[0].Value = reader.GetString(0);
                                        dataGridView1.Rows[index].Cells[1].Value = reader.GetString(1);
                                        dataGridView1.Rows[index].Cells[2].Value = secondname[i] + " " + firstname[i] + " " + lastname[i];
                                    }
                                }
                                catch
                                {

                                }

                            }
                        }
                    }

                }
            }
        }
    }
}
