using System;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                textBox2.Text = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (InvalidCastException)
            {
                textBox1.Text = "";
                textBox2.Text = "";


            }
        }
        bool x = true;
        private void button1_Click(object sender, EventArgs e)  // accept
        {
            bool x = true;
            x=library.dbworks.confirmRequest("1", (string)dataGridView1.SelectedRows[0].Cells[3].Value, (string)dataGridView1.SelectedRows[0].Cells[4].Value);
            if (x == false) { MessageBox.Show("book not avaible"); }
            DataSet d1 = library.dbworks.InfoPull("1", "2");
            dataGridView1.DataSource = d1.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e) // ignore
        {
           library.dbworks.confirmRequest("0", (string)dataGridView1.SelectedRows[0].Cells[3].Value, (string)dataGridView1.SelectedRows[0].Cells[4].Value);
            DataSet d1 = library.dbworks.InfoPull("1", "2");
            dataGridView1.DataSource = d1.Tables[0];
        }
    }
    
}
