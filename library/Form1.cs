using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library;
using LIBRARY_PROJECT;

namespace library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if ("1" == dbworks.Login_Check(textBox1.Text))
            {
                this.Hide();
                Member_Main_Page m1 = new Member_Main_Page();
                m1.ShowDialog();
                this.Close();
            }
            else if ("2" == dbworks.Login_Check(textBox1.Text))
            {
                this.Hide();
                Manager_Main_Page m1 = new Manager_Main_Page();
                m1.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("ID didn't found Please Register !!"); }
        }
    }
}
