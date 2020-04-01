using Service;
using System.Windows;

namespace WpfSocialNetwork
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        UserService service;
        public Registration()
        {
            InitializeComponent();
            service = new UserService();
        }


        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "")
            {
                if (service.CheckIndentityOfNickname(Username.Text))
                {
                    if (Password.Password.ToString() == ConfirmPassword.Password.ToString() && Password.Password.ToString() != "")
                    {
                        try
                        {
                            service.InsertUser(Username.Text, Email.Text, Password.Password.ToString());
                            service.NicknameWrite(Username.Text);
                            Close();
                            General general = new General(Username.Text)
                            {
                                WindowStartupLocation = WindowStartupLocation.CenterScreen
                            };
                            general.Show();
                        }
                        catch
                        {
                            //message message = new message("error");
                            //message.Show();
                        }
                    }
                    else
                    {
                        //message message = new message("passwords don't match ");
                        //message.Show();
                    }
                }
                else
                {
                    //message message = new message("nick is already used");
                    //message.Show();
                }

            }
            else
            {
                //message message = new message("fill all fields");
                //message.Show();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
