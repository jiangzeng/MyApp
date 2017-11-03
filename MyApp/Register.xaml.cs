using MyApp.DataModels;
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
    public sealed partial class Register : Page
    {
        UserService userService = new UserService();
        public Register()
        {
            this.InitializeComponent();
        }

        private void LoginButtonTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = userService.Register(EmailTextBox.Text, DisplayNameTextBox.Text, PasswordTextBox.Password);
                if (user != null)
                {
                    MainPage.user = user;
                    Frame.Navigate(typeof(MainPage));
                }
            } catch(Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
    }
}
