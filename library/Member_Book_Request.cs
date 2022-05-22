using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Member_Book_Request : Form
    {
        public Member_Book_Request()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = library.dbworks.BookPull(textBox1.Text);
            dataGridView1.DataSource = ds1.Tables[0];
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try{ 
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); }
            catch (ArgumentOutOfRangeException) { }
            catch (InvalidCastException) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           
            try
            {
                bool x = library.dbworks.AddInfo(a, library.dbworks.idmembers, library.dbworks.namemembers, "2");
                if (x == false) { MessageBox.Show("book not avaible "); }
                else MessageBox.Show("added");
            }
            catch (ArgumentOutOfRangeException) { }
        }
    }
}
