using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class GeneralKourortUser : Form
    {
        public GeneralKourortUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectMindKourortForm form = new SelectMindKourortForm();
            form.Show();

        }
        private void getLabels()
        {
            firstnameLabel.Text = Cookies.firstname;
            lastnameLabel.Text = Cookies.lastname;
            secondnameLabel.Text = Cookies.secondname;
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
                    query.CommandText = "SELECT `name` FROM `kourort` WHERE ID = @id";
                    query.Parameters.AddWithValue("@id", Cookies.kourort_ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            kourortLabel.Text = reader.GetString(0);
                        }
                    }
                }
            }
        }
        private void GeneralKourortUser_Load(object sender, EventArgs e)
        {
            if (haveKourort())
            {
                button1.Enabled = false;
                CreatePeoples.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                CreatePeoples.Enabled = false;

            }
            getLabels();
        }
        private bool haveKourort()
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
                    query.CommandText = "SELECT count(kourort_ID) FROM `user` WHERE ID = @id";
                    query.Parameters.AddWithValue("@id", Cookies.ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) > 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CreatePeopleKourortForm form = new CreatePeopleKourortForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetPeoplesKourortForm form = new GetPeoplesKourortForm();
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CheckInvitedPeopleForm form = new CheckInvitedPeopleForm();
            form.Show();
        }

        private void GeneralKourortUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
