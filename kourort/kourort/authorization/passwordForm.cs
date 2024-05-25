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
    public partial class passwordForm : Form
    {
        public passwordForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Trim().Length > 0)
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
                        query.CommandText = "UPDATE `kourort`.`authorization` SET `password` = @password WHERE (`user_ID` = @id);";
                        query.Parameters.AddWithValue("@id", Cookies.ID);
                        query.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim()); 
                        query.ExecuteNonQuery();
                    }
                }
                this.Close();
                ResetPasswordForm reset = new ResetPasswordForm();
                reset.Close();
                AuthorizationForm form = new AuthorizationForm();
                form.Show();
            }
            else
            {
                MessageBox.Show("Введите новый пароль");
            }            
        }
        private void passwordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.Show();
        }
    }
}
