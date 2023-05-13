using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HospitalRecords
{
    public partial class AddPatient : Form
    {

        private string imageUrl = "No Image";
        public AddPatient()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase);

                if (!emailRegex.IsMatch(textBox3.Text))
                {
                    MessageBox.Show("Invalid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                // Create a connection to the database
                SQLiteConnection connection = new SQLiteConnection("Data Source=hospitaldb.sqlite;Version=3;");

                // Open the connection
                connection.Open();

                // Create a command
                SQLiteCommand commandPatient = new SQLiteCommand("INSERT INTO Patients (pemail,pname,pgender,pdob,paddress,pphone,ppicture) " +
                    "VALUES (@pemail,@pname,@pgender,@pdob,@paddress,@pphone,@ppicture);", connection);

                // Set the parameters
                commandPatient.Parameters.AddWithValue("@pemail", textBox3.Text);
                commandPatient.Parameters.AddWithValue("@pname", textBox1.Text);
                commandPatient.Parameters.AddWithValue("@pgender", comboBox1.Text);
                commandPatient.Parameters.AddWithValue("@pdob", dateTimePicker1.Text.ToString());
                commandPatient.Parameters.AddWithValue("@pphone", textBox4.Text.ToString());
                commandPatient.Parameters.AddWithValue("@paddress", textBox2.Text);
                commandPatient.Parameters.AddWithValue("@ppicture", imageUrl);

                // Execute the command
                commandPatient.ExecuteNonQuery();

                // Close the connection
                connection.Close();

                MessageBox.Show("Patient Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new OpenFileDialog control.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set the dialog's properties.
                openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                openFileDialog1.Title = "Open Image";


                // Show the dialog.
                DialogResult result = openFileDialog1.ShowDialog();

                // If the user clicked OK, get the path of the selected file.
                if (result == DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;
                    imageUrl = openFileDialog1.SafeFileName;
                    // Create a new Bitmap object from the image file.
                    Bitmap bitmap = new Bitmap(path);


                    // Save the image to a new file.
                    bitmap.Save(imageUrl, ImageFormat.Jpeg);

                    Image image = Image.FromFile(imageUrl);
                    pictureBox1.Image = image;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error Occured check your image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;


        }
    }
}
