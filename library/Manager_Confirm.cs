﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Manager_Confirm : Form
    {
        public Manager_Confirm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Main_Page m1 = new Manager_Main_Page();
            m1.ShowDialog();
            this.Close();
        }

        private void Manager_Confirm_Load(object sender, EventArgs e)
        {
          DataSet d1 = library.dbworks.InfoPull("1","2");
            dataGridView1.DataSource = d1.Tables[0];
        }
    }
}
