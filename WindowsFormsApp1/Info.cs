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
    public partial class Info : Form
    {
        public string myName;
        public string myInfo;
        public string myRate;
        public int rateTimes;
        public string myType;
        public string directorName;
        public string actorText;
        public int year;
        public string pictPath;
        public int myId;
        public int movieId;
        public string userName;
        MySqlConnection info_connect = new MySqlConnection("server=localhost;User Id=root;password=;Database=testfinal;");
        
        
        public Info(string name, string uName)
        {
            InitializeComponent();
            myName = name;
            userName = uName;
        }

        

        public void getInfo(string info) {
            myInfo = info;
        }

        public void getRate(string rate) {
            myRate = rate;
        }

        public void getDirectorName(string name)
        {
            directorName = name;
        }

        public void getText(string text)
        {
            actorText = text;
        }

        public void getYear(int yr)
        {
            year = yr;
        }

        public void getTimes(int times)
        {
            rateTimes = times;
        }

        public void getType(string type) {
            myType = type;
        }

        public void getPictPath(string path)
        {
            pictPath = path;
        }

        public void getMovieId(int id)
        {
            movieId = id;
        }

        public void getConnection(MySqlConnection con)
        {
            info_connect = con;
        }

        public void getInfomation() {
            int lblWidth = this.nameLabel.Width;
            float size = this.nameLabel.Font.Size;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Text = myName;
            while (this.nameLabel.Width > lblWidth)
            {
                size -= 0.25F;
                this.nameLabel.Font = new Font(new FontFamily(this.nameLabel.Font.Name), size, this.nameLabel.Font.Style, GraphicsUnit.World);
            }
            this.nameLabel.AutoSize = false;
            this.nameLabel.Width = lblWidth;

            this.nameLabel.Text = myName;
            this.sumLabel.Text = myInfo;
            this.rateLabel.Text = myRate;
            this.typeLabel.Text = myType;
            this.lblYear.Text = "Year: " + year.ToString();
            this.lblDirector.Text = "Director: " + directorName;
            this.lblActor.Text = "Actor: " + actorText;
            this.m_picture.ImageLocation = pictPath;
            this.lblTimes.Text = rateTimes.ToString();
            //myId = MovieInfo.userId;
        }

        //public delegate void myMethodDelegate();
        public void getMovieInfo()
        {
            info_connect.Open();
            string sql_1 = "select * from movie where movieTitle = '" + myName + "'";
            MySqlCommand myCmd = new MySqlCommand(sql_1, info_connect);
            MySqlDataReader reader;
            reader = myCmd.ExecuteReader();
            reader.Read();


            string sql_2 = "select typeName " +
                           "from movie m, type t, movie_has_type c " +
                           "where m.movieTitle='" + myName + "' and m.movieID=c.movieId and c.typeId=t.typeId";
            MySqlCommand myCmd2 = new MySqlCommand(sql_2, info_connect);



            this.getInfo(reader["movieSummary"].ToString());
            this.getRate(reader["movieRate"].ToString());
            this.getTimes(Convert.ToInt32(reader["ratedTimes"]));
            this.getYear(Convert.ToInt32(reader["movieYear"]));
            this.getPictPath(reader["picLocation"].ToString());

            int id = Convert.ToInt32(reader["movieID"]);
            this.getMovieId(id);
            reader.Close();

            reader = myCmd2.ExecuteReader();
            string type = "Type: ";
            int typeCount = 0;
            while (reader.Read())
            {
                typeCount++;
                type += reader["typeName"].ToString();
                if (typeCount <= 3)
                    type += " ";
                else
                {
                    type += "\n";
                    typeCount = 0;
                }
            }
            reader.Close();
            this.getType(type);

            string sql_3 = "select movieDirectorID from movie where movieID = " + id;
            reader = new MySqlCommand(sql_3, info_connect).ExecuteReader();
            reader.Read();
            int dId = Convert.ToInt32(reader["movieDirectorID"]);
            reader.Close();

            string sql_3_1 = "select directorName from director where directorId = " + dId;

            reader = new MySqlCommand(sql_3_1, info_connect).ExecuteReader();
            reader.Read();
            this.getDirectorName(reader["directorName"].ToString());
            reader.Close();

            string sql_4 = "select a.actorName, m.movieID from movie m join actor a join actor_has_movie h " +
                           "on m.movieID = h.movieId and a.actorId = h.actorId " +
                           "where m.movieID = " + id;
            reader = new MySqlCommand(sql_4, info_connect).ExecuteReader();
            string text = "";
            int actorCount = 0;
            while (reader.Read())
            {
                actorCount++;
                text += reader["actorName"].ToString();
                if (actorCount <= 3)
                    text += " ";
                else
                {
                    text += "\n";
                    actorCount = 0;
                }
            }
            this.getText(text);
            reader.Close();

            this.getInfomation();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            getMovieInfo();

            //原代码
            MySqlDataReader reader;
            string sql_getId = "select userId from user where userName = '" + userName + "'";
            reader = new MySqlCommand(sql_getId, info_connect).ExecuteReader();
            reader.Read();
            myId = Convert.ToInt32(reader["userId"]);
            reader.Close();
            string sql_isExit = "select count(*) as num from rate where userId = " + myId + " and movieId = " + movieId;
            MySqlCommand cmd = new MySqlCommand(sql_isExit, info_connect);
            
            reader = cmd.ExecuteReader();
            reader.Read();
            if (Convert.ToInt32(reader["num"]) == 0)
            {
                this.myComment.Hide();
                reader.Close();
            }
            else
            {
                reader.Close();
                this.beginRate.Hide();

                string sql_getRate = "select rate from rate where userId = " + myId + " and movieId = " + movieId;
                cmd = new MySqlCommand(sql_getRate, info_connect);
                reader = cmd.ExecuteReader();
                reader.Read();
                this.lbl_my_rate.Text = "My Rate: " + reader["rate"];
                reader.Close();
            }

            string sql_isFavorite = "select count(*) as bool from user_like_movie where userId = " + myId + " and movieId = " + movieId;
            reader = new MySqlCommand(sql_isFavorite, info_connect).ExecuteReader();
            reader.Read();
            if (Convert.ToInt32(reader["bool"]) == 0)
            {
                this.add_to_favo.Text = "Like";
            }
            else
            {
                this.add_to_favo.Text = "Unlike";
            }
            reader.Close();
        }

        private void beginRate_Click(object sender, EventArgs e)
        {
            writeComment com = new writeComment(this, this.userName);
            com.getAll(myId, movieId, info_connect, myName);
            com.Show();
        }

        private void add_to_favo_Click(object sender, EventArgs e)
        {
            if (this.add_to_favo.Text == "Like")
            {
                string sql_insert = "insert into user_like_movie values(" + myId + ", " + movieId + ")";
                new MySqlCommand(sql_insert, info_connect).ExecuteNonQuery();

                this.add_to_favo.Text = "Unlike";
                MessageBox.Show("Add Successfully!");
            }
            else if (this.add_to_favo.Text == "Unlike")
            {
                string sql_delete = "delete from user_like_movie where movieId = " + movieId;
                new MySqlCommand(sql_delete, info_connect).ExecuteNonQuery();

                this.add_to_favo.Text = "Like";
                MessageBox.Show("Delete Successfully!");
            }
        }
    }
}
