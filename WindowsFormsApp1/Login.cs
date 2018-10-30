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
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
            //this.SkinEngine = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = "PageColor2.ssk";
            //Sunisoft.IrisSkin.SkinEngine se = null;
            //se = new Sunisoft.IrisSkin.SkinEngine();
            //se.SkinAllForm = true;
            //se.Active = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("Sorry, username or password is empty.\nPlease enter agian!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string connect = "Server=localhost;Database=testfinal;Uid=root;Pwd=";
                    MySqlConnection con = new MySqlConnection(connect);
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();

                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    cmd.CommandText = "SELECT userName,userPassword FROM user WHERE userName='" + username + "';";

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    int n = da.Fill(ds, "login");
                    if (n == 0)
                    {
                        MessageBox.Show("Sorry, username doesn't exist.\nPlease enter agian!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        con.Close();
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0][1].ToString().Equals(password))
                        {
                            if (ds.Tables[0].Rows[0][0].ToString().Equals("root"))
                            {
                                con.Close();
                                Form root = new root();
                                this.Hide();
                                root.ShowDialog();

                            }
                            else
                            {
                                con.Close();
                                Form1 f = new Form1(username);
                                this.Hide();
                                f.ShowDialog();
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sorry, username or password incorrect.\nPlease enter agian!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            con.Close();
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }
        }
        

        private void label3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_Register f = new Form_Register();
            f.ShowDialog();
            this.Visible = true;
        }

        private void Form_login_Load(object sender, EventArgs e)
        {

        }

        
    }
}
