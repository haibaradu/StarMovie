using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieCommentSystem
{
    public partial class root : Form
    {
        public root()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new MovieManage();
            this.Hide();
            f.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new TypeManage();
            this.Hide();
            f.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Director_Actor_Manage("Director");
            this.Hide();
            f.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new Director_Actor_Manage("Actor");
            this.Hide();
            f.ShowDialog();
            this.Visible = true;
        }

        private void root_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_login login = new Form_login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
