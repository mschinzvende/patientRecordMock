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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalRecords
{
    public partial class Patient_Record : Form
    {
        public Patient_Record()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a connection to the database
                SQLiteConnection connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;");

                // Open the connection
                connection.Open();

                // Create a command
                SQLiteCommand commandPatient = new SQLiteCommand("UPDATE Patients SET pemail=@pemail,pname=@pname,pgender=@pgender,pdob=@pdob,paddress=@paddress,pphone=@pphone, pnotes=@pnotes WHERE pid=@ppid", connection);

                // Set the parameters
                commandPatient.Parameters.AddWithValue("@pemail", textBox5.Text);
                commandPatient.Parameters.AddWithValue("@pname", textBox1.Text);
                commandPatient.Parameters.AddWithValue("@pgender", textBox4.Text);
                commandPatient.Parameters.AddWithValue("@pdob", textBox2.Text);
                commandPatient.Parameters.AddWithValue("@pphone", textBox3.Text);
                commandPatient.Parameters.AddWithValue("@paddress", textBox7.Text);
                commandPatient.Parameters.AddWithValue("@pnotes", textBox6.Text);
                commandPatient.Parameters.AddWithValue("@ppid", Main.id);


                // Execute the command
                commandPatient.ExecuteNonQuery();
                // Close the connection
                connection.Close();

                MessageBox.Show("Record update success", "edit success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void Patient_Record_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Main.name;
                textBox4.Text = Main.gender;
                textBox2.Text = Main.dob;
                textBox5.Text = Main.email;
                textBox3.Text = Main.phone;
                textBox6.Text = Main.notes;
                textBox7.Text = Main.address;


                Image image = Image.FromFile(Main.picture);
                pictureBox1.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
