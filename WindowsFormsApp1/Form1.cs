using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace MovieCommentSystem
{
    public partial class Form1 : Form
    {

        static string connection = "Server=localhost;Database=testfinal;Uid=root;Pwd=;";
        static MySqlConnection con = new MySqlConnection(connection);

        static string picLoad = "select movietitle,picLocation from movie";
        static ArrayList picBox = new ArrayList();
        static ArrayList nameList = new ArrayList();

        static int page = 1;
        static int max;
        public string username;

        //string outputInfo;

        public Form1(string name)
        {
            username = name;
            InitializeComponent();
            timer1.Start();
            
        }

        
        




        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            UserCenter user = new UserCenter(username);
            //UserCenter userCenter = new UserCenter(username);
            this.Hide();
            user.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(orderComboBox.SelectedItem.ToString());
            string orderSelected = orderComboBox.SelectedItem.ToString();
            string order;
            if(orderSelected=="Top Rated")
            {
                order = "movieRate";
            }else if(orderSelected=="Hottest")
            {
                order = "ratedtimes";
            }
            else
            {
                order = "movieYear";
            }
            //string searchStr = this.searchingText.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;database=testfinal;uid=root;pwd=");

            //string sql = "select movieTitle,picLocation from movie where movieTitle LIKE '%" + searchStr + "%'"+"order by "+order +" desc";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);


            //try
            //{
            //    conn.Open();
            //    MySqlDataReader reader = cmd.ExecuteReader();
            //    //MySqlDataReader reader = cmd.ExecuteReader();
            //    picBox.Clear();
            //    nameList.Clear();
            //    while (reader.Read())
            //    {
            //        try
            //        {
            //            try
            //            {
            //                picBox.Add(reader.GetString("picLocation"));
            //                nameList.Add(reader.GetString("movieTitle"));
            //                //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
            //            }
            //            catch
            //            {
            //                continue;
            //            }
            //        }
            //        catch { continue; }

            //    }
            //    int i = 6 - picBox.Count % 6;
            //    if (i != 6)
            //    {
            //        for (int m = 1; m <= i; m++)
            //        {
            //            picBox.Add("");
            //            nameList.Add("");
            //        }
            //    }
            //    max = picBox.Count / 6;
            //    if (picBox.Count == 0)
            //    {
            //        for(i = 1; i <= 6; i++)
            //        {
            //            picBox.Add("");
            //            nameList.Add("");
            //        }

            //    }
            //    this.pictureBox1.ImageLocation = picBox[(page - 1) * 6] as String;
            //    this.pictureBox2.ImageLocation = picBox[(page - 1) * 6 + 1] as String;
            //    this.pictureBox3.ImageLocation = picBox[(page - 1) * 6 + 2] as String;
            //    this.pictureBox4.ImageLocation = picBox[(page - 1) * 6 + 3] as String;
            //    this.pictureBox5.ImageLocation = picBox[(page - 1) * 6 + 4] as String;
            //    this.pictureBox6.ImageLocation = picBox[(page - 1) * 6 + 5] as String;

            //    this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
            //    this.linkLabel2.Text = nameList[(page - 1) * 6 + 1] as String;
            //    this.linkLabel3.Text = nameList[(page - 1) * 6 + 2] as String;
            //    this.linkLabel4.Text = nameList[(page - 1) * 6 + 3] as String;
            //    this.linkLabel5.Text = nameList[(page - 1) * 6 + 4] as String;
            //    this.linkLabel6.Text = nameList[(page - 1) * 6 + 5] as String;
            //    this.label2.Text = page + "/" + max;
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
            if (searchTypeSelected == "Title" || searchTypeSelected == "movieTitle")
            {
                searchTypeSelected = "movieTitle";
                string searchStr = this.searchingText.Text;
                string sql = "select movieTitle,picLocation from movie where " + searchTypeSelected + " LIKE '%" + searchStr + "%'" + "order by " + order + " desc"; ;
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch
                        {
                            continue;
                        }


                    }
                    
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
                    page = 1;
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
            else if (searchTypeSelected == "Type" || searchTypeSelected == "typeName")
            {
                searchTypeSelected = "typeName";
                string searchStr = this.searchingText.Text;
                string sql = "select m.movieTitle,m.picLocation from movie m,type t,movie_has_type mt where t.typeId=mt.typeId and m.movieId=mt.movieId and t." + searchTypeSelected + " LIKE '%" + searchStr + "%'" + "order by " + order + " desc"; ;
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString(("movieTitle")));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch { continue; }
                    }
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
                    page = 1;
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
            else if (searchTypeSelected == "Actor" || searchTypeSelected == "actorName")
            {
                searchTypeSelected = "actorName";
                string searchStr = this.searchingText.Text;
                string sql = "select m.movieTitle,m.picLocation from movie m,actor a,actor_has_movie am where a.actorId=am.actorId and m.movieId=am.movieId and a." + searchTypeSelected + " LIKE '%" + searchStr + "%'" + "order by " + order + " desc"; ;
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch { continue; }
                    }
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
                    page = 1;
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
            else if (searchTypeSelected == "Director" || searchTypeSelected == "directorName")
            {
                searchTypeSelected = "directorName";
                string searchStr = this.searchingText.Text;
                string sql = "select movieTitle,picLocation from movie m,director d  where m.movieDirectorId=d.directorId and d." + searchTypeSelected + " LIKE '%" + searchStr + "%'" + "order by " + order + " desc"; ;
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch
                        {
                            continue;
                        }
                    }
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
                    page = 1;
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderComboBox.SelectedIndex = 0;
            SearchTypeBox.SelectedIndex = 0;
            picBox.Clear();
            nameList.Clear();
            try
        {
            con.Open();
            Console.WriteLine("success");
        }
        catch (MySqlException ex)
        {
                MessageBox.Show("asdasd");
            Console.WriteLine(ex.Message);
        }
        MySqlCommand command = new MySqlCommand(picLoad, con);
        MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
        {
                try
                {
                    try
                    {
                        picBox.Add(reader.GetString("picLocation"));
                        nameList.Add(reader.GetString("movieTitle"));
                        //Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式

                    }
                    catch
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                    }

            int i = 6-picBox.Count % 6;
            if (i != 6)
            {
                for (int m=1; m <= i;m++)
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
            page = 1;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel1.Text,username);
            info.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel3.Text, username);
            info.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel5.Text, username);
            info.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (page <= 1)
                page = 1;
            else
                page--;
            this.pictureBox1.ImageLocation = picBox[(page-1)*6] as String;
            this.pictureBox2.ImageLocation = picBox[(page - 1) * 6+1] as String;
            this.pictureBox3.ImageLocation = picBox[(page - 1) * 6+2] as String;
            this.pictureBox4.ImageLocation = picBox[(page - 1) * 6+3] as String;
            this.pictureBox5.ImageLocation = picBox[(page - 1) * 6+4] as String;
            this.pictureBox6.ImageLocation = picBox[(page - 1) * 6+5] as String;

            this.linkLabel1.Text = nameList[(page - 1) * 6] as String;
            this.linkLabel2.Text = nameList[(page - 1) * 6+1] as String;
            this.linkLabel3.Text = nameList[(page - 1) * 6+2] as String;
            this.linkLabel4.Text = nameList[(page - 1) * 6+3] as String;
            this.linkLabel5.Text = nameList[(page - 1) * 6+4] as String;
            this.linkLabel6.Text = nameList[(page - 1) * 6+5] as String;
            this.label2.Text = page + "/" + max;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int page_restore = page;
                page = Convert.ToInt32(textBox2.Text);
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

        private void button5_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=testfinal;uid=root;pwd=");

            if (searchTypeSelected == "Title"||searchTypeSelected=="movieTitle")
            {
                searchTypeSelected = "movieTitle";
                string searchStr = this.searchingText.Text;
                string sql = "select movieTitle,picLocation from movie where " + searchTypeSelected + " LIKE '%" + searchStr + "%'";
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch
                        {
                            continue;
                        }


                    }
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
                    page = 1;
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
                    MessageBox.Show("Please input something valid!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (searchTypeSelected == "Type"||searchTypeSelected=="typeName")
            {
                searchTypeSelected = "typeName";
                string searchStr = this.searchingText.Text;
                string sql = "select m.movieTitle,m.picLocation from movie m,type t,movie_has_type mt where t.typeId=mt.typeId and m.movieId=mt.movieId and t." + searchTypeSelected + " LIKE '%" + searchStr + "%'";
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString(("movieTitle")));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch { continue; }
                    }
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
                    page = 1;
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
                    MessageBox.Show("Please input something valid!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (searchTypeSelected == "Actor"||searchTypeSelected=="actorName")
            {
                searchTypeSelected = "actorName";
                string searchStr = this.searchingText.Text;
                string sql = "select m.movieTitle,m.picLocation from movie m,actor a,actor_has_movie am where a.actorId=am.actorId and m.movieId=am.movieId and a." + searchTypeSelected + " LIKE '%" + searchStr + "%'";
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch { continue; }
                    }
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
                    page = 1;
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
                catch (Exception ex)
                {
                    MessageBox.Show("Please input something valid!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (searchTypeSelected == "Director"||searchTypeSelected== "directorName")
            {
                searchTypeSelected = "directorName";
                string searchStr = this.searchingText.Text;
                string sql = "select movieTitle,picLocation from movie m,director d  where m.movieDirectorId=d.directorId and d." + searchTypeSelected + " LIKE '%" + searchStr + "%'";
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
                        try
                        {
                            picBox.Add(reader.GetString("picLocation"));
                            nameList.Add(reader.GetString("movieTitle"));
                            //textBox2.AppendText(reader.GetInt32("userId") + " " + reader.GetString("userName") + "  ");
                        }
                        catch
                        {
                            continue;
                        }
                    }
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
                    page = 1;
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
                    MessageBox.Show("Please input something valid!");
                }
                finally
                {
                    conn.Close();
                }
            }
            

        }
        public static string type;
        public static string searchTypeSelected;
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            searchTypeSelected = SearchTypeBox.SelectedItem.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1201;
            int i = DateTime.Now.Second;
            switch (i % 3)
            {
                case 0:
                    pictureBoxTop.Image = System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\002.jpg");
                    pictureBox7.Image= System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\003.jpg");
                    break;
                case 1:
                    pictureBoxTop.Image = System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\005.jpg");
                    pictureBox7.Image= System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\004.jpg");
                    break;
                case 2:
                    pictureBoxTop.Image = System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\006.jpg");
                    pictureBox7.Image = System.Drawing.Image.FromFile(@"F:\Projects\C#\WindowsFormsApp1\WindowsFormsApp1\Resources\007.jpg");
                    break;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel2.Text, username);
            info.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel4.Text, username);
            info.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Info info = new Info(linkLabel6.Text, username);
            info.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("E:\\searchReport.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Movies with " + SearchTypeBox.Text + " containing '" + searchingText.Text + "' searched by " + username + "\n\n"));
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            for (int i = 0; i < nameList.Count; i++)
            {
                string movieTitle = nameList[i].ToString();
                cmd.CommandText = "SELECT movieId,movieTitle,movieYear,movieRate,ratedTimes,movieSummary FROM movie WHERE movieTitle='" + movieTitle + "';";
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    doc.Add(new Paragraph("movieId: " + Convert.ToString(r["movieId"])));
                    doc.Add(new Paragraph("movieTitle: " + Convert.ToString(r["movieTitle"])));
                    doc.Add(new Paragraph("movieYear: " + Convert.ToString(r["movieYear"])));
                    doc.Add(new Paragraph("movieRate: " + Convert.ToString(r["movieRate"])));
                    doc.Add(new Paragraph("ratedTimes: " + Convert.ToString(r["ratedTimes"])));
                    doc.Add(new Paragraph("movieSummary: " + Convert.ToString(r["movieSummary"] + "\n" + "\n")));
                }
                r.Close();
            }
            con.Close();
            doc.Close();
            Process.Start("E:\\searchReport.pdf");
        }
    }
}
