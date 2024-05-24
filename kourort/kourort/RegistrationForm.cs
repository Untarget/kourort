using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kourort
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            
        }
        private void registrationTextBox_Click(object sender, EventArgs e)
        {
            if(validation())
            {
                if (!getExist())
                {
                    if (POST())
                    {
                        MessageBox.Show("Вы были успешно зарегестрированы!");
                    }
                    else
                    {
                        MessageBox.Show("К сожалению мы не можем зарегестрировать вас.\n Попробуйте снова или обратитесть к администратору");
                    }
                }
                else
                {
                    MessageBox.Show("К сожалению пользователь с таким логином уже существует.\n Выберите другой");
                }
            }
        }
        private bool POST()
        {
            int userType = 0;
            int userID=0;
            if(KourortUserCheckBox.Checked)
            {
                userType = 1;
            }
            if(UserCheckBox.Checked)
            {
                userType = 2;
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
                    query.CommandText = "INSERT INTO `kourort`.`user` (`secondname`, `firstname`, `lastname`, `age`, `post_ID`) VALUES (@secondname, @firstname, @lastname, @age, @post_ID);";
                    query.Parameters.AddWithValue("@secondname", secondNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@firstname", firstNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@lastname", lastNameTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@age", ageTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@post_ID", userType);
                    query.ExecuteNonQuery();
                    query.Parameters.Clear();
                    query.CommandText = "SELECT max(ID) FROM `user`";
                    using(var reader = query.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            userID=reader.GetInt32(0);
                        }
                    }
                    query.CommandText = "INSERT INTO `kourort`.`authorization` (`user_ID`, `login`, `password`) VALUES(@userid, @login, @password);";
                    query.Parameters.AddWithValue("@userid", userID);
                    query.Parameters.AddWithValue("@login", loginTextBox.Text.Trim());
                    query.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim());
                    query.ExecuteNonQuery();
                    return true;
                }
            }
            return false;
        }
        private bool getExist()
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
                    query.CommandText = "SELECT COUNT(*) FROM `authorization` WHERE `login` = @login;";
                    query.Parameters.AddWithValue("@login", loginTextBox.Text.Trim()); 
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
                                if (passwordTextBox.Text.Trim().Length > 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Укажите ваш пароль");
                                    return false;
                                }
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
            return false;
        }
        private void KourortUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(KourortUserCheckBox.Checked)
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
        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.Show();
        }
    }
}
