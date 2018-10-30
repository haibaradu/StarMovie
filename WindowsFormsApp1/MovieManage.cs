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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace MovieCommentSystem
{
    public partial class MovieManage : Form
    {
        private string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
        

        public MovieManage()
        {
            InitializeComponent();
           
        }

        private void MovieManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;
            Refresh();
        }

        private new void Refresh()
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT movieYear,movieTitle AS name FROM movie";
           // MySqlDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }
         
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            if (dataGridView1.CurrentRow.Selected)
            {
                string movie = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cmd.CommandText = "SELECT movieId FROM movie WHERE movieTitle='" + movie + "';";
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                int movieId = Convert.ToInt32(r["movieId"]);
                r.Close();
                DialogResult dr = MessageBox.Show("Are you sure to delete it?", "Warning" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if(dr == DialogResult.OK)
                {
                    cmd.CommandText = "DELETE FROM movie_has_type WHERE movieId=" + movieId + ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM actor_has_movie WHERE movieId=" + movieId + ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM user_like_movie WHERE movieId=" + movieId + ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM rate WHERE movieId=" + movieId + ";";

                    cmd.CommandText = "DELETE FROM movie WHERE movieTitle='" + movie + "';";
                    cmd.ExecuteNonQuery();
                    Refresh();
                    if (this.dataGridView1.Rows.Count == 0)
                        btnDelete.Enabled = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new MovieAdd();
            f.ShowDialog();
            Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (txtName.Text.Equals(dataGridView1.Rows[i].Cells[1].Value))
                {
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    txtName.Text = "";
                    return;
                }
            }
            MessageBox.Show("Movie isn't found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string movieTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Form f = new Info(movieTitle, "root");
            f.ShowDialog();
        }

        

        

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("E:\\test.pdf", FileMode.Create));
            doc.Open();

            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT movieId,movieTitle,movieYear,movieRate,ratedTimes,movieSummary FROM movie";
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                doc.Add(new Paragraph("movieId: " + Convert.ToString(r["movieId"])));
                doc.Add(new Paragraph("movieTitle: " + Convert.ToString(r["movieTitle"])));
                doc.Add(new Paragraph("movieYear: " + Convert.ToString(r["movieYear"])));
                doc.Add(new Paragraph("movieRate: " + Convert.ToString(r["movieRate"])));
                doc.Add(new Paragraph("ratedTimes: " + Convert.ToString(r["ratedTimes"])));
                doc.Add(new Paragraph("movieSummary: " + Convert.ToString(r["movieSummary"] + "\n" + "\n")));
            }
            r.Close();
            doc.Close();
            Process.Start("E:\\test.pdf");

        }
    }
}
