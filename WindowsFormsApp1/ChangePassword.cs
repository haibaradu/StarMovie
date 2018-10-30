using MySql.Data.MySqlClient;
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
    public partial class ChangePassword : Form
    {

        static string connection = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
        static MySqlConnection con = new MySqlConnection(connection);
        static string username;


        public ChangePassword(string name)
        {
            username = name;
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }
        string passWord;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT userPassword FROM user WHERE userName='" + username + "';";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passWord = reader.GetString("userPassword");
                }

                if (textBoxPrePwd.Text == "")
                {
                    MessageBox.Show("Please enter your password!");
                }
                else if (textBoxPrePwd.Text == passWord)
                {
                    string prePwd = textBoxPrePwd.Text;
                    string newPwd = textBoxNewPwd.Text;
                    string confirmPwd = textBoxConfirm.Text;
                    if (prePwd == "" || newPwd == "" || confirmPwd == "")
                    {
                        MessageBox.Show("Invalid input!");
                    }
                    else
                    {
                        if (newPwd.Length < 6)
                        {
                            MessageBox.Show("Password should have at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxNewPwd.Text = "";
                            textBoxConfirm.Text = "";
                        }
                        else if (!newPwd.Equals(confirmPwd))
                        {
                            MessageBox.Show("Passwords different!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxNewPwd.Text = "";
                            textBoxConfirm.Text = "";
                        }
                        else
                        {
                            string updatePassword = "update user set userPassword = '" + newPwd + "' where userPassword = '" + prePwd + "'";
                            reader.Close();
                            MySqlCommand update = con.CreateCommand();
                            update.CommandText = updatePassword;
                            update.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Successfully change your password!", "Success", MessageBoxButtons.OK);
                            UserCenter userCenter = new UserCenter(username);
                            this.Hide();
                            userCenter.ShowDialog();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the right password!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Please input something valid!");
            }



            
        }

        private void textBoxPrePwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            con.Close();
            UserCenter user = new UserCenter(username);
            //UserCenter userCenter = new UserCenter(username);
            this.Hide();
            user.ShowDialog();
            this.Close();
        }
    }
}
