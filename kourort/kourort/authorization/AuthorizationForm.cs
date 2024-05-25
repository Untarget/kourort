using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Warehouse;

namespace kourort
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void POST_Button_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (authorization(loginTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    if (SetCookies(loginTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                    {
                        switch (Cookies.post)
                        {
                            case 1:
                                {
                                    this.Visible = false;
                                    GeneralAdminForm generalAdminForm = new GeneralAdminForm();
                                    generalAdminForm.ShowDialog();
                                    break;
                                }
                            case 2:
                                {
                                    this.Visible = false;
                                    GeneralKourortUser managerGeneralForm = new GeneralKourortUser();
                                    managerGeneralForm.ShowDialog();
                                    break;
                                }
                            case 3:
                                {
                                    this.Visible = false;
                                    GeneralUserForm generalUsualEmployer = new GeneralUserForm();
                                    generalUsualEmployer.ShowDialog();
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так :(\nОбратитесь к администратору сети");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким паролем и логиным не существует.\nПопробуйте еще раз.");
                }
            }
            else
            {
                MessageBox.Show("Корректно заполните данные для входа");
            }
        }



        /// <summary>
        /// Проверка на заполнение пароля и логина
        /// </summary>
        /// <returns></returns>
        private bool validate()
        {
            if (loginTextBox.Text.Trim().Length > 0)
            {
                if (passwordTextBox.Text.Trim().Length > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
                return false;
            }
        }
        /// <summary>
        /// Проверка на существование пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool authorization(in string login, in string password)
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
                    query.CommandText = "SELECT COUNT(*) FROM `authorization` WHERE (`login` = @login AND `password` = @password);";
                    query.Parameters.AddWithValue("@login", login);
                    query.Parameters.AddWithValue("@password", password);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Ввод данных в Cookies
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="post"></param>
        /// <returns>
        /// <param name="Cookies.firstname"></param>
        /// <param name="Cookies.secondname"></param>
        /// <param name="Cookies.lastname"></param>
        /// <param name="Cookies.ID"></param>
        /// </returns>
        private bool SetCookies(in string login, in string password)
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
                    query.Parameters.Clear();
                    query.CommandText = "SELECT `secondname`, `firstname`, `lastname`, `post_ID`, `ID`,`kourort_ID` FROM `user` WHERE `ID`=(SELECT `user_ID` FROM `authorization` WHERE (`login` = @login AND `password` = @password));";
                    query.Parameters.AddWithValue("@login", login);
                    query.Parameters.AddWithValue("@password", password);
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cookies.secondname = reader.GetString(0);
                            if (Cookies.secondname.Length > 0)
                            {
                                Cookies.firstname = reader.GetString(1);
                                if (Cookies.firstname.Length > 0)
                                {
                                    Cookies.lastname = reader.GetString(2);
                                    if (reader.GetInt32(3) > 0 && reader.GetInt32(4) > 0)
                                    {
                                        Cookies.post = reader.GetInt32(3);
                                        Cookies.ID = reader.GetInt32(4);
                                        try
                                        {
                                            Cookies.kourort_ID = reader.GetInt32(5);
                                        }
                                        catch
                                        {

                                        }
                                        
                                        return true;
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistrationForm form = new RegistrationForm();
            form.Show();

        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ResetPasswordForm form = new ResetPasswordForm();
            form.Show();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
