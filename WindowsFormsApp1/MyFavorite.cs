using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MovieCommentSystem
{
    public partial class MyFavorite : Form
    {
        static string connection = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";

        static string picLoad;

        static ArrayList picBox = new ArrayList();
        static ArrayList nameList = new ArrayList();

        static int page = 1;
        static int max;
        static string username;

        public MyFavorite(string name)
        {
            username = name;
            InitializeComponent();
                   }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=testfinal;uid=root;pwd=");


            string searchStr = this.textBoxSearch.Text;
            string sql = "select m.movieTitle,m.picLocation from movie m ,user_like_movie ulm ,user u where m.movieId = ulm.movieId and ulm.userId=u.userId and u.userName='" + username + "'and m.movieTitle LIKE '%" + searchStr + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                //MySqlDataReader reader = cmd.ExecuteReader();
                picBox.Clear();
                nameList.Clear();
                while (reader.Read())
                {
                    picBox.Add(reader.GetString("picLocation"));
                    nameList.Add(reader.GetString("movieTitle"));
                    //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                }
                reader.Close();
                int i = 6 - picBox.Count % 6;
                if (i != 6)
                {
                    for (int m = 1; m <= i; m++)
                    {
                        picBox.Add("");
                        nameList.Add("");
                    }
                }
                max = picBox.Count / 6;
                if (picBox.Count == 0)
                {
                    for (i = 1; i <= 6; i++)
                    {
                        picBox.Add("");
                        nameList.Add("");
                    }

                }
                this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
                this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
                this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
                this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
                this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
                this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

                this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
                this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
                this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
                this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
                this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
                this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
                this.label2.Text = page + "/" + max;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void MyFavorite_Load(object sender, EventArgs e)
        {
           
            Refresh();
        }

        public new void Refresh()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;database=testfinal;uid=root;pwd=");
            try
            {

                picLoad = "select m.movieTitle,m.picLocation from movie m ,user_like_movie ulm ,user u where m.movieId = ulm.movieId and ulm.userId=u.userId and u.userName='" + username + "'";
                con.Open();
                Console.WriteLine("success");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            picBox.Clear();
            nameList.Clear();
            MySqlCommand command = new MySqlCommand(picLoad, con);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                picBox.Add(reader.GetString("picLocation"));
                nameList.Add(reader.GetString("movieTitle"));
                //Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
            }
            
            con.Close();
            int i = 6 - picBox.Count % 6;
            if (i != 6)
            {
                for (int m = 1; m <= i; m++)
                {
                    picBox.Add("");
                    nameList.Add("");
                }
            }
            max = picBox.Count / 6;
            if (max == 0)
            {
                for (i = 1; i <= 6; i++)
                {
                    picBox.Add("");
                    nameList.Add("");
                }
            }
                this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
                this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
                this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
                this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
                this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
                this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

                this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
                this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
                this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
                this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
                this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
                this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
                this.label2.Text = page + "/" + max;
        }
        

        private void buttonPre_Click(object sender, EventArgs e)
        {
            if (page <= 1)
                page = 1;
            else
                page--;
            this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
            this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
            this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
            this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
            this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
            this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

            this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
            this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
            this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
            this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
            this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
            this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
            this.label2.Text = page + "/" + max;
        }

        private void buttonTurnTo_Click(object sender, EventArgs e)
        {
            try
            {
                int page_restore = page;
                page = Convert.ToInt32(textBoxPage.Text);
                if (page <= max && max >= 1)
                {
                    this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
                    this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
                    this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
                    this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
                    this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
                    this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

                    this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
                    this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
                    this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
                    this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
                    this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
                    this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
                    this.label2.Text = page + "/" + max;
                }
                else
                {
                    page = page_restore;
                    MessageBox.Show("Please enter a proper number!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please enter proper number");

            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (page >= max)
                page = max;
            else
                page++;
            this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
            this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
            this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
            this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
            this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
            this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

            this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
            this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
            this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
            this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
            this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
            this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
            this.label2.Text = page + "/" + max;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void buttonUserCenter_Click(object sender, EventArgs e)
        {
            UserCenter userCenter = new UserCenter(username);
            this.Hide();
            userCenter.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel1.Text, username);
            info.ShowDialog();
            this.Refresh();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel2.Text, username);
            info.ShowDialog();
            this.Refresh();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel3.Text, username);
            info.ShowDialog();
            this.Refresh();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel4.Text, username);
            info.ShowDialog();
            this.Refresh();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel5.Text, username);
            info.ShowDialog();
            this.Refresh();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel6.Text, username);
            info.ShowDialog();
            this.Refresh();
        }
    }
}
