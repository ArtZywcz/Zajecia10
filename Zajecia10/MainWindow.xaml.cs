using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Zajecia10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            ListViewUsers.ItemsSource = users;

            //FileWatcher test = new FileWatcher();
            //test.Show();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            char ch = Convert.ToChar((counter % 26) + 65);
            Random rnd = new Random();

            if (users.Any())
            {
                counter = users.Max(x => x.id + 1);
                ch = Convert.ToChar((counter%26)+65);
            }

            users.Add(new User(counter, $"{ch}abacki", $"{rnd.Next(100000,999999)}", 0));
        }

        private void ButtonAddPoints_Click(object sender, RoutedEventArgs e)
        {
            
            if (users.Any())
            {

                User test = (User)ListViewUsers.SelectedItem;
                if (test != null)test.points += 100;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (users.Any())
            {
                User test = (User)ListViewUsers.SelectedItem;
                if (test != null) users.Remove(test);
            }
         }
    }
}
