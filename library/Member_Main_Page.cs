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
    public partial class Member_Main_Page : Form
    {
        public Member_Main_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Book_Request m1 = new Member_Book_Request();
            m1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Give_Book m1 = new Member_Give_Book();
            m1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Book_Request_Look m1 = new Member_Book_Request_Look();
            m1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m1 = new Form1();
            m1.ShowDialog();
            this.Close();
        }
    }
}
