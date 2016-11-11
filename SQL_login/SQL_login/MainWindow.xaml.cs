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

namespace SQL_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User>();  //new list of users 
        myDatabaseEntities dbentities = new myDatabaseEntities();  //new instance of DB

        public MainWindow()
        {
            InitializeComponent();

        }
        private void mtdLoadUsers()  //preload user list on 'Window loaded' at runtime
        {
            userList.Clear();//clear list pre reload
            foreach (var user in dbentities.Users)
            {
                userList.Add(user);
            }

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
