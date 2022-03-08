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
    }
}
