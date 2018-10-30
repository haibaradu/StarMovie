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
    public partial class Director_Actor_Manage : Form
    {
        private string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
        private string obj;

        public Director_Actor_Manage(string s)
        {
            obj = s;
            InitializeComponent();
        }

        private void DirectorManage_Load(object sender, EventArgs e)
        {
            this.Text = obj + "Management";
            this.groupBox_add.Text = "Add " + obj;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;
            F5();
            if (this.dataGridView1.Rows.Count == 0)
                button4.Enabled = false;
        }

        private void F5()
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            if(obj.Equals("Director"))
                cmd.CommandText = "SELECT directorName AS name,directorSex AS sex,directorNationality as nationality FROM director";
            else
                cmd.CommandText=  "SELECT actorName AS name,actorSex AS sex,actorNationality as nationality FROM actor";
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please enter completely!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MySqlConnection con = new MySqlConnection(connect);
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (textBox1.Text.Equals(dataGridView1.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show(obj + " exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        return;
                    }
                }
                string sex;
                if (radioButton1.Checked == true)
                    sex = "male";
                else
                    sex = "female";

                cmd.CommandText = "INSERT INTO " + obj + " VALUES(NULL,'" + textBox1.Text + "','" + sex + "','" + textBox2.Text + "');";
                cmd.ExecuteNonQuery();
                con.Close();
                F5();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                button4.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Add succeeded!", "Success", MessageBoxButtons.OK);
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form f = new Director_Actor_Search(this, obj);
                f.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect);
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                if (dataGridView1.CurrentRow.Selected)
                {
                    if (obj.Equals("Director"))
                    {
                        string director = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd.CommandText = "SELECT directorId FROM director WHERE directorName='" + director + "';";
                        MySqlDataReader r = cmd.ExecuteReader();
                        r.Read();
                        int directorId = Convert.ToInt32(r["directorId"]);
                        r.Close();
                        DialogResult dr = MessageBox.Show("are you sure to delete it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.OK)
                        {
                            cmd.CommandText = "UPDATE movie SET movieDirectorID=NULL WHERE movieDirectorID=" + directorId + ";";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DELETE FROM director WHERE directorName='" + director + "';";
                            cmd.ExecuteNonQuery();
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            
                        }
                    }
                    else if (obj.Equals("Actor"))
                    {
                        string actor = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd.CommandText = "SELECT actorId FROM actor WHERE actorName='" + actor + "';";
                        MySqlDataReader r = cmd.ExecuteReader();
                        r.Read();
                        int actorId = Convert.ToInt32(r["actorId"]);
                        r.Close();

                        DialogResult dr = MessageBox.Show("are you sure to delete it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.OK)
                        {
                            cmd.CommandText = "DELETE FROM actor_has_movie WHERE actorId=" + actorId + ";";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM actor WHERE actorName='" + actor + "';";
                        cmd.ExecuteNonQuery();
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            
                        }
                    }
                    con.Close();
                    F5();
                    if (this.dataGridView1.Rows.Count == 0)
                        button4.Enabled = false;
                    //MessageBox.Show("Delete succeeded!", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("No row is selected to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form f = new Director_Actor_Modify(this.dataGridView1,obj);
            f.ShowDialog();
            int i = this.dataGridView1.CurrentRow.Index;
            F5();
            dataGridView1.Rows[i].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
        }

        public DataGridView getView()
        {
            return this.dataGridView1;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
