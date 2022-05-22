using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Member_Give_Book : Form
    {
        public Member_Give_Book()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Main_Page m1 = new Member_Main_Page();
            m1.ShowDialog();
            this.Close();
        }

        private void Member_Give_Book_Load(object sender, EventArgs e)
        {
            DataSet ds1 = library.dbworks.InfoPull(library.dbworks.idmembers, "1");
            dataGridView1.DataSource = ds1.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string memberid = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string bookid = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            library.dbworks.AddInfo(bookid, memberid, name, "3");
        }
    }
}
