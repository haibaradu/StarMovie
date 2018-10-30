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
    public partial class MovieAdd : Form
    {
        public MovieAdd()
        {
            InitializeComponent();
        }

        private void btnSearchType1_Click(object sender, EventArgs e)
        {
            MovieInfoSearch m = new MovieInfoSearch(1);
            m.ShowDialog();
            if (!m.isClose())
            {
                for (int i = 0; i < listBoxType.Items.Count; i++)
                {
                    if (m.getName().Equals(listBoxType.Items[i].ToString()))
                    {
                        MessageBox.Show("Type exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                listBoxType.Items.Add(m.getName());
            }
        }

        private void btnSearchDirector_Click(object sender, EventArgs e)
        {
            MovieInfoSearch m = new MovieInfoSearch(2);
            m.ShowDialog();
            if(!m.isClose())
                this.txtDirector.Text = m.getName();
        }

        private void btnSearchActor1_Click(object sender, EventArgs e)
        {
            MovieInfoSearch m = new MovieInfoSearch(3);
            m.ShowDialog();
            if (!m.isClose())
            {
                for (int i = 0; i < listBoxActor.Items.Count; i++)
                {
                    if (m.getName().Equals(listBoxActor.Items[i].ToString()))
                    {
                        MessageBox.Show("Actor exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                listBoxActor.Items.Add(m.getName());
            }
        }

        private void btnSearchPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            file.ShowDialog();
            if(!file.FileName.Equals(""))
                txtPicture.Text = file.FileName;
            if (txtPicture.Text != "")
                pictureBox1.Load(txtPicture.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string year = comboBox1.Text;
                string director = txtDirector.Text;
                string picture = txtPicture.Text.Replace("\\", "\\\\");
                string summary = txtSummary.Text;

                if (title == "" || year == "" || director == "" || picture == "" || summary == "")
                {
                    MessageBox.Show("Please enter completely!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=; ";
                MySqlConnection con = new MySqlConnection(connect);
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "SELECT directorId FROM director WHERE directorName='" + director + "';";
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                int directorId = Convert.ToInt32(r["directorId"]);
                r.Close();

                cmd.CommandText = "INSERT INTO movie VALUES(NULL,'" + title + "'," + year + ",0,0,'" + summary + "',NULL,'" + picture + "'," + directorId + ");";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT movieId FROM movie WHERE movieTitle='" + title + "';";
                r = cmd.ExecuteReader();
                r.Read();
                int movieId = Convert.ToInt32(r["movieId"]);
                r.Close();

                for (int i = 0; i < listBoxType.Items.Count; i++)
                {
                    string type = listBoxType.Items[i].ToString();
                    cmd.CommandText = "SELECT typeId FROM type WHERE typeName='" + type + "';";
                    r = cmd.ExecuteReader();
                    r.Read();
                    int typeId = Convert.ToInt32(r["typeId"]);
                    r.Close();
                    cmd.CommandText = "INSERT INTO movie_has_type VALUES(" + movieId + "," + typeId + ");";
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < listBoxActor.Items.Count; i++)
                {
                    string actor = listBoxActor.Items[i].ToString();
                    cmd.CommandText = "SELECT actorId FROM actor WHERE actorName='" + actor + "';";
                    r = cmd.ExecuteReader();
                    r.Read();
                    int actorId = Convert.ToInt32(r["actorId"]);
                    r.Close();
                    cmd.CommandText = "INSERT INTO actor_has_movie VALUES(" + actorId + "," + movieId + ");";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Add succeeded!", "Success", MessageBoxButtons.OK);
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }

        private void deleteType_MouseClick(object sender, MouseEventArgs e)
        {
            int i = listBoxType.SelectedIndex;
            listBoxType.Items.RemoveAt(i);
        }

        private void listBoxType_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxType.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    listBoxType.SelectedIndex = index;
                    this.deleteType.Show(this.listBoxType, e.Location);
                }
            }
        }

        private void deleteActor_MouseClick(object sender, MouseEventArgs e)
        {
            int i = listBoxActor.SelectedIndex;
            listBoxActor.Items.RemoveAt(i);
        }

        private void listBoxActor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxActor.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    listBoxActor.SelectedIndex = index;
                    this.deleteActor.Show(this.listBoxActor, e.Location);
                }
            }
        }

        private void MovieAdd_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i >= 1930; i--)
            {
                string year = string.Format("{0}", i);
                comboBox1.Items.Add(year);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            bool match = false;
            for (int i = DateTime.Now.Year; i >= 1930; i--)
            {
                if (comboBox1.Text.Equals(i.ToString()))
                    match = true;
            }
            if (match == false)
                comboBox1.Text = "2018";
        }
    }
}
