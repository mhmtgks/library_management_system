using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY_PROJECT
{
    public partial class Manager_Add_Book : Form
    {
        public Manager_Add_Book()
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
    }
}
