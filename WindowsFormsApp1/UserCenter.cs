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
    public partial class UserCenter : Form
    {
        static string connection = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
        static MySqlConnection conn = new MySqlConnection(connection);

        private string username;
        public UserCenter(string name)
        {
            username = name;
            InitializeComponent();
            string userSelect = "SELECT userEmail FROM user WHERE userName='" + username + "';";
            string userEmail;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(userSelect, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userEmail = reader.GetString("userEmail");
                lbEmail.Text = userEmail;
                lbName.Text = username;
                int random = new Random().Next(1, 6);
                userPortrait.ImageLocation = "F:\\Projects\\C#\\WindowsFormsApp1\\WindowsFormsApp1\\Resources\\random\\random" + random+".png";

            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            //textBoxEmail.Text = Form_Register.email;
        }

        private void btnNewPwd_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(username);
            this.Hide();
            conn.Close();
            changePassword.ShowDialog();
            this.Close();

        }

        private void btnMyLove_Click(object sender, EventArgs e)
        {
            MyFavorite myFavorite = new MyFavorite(username);
            this.Hide();
            conn.Close();
            myFavorite.ShowDialog();
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            conn.Close();
            Form1 form1 = new Form1(username);
            //UserCenter userCenter = new UserCenter(username);
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void UserCenter_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "PageColor1.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            Form_login login = new Form_login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
