using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class SelectMindKourortForm : Form
    {
        public SelectMindKourortForm()
        {
            InitializeComponent();
            CreateKourortLabel.Enabled = false;
            CreateKourortTextBox.Enabled = false;
            addKourortsList();
            addKourortsListBox();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (KourortCheckBox.Checked)
            {
                if (CreateKourortTextBox.Text.Trim().Length > 0)
                {
                    CreateKourort();
                    MessageBox.Show("Ваша заявка была отправлена администрации");
                    this.Close();
                }
            }
            else
            {
                if (kourortListBox.SelectedIndex >= 0)
                {
                    SelectKourort();
                    MessageBox.Show("Ваша заявка была отправлена администрации");
                    this.Close();
                }
            }
        }
        private List<string> kourortsName = new List<string>();
        private List<Int32> kourortsID = new List<Int32>();
        private void addKourortsList()
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
                    query.CommandText = "SELECT `ID`, `name` FROM `kourort`";
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kourortsID.Add(reader.GetInt32(0));
                            kourortsName.Add(reader.GetString(1));
                        }

                    }
                }
            }
        }
        private void addKourortsListBox()
        {
            kourortListBox.Items.AddRange(kourortsName.ToArray());
        }

        private void SelectKourort()
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

                    query.CommandText = "INSERT INTO `kourort`.`admin-queries` (`process`, `query`, `user_ID`, `user_post_ID`, `kourort_ID`, type) VALUES (@process, @query, @userid, @idpost, @idkourort, 1);";
                    query.Parameters.AddWithValue("@userid", Cookies.ID);
                    query.Parameters.AddWithValue("@idpost", Cookies.post);
                    query.Parameters.AddWithValue("@idkourort", kourortListBox.SelectedIndex + 1);
                    query.Parameters.AddWithValue("@process", "Не рассмотрено");
                    query.Parameters.AddWithValue("@query", $"Прошу зачислить меня, как представителя организации \"{kourortListBox.SelectedItem.ToString()}\".");
                    query.ExecuteNonQuery();

                }
            }
        }
        private void KourortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateKourortLabel.Enabled)
            {
                CreateKourortLabel.Enabled = false;
                CreateKourortTextBox.Enabled = false;
                ChooseKourotLabel.Enabled = true;
                kourortListBox.Enabled = true;
                NextButton.Text = "Зарегестрировать";
            }
            else
            {
                CreateKourortLabel.Enabled = true;
                CreateKourortTextBox.Enabled = true;
                ChooseKourotLabel.Enabled = false;
                kourortListBox.Enabled = false;
                NextButton.Text = "Выбрать";
            }
        }
        private void CreateKourort()
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

                    query.CommandText = "INSERT INTO `kourort`.`admin-queries` (`process`, `query`, `user_ID`, `user_post_ID`, type) VALUES (@process, @query, @userid, @idpost, 2);";
                    query.Parameters.AddWithValue("@userid", Cookies.ID);
                    query.Parameters.AddWithValue("@idpost", Cookies.post);
                    query.Parameters.AddWithValue("@process", "Не рассмотрено");
                    query.Parameters.AddWithValue("@query", $"Прошу зарегестрировать организацию {CreateKourortTextBox.Text.Trim()} и зачислить меня, как ее представителя.");
                    query.ExecuteNonQuery();

                }
            }
        }
    }
}
