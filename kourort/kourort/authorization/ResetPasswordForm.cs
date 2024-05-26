using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (validation())
                if (getExist())
                {
                    this.Hide();
                    passwordForm form = new passwordForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Вы не прошли проверку");
                }
        }
        private bool getExist()
        {
            int post = 0;
            if (UserCheckBox.Checked)
            {
                post = 3;
            }
            if (KourortUserCheckBox.Checked)
            {
                post = 2;
            }
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
                    query.CommandText = "SELECT `ID` FROM `user` WHERE `secondname`=@secondname AND `firstname` = @firstname AND `age` = @age AND `post_ID` = @post;";
                    query.Parameters.AddWithValue("@secondname", secondNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@firstname", firstNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@lastname", lastNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age", ageTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@post", post);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                if (reader.GetInt32(0) > 0)
                                {
                                    Cookies.ID = reader.GetInt32(0);
                                    goto Next;
                                }
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                Next:
                    query.CommandText = "SELECT COUNT(*) FROM `authorization` WHERE `login` = @login AND `user_ID` = @id;";
                    query.Parameters.AddWithValue("@login", loginTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@id", Cookies.ID);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                if (reader.GetInt32(0) > 0)
                                    return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private bool validation()
        {
            if (KourortUserCheckBox.Checked || UserCheckBox.Checked)
            {
                if (secondNameTextBox.Text.Trim().Length > 0)
                {
                    if (firstNameTextBox.Text.Trim().Length > 0)
                    {
                        if (Int32.TryParse(ageTextBox.Text.Trim(), out int age))
                        {
                            if (loginTextBox.Text.Trim().Length > 0)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Укажите ваш логин");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Укажите ваш возраст");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Укажите ваше имя");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Укажите вашу фамилию");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Укажите кто вы");
                return false;
            }
        }
        private void KourortUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (KourortUserCheckBox.Checked)
            {
                if (UserCheckBox.Checked)
                {
                    UserCheckBox.Checked = false;
                }
            }
        }
        private void UserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UserCheckBox.Checked)
            {
                if (KourortUserCheckBox.Checked)
                {
                    KourortUserCheckBox.Checked = false;
                }
            }
        }
        private void ResetPasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            AuthorizationForm form1 = new AuthorizationForm();
            form1.Show();

        }
    }
}
