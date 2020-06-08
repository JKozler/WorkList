using System;
using System.Collections.Generic;
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
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO.Packaging;

namespace PracovniDiar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;DATABASE=users;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from infouser", connection);

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            connection.Close();

            data.DataContext = dt;

            if (File.Exists("Workers.txt"))
            {
                using (StreamReader sr = new StreamReader("workers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lblWorkers.Items.Add(line);
                    }
                }
            }
        }

        private void SelectedChangedLbl(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void removeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lblWorkers.SelectedItem != null)
            {
                nameOfWorker.Content = "";
                lblWorkers.Items.Remove(lblWorkers.SelectedItem);
            }
            else
                MessageBox.Show("Musíte někoho vybrat.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);

            infoAboutUsers.Visibility = Visibility.Hidden;
        }

        private void LblMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            infoAboutUsers.Visibility = Visibility.Visible;
            nameOfWorker.Content = lblWorkers.SelectedItem.ToString();
        }

        private void ChBox1(object sender, RoutedEventArgs e)
        {
            workNotDone.IsChecked = false;
        }

        private void ChBox2(object sender, RoutedEventArgs e)
        {
            workDone.IsChecked = false;
        }
    }
}
