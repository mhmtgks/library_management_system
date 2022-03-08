using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using library;

namespace LIBRARY_PROJECT
{
    public partial class Manager_Main_Page : Form
    {
        public Manager_Main_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Confirm m1 = new Manager_Confirm();
            m1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Give_Book m1 = new Manager_Give_Book();
            m1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Take_Book m1 = new Manager_Take_Book();
            m1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Add_Book m1 = new Manager_Add_Book();
            m1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m1 = new Form1();
            m1.ShowDialog();
            this.Close();
        }
    }
}
