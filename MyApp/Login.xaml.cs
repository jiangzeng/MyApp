using MyApp.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        UserService userService = new UserService();
        public Login()
        {
            this.InitializeComponent();
        }

        private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainPage.user = userService.Login(EmailTextBox.Text, PasswordTextBox.Password);
                Frame.Navigate(typeof(MainPage));
            } catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (PasswordTextBox.Password != "")
            {
                if(e.Key == Windows.System.VirtualKey.Enter)
                {
                    PassportSignInButton_Click(null,null);
                }
            }

        }

        private void RegisterButtonTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
