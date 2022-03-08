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

namespace LIBRARY_PROJECT
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int type= 5;
            dbworks.Login_Check(textBox1.Text);
            
            if (type == 0)
            {
                this.Hide();
                Member_Main_Page m1 = new Member_Main_Page();
                m1.ShowDialog();
                this.Close();
            }
            else if (type == 1)
            {
                this.Hide();
                Manager_Main_Page m1 = new Manager_Main_Page();
                m1.ShowDialog();
                this.Close();

            }
        }
    }
}
