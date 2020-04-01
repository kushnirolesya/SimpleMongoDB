using Service;
using System.Windows;

namespace WpfSocialNetwork
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        UserService service;

        public Login()
        {
            InitializeComponent();
            service = new UserService();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (service.CheckPassword(Username.Text, Password.Password.ToString()))
            {

                service.NicknameWrite(Username.Text);
                General general = new General(Username.Text)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                general.Show();
                this.Close();
            }
            else
            {
                //message window = new message("Incorect password");
                //window.Show();
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Close();
            Registration registration = new Registration()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            registration.Show();
        }
    }
}
