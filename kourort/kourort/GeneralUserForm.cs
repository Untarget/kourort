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
    public partial class GeneralUserForm : Form
    {
        public GeneralUserForm()
        {
            InitializeComponent();
        }

        private void GeneralUserForm_Load(object sender, EventArgs e)
        {
            setLabels();
        }
        private void setLabels()
        {
           firstnameLabel.Text = Cookies.firstname;
           lastnameLabel.Text = Cookies.lastname;
           secondnameLabel.Text = Cookies.secondname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrateChildForm registrateChildForm = new RegistrateChildForm();
            registrateChildForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckMindQueriesForm check = new CheckMindQueriesForm();
            check.Show();
        }

        private void GeneralUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
