using MyApp.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static User user = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                Frame.Navigate(typeof(Login));
            }
            else
            {
                loginInfo.Content = user.Name;
                foreach (NavigationViewItemBase item in NavView.MenuItems)
                {
                    if (item is NavigationViewItem && item.Tag.ToString() == "home")
                    {
                        NavView.SelectedItem = item;
                        break;
                    }
                }
            }
        }


        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            /*
            if (args.IsSettingsInvoked)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                switch (args.InvokedItem)
                {
                    case "loginInfo":
                        ContentFrame.Navigate(typeof(Login));
                        break;

                    case "travels":
                        //ContentFrame.Navigate(typeof(AppsPage));
                        break;

                    case "plans":
                        //ContentFrame.Navigate(typeof(GamesPage));
                        break;

                    case "notifications":
                        //ContentFrame.Navigate(typeof(MusicPage));
                        break;
                }
            }
            */
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
            if (args.IsSettingsSelected)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {

                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "home":
                        ContentFrame.Navigate(typeof(Home));
                        break;

                    case "loginInfo":
                        //ContentFrame.Navigate(typeof(AppsPage));
                        break;

                    case "travels":
                        //ContentFrame.Navigate(typeof(AppsPage));
                        break;

                    case "plans":
                        //ContentFrame.Navigate(typeof(GamesPage));
                        break;

                    case "notifications":
                        //ContentFrame.Navigate(typeof(MusicPage));
                        break;
                }
            }
            
        }
    }
}
