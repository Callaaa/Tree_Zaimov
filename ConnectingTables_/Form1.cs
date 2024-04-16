using MySql.Data.MySqlClient;

namespace ConnectingTables_
{
    public partial class Form1 : Form
    {
        string connstr = "server=10.6.0.127;" + "port=3306;"
           + "user=PC1;" + "password=1111;" + "database=trees_zaimov;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(connstr);
            if (connect.State == 0) connect.Open();
            MessageBox.Show("Connection is now opened");
            //4
            MySqlCommand query = new MySqlCommand("select * from class", connect);
            //5
            MySqlDataReader reader = query.ExecuteReader();
            //6
            while (reader.Read())
            {

                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
            reader.Close();       
            connect.Close();
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"109. Name {textBox1.Text}" +
                $"Name_bg {textBox2.Text}");

            string insertSQL = "INSERT INTO trees_zaimov.class" +
                "(`name`,`name_bg`)" +
                "VALUES (@name,@name_bg)";
           
            MySqlConnection connect = new MySqlConnection(connstr);
            if (connect.State == 0) connect.Open();
           

            MySqlCommand query = new MySqlCommand(insertSQL, connect);
            
            query.Parameters.AddWithValue("@name", textBox1.Text);
            query.Parameters.AddWithValue("@name_bg", textBox2.Text);
            
            query.ExecuteNonQuery();
            connect.Close();
        }
    }

}
