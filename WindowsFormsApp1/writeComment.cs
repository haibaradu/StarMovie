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

namespace MovieCommentSystem
{
    public partial class writeComment : Form
    {
        public writeComment(Info info, string name)
        {
            InitializeComponent();
            userName = name;
            for_close = info;
        }

        public int myId, movieId;
        public MySqlConnection connect;
        public string m_name;
        public string userName;
        public Info for_close;
        public int rate = 0;
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                rate = 1;
            if (radioButton2.Checked)
                rate = 2;
            if (radioButton3.Checked)
                rate = 3;
            if (radioButton4.Checked)
                rate = 4;
            if (radioButton5.Checked)
                rate = 5;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (rate == 0)
            {
                MessageBox.Show("Please complete your comment and rate.");
                
            }
            else
            {
                string sql_update_rate = "insert into rate values (" + rate + "," + myId + "," + movieId + ")";
                string sql_update_movie1 = "update movie set ratedTimes = ratedTimes + 1 where movieID = " + movieId;

                string sql_select = "select ratedTimes, movieRate from movie where movieID = " + movieId;
                MySqlDataReader select = new MySqlCommand(sql_select, connect).ExecuteReader();
                select.Read();
                float movieRate = float.Parse(select["movieRate"].ToString());
                int ratedTimes = Convert.ToInt32(select["ratedTimes"]);
                float newRate = (movieRate * ratedTimes + rate) / (ratedTimes + 1);
                select.Close();

                string sql_update_movie3 = "update movie set movieRate = " + newRate + " where movieID = " + movieId;

                new MySqlCommand(sql_update_rate, connect).ExecuteNonQuery();
                new MySqlCommand(sql_update_movie1, connect).ExecuteNonQuery();
                new MySqlCommand(sql_update_movie3, connect).ExecuteNonQuery();

                this.Close();
                for_close.Close();

                Info newInfo = new Info(m_name, userName);
                newInfo.Show();
            }
        }

        public void getAll(int u_id, int m_id ,MySqlConnection con, string name)
        {
            myId = u_id;
            movieId = m_id;
            connect = con;
            m_name = name;
        }
    }
}
