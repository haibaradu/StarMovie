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
    public partial class Director_Actor_Search : Form
    {
        private Director_Actor_Manage f;
        private string obj;
        public Director_Actor_Search(Director_Actor_Manage f,string s)
        {
            obj = s;
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    if (obj.Equals("Director"))
                        MessageBox.Show("Please enter the director's name!", "Enter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Please enter the actor's name!", "Enter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                for (int i = 0; i < f.getView().Rows.Count; i++)
                {
                    if (textBox1.Text.Equals(f.getView().Rows[i].Cells[0].Value))
                    {
                        f.getView().Rows[i].Selected = true;
                        f.getView().CurrentCell = f.getView().Rows[i].Cells[0];
                        this.Close();
                        return;
                    }
                }
                MessageBox.Show(obj + " doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }

        private void Director_Actor_Search_Load(object sender, EventArgs e)
        {
            this.Text = "Search" + obj;
            this.label1.Text = obj + " name:";
        }
    }
}
