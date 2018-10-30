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
    public partial class MovieInfoSearch : Form
    {
        private string name;
        private int mode;
        private bool close;

        public MovieInfoSearch(int i)
        {
            InitializeComponent();
            mode = i;
        }

        private void MovieDirectorSearch_Load(object sender, EventArgs e)
        {
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;

            string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            if (mode == 1)
            {
                cmd.CommandText = "SELECT typeName AS type FROM type";
            }
            else if (mode == 2)
            {
                cmd.CommandText = "SELECT directorName AS name FROM director";
            }
            else if (mode == 3)
            {
                cmd.CommandText = "SELECT actorName AS name FROM actor";
            }
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            close = false;
            name = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        public string getName()
        {
            return name;
        }

        public bool isClose()
        {
            return close;
        }
    }
}
