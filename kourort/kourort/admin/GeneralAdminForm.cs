﻿using kourort.admin;
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
using Warehouse;

namespace kourort
{
    public partial class GeneralAdminForm : Form
    {
        public GeneralAdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAllUsers form = new CheckAllUsers();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminQueriesType1Form form = new AdminQueriesType1Form();
            form.Show();
        }

        private void GeneralAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckAllUsers checkAllUsers = new CheckAllUsers();
            checkAllUsers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminQueriesType2Form form = new AdminQueriesType2Form();   
            form.Show();
        }

        private void GeneralAdminForm_Load(object sender, EventArgs e)
        {
            firstnameLabel.Text=Cookies.firstname;
            secondnameLabel.Text=Cookies.secondname;
            lastnameLabel.Text=Cookies.lastname;
        }
    }
}
