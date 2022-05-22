using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Member_Book_Request_Look : Form
    {
        public Member_Book_Request_Look()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Main_Page m1 = new Member_Main_Page();
            m1.ShowDialog();
            this.Close();
        }

        private void Member_Book_Request_Look_Load(object sender, EventArgs e)
        {
            DataSet d1 = library.dbworks.InfoPull(library.dbworks.idmembers, "*");
            dataGridView1.DataSource = d1.Tables[0];
            DataGridViewColumn column = dataGridView1.Columns[3];
            column.Width = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "1")
                {
                    textBox1.Text = "accepted";
                }
                else if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "2")
                {
                    textBox1.Text = "waiting";
                }
                else if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "3")
                {
                    textBox1.Text = "given back";
                }
                else if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "0")
                {
                    textBox1.Text = "rejected";
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (InvalidCastException) { }

        }
    }
}
