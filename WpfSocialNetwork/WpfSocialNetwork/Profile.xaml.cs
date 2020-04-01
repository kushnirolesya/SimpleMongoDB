using Model;
using Repository;
using Service;
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
using System.Windows.Shapes;

namespace WpfSocialNetwork
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        UserRepository userRepository;
        PostService postService;
        UserService userService;
        User user;
        List<Post> posts;

        Post currentPost;

        string personNickname;

        //public Profile(string username)
        //{
        //    InitializeComponent();
        //    personNickname = username;

        //    userRepository = new UserRepository();
        //    userService = new UserService();
        //    postService = new PostService();
        //    user = new User();

        //    user = userRepository.GetUser(personNickname);
        //    Email.Text = user.Email;
        //    Username.Text = user.Nickname;
            
        //    currentPost = new Post();
        //    posts = new List<Post>();
        //    posts = postService.GetPosts(personNickname);


        //}

        public Profile(string loginUsername, string visitUsername)
        {
            InitializeComponent();
            personNickname = visitUsername;

            if (loginUsername == visitUsername)
            {
                followButton.Visibility = Visibility.Hidden;
                unfollowButton.Visibility = Visibility.Hidden;
            }

            userRepository = new UserRepository();
            userService = new UserService();
            postService = new PostService();
            user = new User();

            user = userRepository.GetUser(visitUsername);
            Email.Text = user.Email;
            Username.Text = user.Nickname;

            Followers.Text = userService.GetFollowers(visitUsername).ToString();
            Following.Text = userService.GetFollowers(visitUsername).ToString();

            currentPost = new Post();
            posts = new List<Post>();
            posts = postService.GetPosts(visitUsername);
        }

        private void Follow(object sender, RoutedEventArgs e)
        {
            if (!userService.CheckAlreadyFollow(userService.NicknameRead(), personNickname))
            {
                userRepository.Following(userService.NicknameRead(), personNickname);
                userRepository.Follow(personNickname, userService.NicknameRead());
                followButton.Background = Brushes.Green;
            }
        }

        private void Unfollow(object sender, RoutedEventArgs e)
        {
            userRepository.Unfollow(userService.NicknameRead(), personNickname);
            Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
            SolidColorBrush brush = new SolidColorBrush(color);
            followButton.Background = brush;

        }
        
        private void Back(object sender, RoutedEventArgs e)
        {
            General general = new General(personNickname);
            general.Show();
            Close();
        }
    }
}
