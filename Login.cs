using System.Data.SqlClient;
using System.Data.SQLite;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace HospitalRecords
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!File.Exists("hospitaldb.sqlite"))
            {
                CreateDb();
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Get the username and password from the user
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Hash the password using SHA512
            SHA512Managed sha512 = new SHA512Managed();
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Check if the username and password match the stored values
            bool isAuthenticated = false;
            using (var connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;"))
            {
                connection.Open();

                // Create a command
                var cmd = new SQLiteCommand("SELECT * FROM Users WHERE username = @username AND password = @password", connection);

                // Set the parameters
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hash);

                // Execute the command
                var reader = cmd.ExecuteReader();

                // Check if the user was found
                if (reader.Read())
                {
                    isAuthenticated = true;
                }

                reader.DisposeAsync();
                connection.Close();
            }

            // Display a message to the user
            if (isAuthenticated)
            {
                textBox1.Clear();
                textBox2.Clear();

                Hide();
                Main mainForm = new Main();
                mainForm.ShowDialog();
                Show();



            }
            else
            {
                MessageBox.Show("Invalid Login please try again!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CreateDb()
        {
            // Create a connection to the database
            SQLiteConnection connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;");

            // Open the connection
            connection.Open();

            // Create a command
            SQLiteCommand command = new SQLiteCommand("CREATE TABLE Users (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, password TEXT);", connection);

            // Execute the command
            command.ExecuteNonQuery();

            // Create a command
            SQLiteCommand commandUsers = new SQLiteCommand("INSERT INTO Users (username, password) VALUES (@stock_user, @stock_pass);", connection);

            // Set the parameters
            commandUsers.Parameters.AddWithValue("@stock_user", "admin");

            byte[] stock_pass = encryptPass("admin");
            commandUsers.Parameters.AddWithValue("@stock_pass", stock_pass);


            // Execute the command
            commandUsers.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }

        private byte[] encryptPass(string password)
        {
            // Create a new instance of the SHA512Managed class
            SHA512Managed sha512 = new SHA512Managed();

            // Encrypt the data
            byte[] encryptedPassword = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));

            return encryptedPassword;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Main mainForm = new Main();
            mainForm.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invalid Login please try again!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}