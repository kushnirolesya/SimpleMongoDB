using Model;
using Service;
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
using System.Windows.Shapes;

namespace WpfSocialNetwork
{
    /// <summary>
    /// Interaction logic for SearchUser.xaml
    /// </summary>
    public partial class SearchUser : Window
    {
        UserService service;
        private string loginUsername;

        public SearchUser(string username)
        {
            loginUsername = username;
            InitializeComponent();
            service = new UserService();

        }

        private void Search(object sender, RoutedEventArgs e)
        {

            if (service.CheckIfUserIsInDatabase(searchUser.Text))
            {
                Profile profile = new Profile(loginUsername, searchUser.Text)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                profile.ShowDialog();
            }
            else
            {
                //message window = new message("there is not such user");
                //window.Show();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            General general = new General();
            general.Show();
            Close();
        }
    }
}
