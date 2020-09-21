using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List Loaded
        List<Person> loadedPeople = new List<Person>();
        int currentPerson = 0;

        /*Returns true if fields pass the validation constraints*/
        public bool validateForm()
        {
            var name = txtName.Text;
            var age = Convert.ToInt32(txtAge.Text);
            var address = txtAddress.Text;
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(address) && (age >= 0 && age <= 100))
            {
                return true;
            }
            return false;
        }

        /*Loads data from a .csv*/
        public List<Person> loadFromFile()
        {
            List<Person> data = new List<Person>();
            using (var reader = File.OpenText("myFile.csv"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    string[] lineValues = line.Split(',');
                    Person person = new Person(lineValues[0], lineValues[1], lineValues[2]);
                    data.Add(person);
                    line = reader.ReadLine();
                }
            }
            return data;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(validateForm())
            {
                var csv = new StringBuilder();
                string fileName = "myFile.csv";
                var newLine = string.Format("{0}, {1}, {2}", txtName.Text, txtAge.Text, txtAddress.Text);
                csv.AppendLine(newLine);
                try
                {
                    File.AppendAllText(fileName, csv.ToString()) ;
                    MessageBox.Show($"Data has been saved to {fileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to write to {fileName}");
                }
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            currentPerson = 0;
            loadedPeople = loadFromFile();
            MessageBox.Show("File Loaded.");
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if(currentPerson < loadedPeople.Count)
            {
                txtName.Text = loadedPeople[currentPerson].Name;
                txtAge.Text = loadedPeople[currentPerson].Age;
                txtAddress.Text = loadedPeople[currentPerson].Address;
                currentPerson++;
            } else
            {
                currentPerson = 0;
                MessageBox.Show("EOL");
            }
            
        }
    }
}
