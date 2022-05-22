using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Manager_Give_Book : Form
    {
        public Manager_Give_Book()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager_Main_Page m1 = new Manager_Main_Page();
            m1.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = library.dbworks.BookPull(textBox1.Text);
            dataGridView1.DataSource = ds1.Tables[0];
           /* if (ds1.Tables[0].Rows.Count == 0)
                MessageBox.Show("Kayıt Yok");*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = library.dbworks.MemberPull(textBox2.Text);
            dataGridView2.DataSource = ds1.Tables[0];

        }
    }
}
