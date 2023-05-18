using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalRecords
{
    public partial class Main : Form
    {


        public static string name { get; set; }
        public static string email { get; set; }
        public static string gender { get; set; }
        public static string dob { get; set; }
        public static string address { get; set; }
        public static string phone { get; set; }
        public static string picture { get; set; }
        public static string notes { get; set; }
        public static int id { get; set; }




        public Main()
        {
            InitializeComponent();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();



        }
        private void LoadData()
        {
            try

            
            {
                listBox1.Items.Clear();
                // Create a connection to the database
                SQLiteConnection connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;");

                // Open the connection
                connection.Open();
                
                // Create a command
                SQLiteCommand command = new SQLiteCommand("SELECT pid FROM Patients;", connection);

                // Execute the command.
                SQLiteDataReader reader = command.ExecuteReader();

                // Iterate through the results.
                while (reader.Read())
                {


                    listBox1.Items.Add(reader["pid"]);
                }
                // Close the connection
                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 4)
            {
                try
                {
                    bool isValidPatient = false;
                    // Create a connection to the database
                    SQLiteConnection connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;");

                    // Open the connection
                    connection.Open();

                    // Create a command
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM Patients WHERE pid ='" + int.Parse(textBox1.Text) + "';", connection);

                    // Execute the command.
                    SQLiteDataReader reader = command.ExecuteReader();

                    

                    // Iterate through the results.
                    if (reader.Read())
                    {
                        isValidPatient = true;
                        name = reader["pname"] as string;
                        email = reader["pemail"] as string;
                        gender = reader["pgender"] as string;
                        dob = reader["pdob"] as string;
                        address = reader["paddress"] as string;
                        phone = reader["pphone"] as string;
                        picture = reader["ppicture"] as string;
                        notes = reader["pnotes"] as string;
                        id = int.Parse(textBox1.Text);
                        

                    }
                    reader.DisposeAsync();
                    connection.Close();

                    if (isValidPatient == false)
                    {
                        
                        MessageBox.Show("Invalid Patient Fingerint. Please try again", "Invalid Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();

                    }

                    else
                    {
                        
                        textBox1.Clear();
                        groupBox1.Visible = false;
                        Patient_Record showRecord = new Patient_Record();
                        showRecord.ShowDialog();
                    }
                   
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            textBox1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadData();
        }
    }
}
