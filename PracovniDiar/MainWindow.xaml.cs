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
            infoAboutUsers.Visibility = Visibility.Visible;
            nameOfWorker.Content = lblWorkers.SelectedItem.ToString();
        }
    }
}
