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
    public partial class CreatePeopleKourortForm : Form
    {
        public CreatePeopleKourortForm()
        {
            InitializeComponent();
            
        }
       
        private void CreatePeopleKourortForm_Load(object sender, EventArgs e)
        {
            AddInfo();
        }
        private void AddInfo()
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
                    query.CommandText = "SELECT `age-10-people-count`, `age-11-people-count`, `age-12-people-count`, `age-13-people-count`, `age-14-people-count`, `age-15-people-count`, `age-16-people-count`, `age-17-people-count` FROM `kourort` WHERE `ID` = @kourortid ";
                    query.Parameters.AddWithValue("@kourortid", Cookies.kourort_ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            age10TextBox.Text = reader.GetValue(0).ToString();
                            age11TextBox.Text = reader.GetValue(1).ToString();
                            age12TextBox.Text = reader.GetValue(2).ToString();
                            age13TextBox.Text = reader.GetValue(3).ToString();
                            age14TextBox.Text = reader.GetValue(4).ToString();
                            age15TextBox.Text = reader.GetValue(5).ToString();
                            age16TextBox.Text = reader.GetValue(6).ToString();
                            age17TextBox.Text = reader.GetValue(7).ToString();
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(validation())
            {
                SetInfo();
                MessageBox.Show("Данные были изменены");
            }
        }
        private bool validation()
        {
            if(Int32.TryParse(age10TextBox.Text.Trim(), out int age10))
            {
                if (Int32.TryParse(age11TextBox.Text.Trim(), out int age11))
                {
                    if (Int32.TryParse(age12TextBox.Text.Trim(), out int age12))
                    {
                        if (Int32.TryParse(age13TextBox.Text.Trim(), out int age13))
                        {
                            if (Int32.TryParse(age14TextBox.Text.Trim(), out int age14))
                            {
                                if (Int32.TryParse(age15TextBox.Text.Trim(), out int age15))
                                {
                                    if (Int32.TryParse(age16TextBox.Text.Trim(), out int age16))
                                    {
                                        if (Int32.TryParse(age17TextBox.Text.Trim(), out int age17))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Введите количество человек с возрастом 17 лет");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Введите количество человек с возрастом 16 лет");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Введите количество человек с возрастом 15 лет");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите количество человек с возрастом 14 лет");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите количество человек с возрастом 13 лет");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите количество человек с возрастом 12 лет");
                    }
                }
                else
                {
                    MessageBox.Show("Введите количество человек с возрастом 11 лет");
                }
            }
            else
            {
                MessageBox.Show("Введите количество человек с возрастом 10 лет");
            }
            return false;
        }
        private void SetInfo()
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
                    query.CommandText = "UPDATE `kourort`.`kourort` SET `age-10-people-count` = @age10, `age-11-people-count` = @age11, `age-12-people-count` = @age12, `age-13-people-count` = @age13, `age-14-people-count` = @age14, `age-15-people-count` = @age15, `age-16-people-count` = @age16, `age-17-people-count` = @age17 WHERE (`ID` = @id);";
                    query.Parameters.AddWithValue("@age10", age10TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age11", age11TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age12", age12TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age13", age13TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age14", age14TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age15", age15TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age16", age16TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age17", age17TextBox.Text.Trim());
                    query.Parameters.AddWithValue("@id", Cookies.kourort_ID);
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
