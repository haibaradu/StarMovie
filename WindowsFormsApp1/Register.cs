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

using System.Text.RegularExpressions;

namespace MovieCommentSystem
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                string username = textBox1.Text;
                string password = textBox2.Text;
                string confirmPassword = textBox3.Text;
                string email = textBox4.Text;

                if (username == "" || password == "" || confirmPassword == "")
                    MessageBox.Show("Username and password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string connect = "Server=localhost;Database=testFinal;Uid=root;Pwd=";
                    MySqlConnection con = new MySqlConnection(connect);
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT userId FROM user WHERE userName='" + username + "';";

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    int n = da.Fill(ds, "register");
                    if (n != 0)
                    {
                        MessageBox.Show("Username exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        con.Close();
                    }
                    else
                    {
                        if (password.Length < 6)
                        {
                            MessageBox.Show("Password should have at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        else if (!textBox2.Text.Equals(textBox3.Text))
                        {
                            MessageBox.Show("Passwords different!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        else if (!r.IsMatch(email))
                        {
                            MessageBox.Show("Invalid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox4.Text = "";
                        }
                        else
                        {
                            string insertInfo = "INSERT INTO user VALUES(NULL,'" + username + "','" + password + "','" + email + "');";
                            MySqlCommand insert = con.CreateCommand();
                            insert.CommandText = insertInfo;
                            insert.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Register succeeded!", "Success", MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show("Please input something valid!");
            }
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {

        }
    }
}
