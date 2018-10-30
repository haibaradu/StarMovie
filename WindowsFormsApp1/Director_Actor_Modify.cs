using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MovieCommentSystem
{
    public partial class Director_Actor_Modify : Form
    {
        private DataGridView view;
        private string obj;

        static string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";

        public Director_Actor_Modify(DataGridView view,string s)
        {
            obj = s;
            InitializeComponent();
            this.view = view;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text == "" || textBoxNationality.Text == "")
                {
                    MessageBox.Show("Please enter completely!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MySqlConnection con = new MySqlConnection(connect);
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    if (textBoxName.Text.Equals(view.Rows[i].Cells[0].Value) && i != view.CurrentRow.Index)
                    {
                        MessageBox.Show(obj + " exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxName.Text = "";
                        textBoxNationality.Text = "";
                        return;
                    }
                }
                string sex;
                if (radioButton1.Checked == true)
                    sex = "male";
                else
                    sex = "female";

                if (obj.Equals("Director"))
                    cmd.CommandText = "UPDATE director SET directorName='" + textBoxName.Text + "',directorSex='" + sex + "',directorNationality='" + textBoxNationality.Text + "' WHERE directorName='" + this.Text + "';";
                else
                    cmd.CommandText = "UPDATE actor SET actorName='" + textBoxName.Text + "',actorSex='" + sex + "',actorNationality='" + textBoxNationality.Text + "' WHERE actorName='" + this.Text + "';";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Modify succeeded!", "Success", MessageBoxButtons.OK);
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DirectorModify_Load(object sender, EventArgs e)
        {
            this.groupBoxModify.Text = "Modify " + obj;

            this.Text = view.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text= view.CurrentRow.Cells[0].Value.ToString();
            textBoxNationality.Text = view.CurrentRow.Cells[2].Value.ToString();
            if (view.CurrentRow.Cells[1].Value.ToString().Equals("male"))
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }
    }
}
