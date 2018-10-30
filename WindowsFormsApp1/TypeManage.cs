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
    public partial class TypeManage : Form
    {
        private string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";

        public TypeManage()
        {
            InitializeComponent();
        }

        private void TypeManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;
            F5();
            if (this.dataGridView1.Rows.Count == 0)
                button2.Enabled = false;
        }

        private void F5()
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT typeName AS type FROM type";
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxType.Text == "") {
                MessageBox.Show("Please enter a type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (textBoxType.Text.Equals(dataGridView1.Rows[i].Cells[0].Value))
                {
                    MessageBox.Show("Type exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxType.Text = "";
                    return;
                }
            }
            cmd.CommandText = "INSERT INTO type VALUES(NULL,'" + textBoxType.Text + "');";
            cmd.ExecuteNonQuery();
            con.Close();
            F5();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            button2.Enabled = true;
            MessageBox.Show("Add succeeded!", "Success", MessageBoxButtons.OK);
            textBoxType.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            if (dataGridView1.CurrentRow.Selected)
            {
                string type = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                cmd.CommandText = "SELECT typeId FROM type WHERE typeName='" + type + "';";
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                int typeId = Convert.ToInt32(r["typeId"]);
                r.Close();

                DialogResult dr = MessageBox.Show("Are you sure to delete it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    cmd.CommandText = "DELETE FROM movie_has_type WHERE typeId=" + typeId + ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM type WHERE typeName='" + type + "';";
                    cmd.ExecuteNonQuery();

                    con.Close();
                    F5();
                    if (this.dataGridView1.Rows.Count == 0)
                        button2.Enabled = false;
                    MessageBox.Show("Delete succeeded!", "Success", MessageBoxButtons.OK);
                }
                else if (dr == DialogResult.Cancel)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("No row is selected to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxType.Text == "")
            {
                MessageBox.Show("Please enter a type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (textBoxType.Text.Equals(dataGridView1.Rows[i].Cells[0].Value))
                {
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    textBoxType.Text = "";
                    return;
                }
            }
            MessageBox.Show("Type isn't found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
