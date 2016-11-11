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
            foreach (var user in dbentities.Users) //fill list 'UserList' with user data from DB
            {
                userList.Add(user);
            }

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User userDetails = new User();
            string currentuser = tbxUser.Text.Trim();//removing spaces with trim  get user detials
            string curentpassword = tbxPassword.Password; //use password box //get password
            userDetails = mtdGetUserDetails(currentuser, curentpassword);//check if exist
            if(userDetails.AccessLeve>0)
            {
                lblError.Content = "OK";
            }
            else
            {
                lblError.Content="ented an invalid username or password";
            }
        }
        private User mtdGetUserDetails(string username, string password)
        {
            User UserDetails = new SQL_login.User();
            foreach (var user in userList)
            {
                if(username==user.UserID && password==user.Password)
                {
                    UserDetails = user;
                }
              
            }
            return UserDetails;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}
