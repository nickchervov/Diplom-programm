using avtoLog.Helpers;
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

namespace avtoLog.Pages
{
    /// <summary>
    /// Логика взаимодействия для carListPage.xaml
    /// </summary>
    public partial class carListPage : Page
    {
        public carListPage()
        {
            InitializeComponent();

            contextMenuCollapsed();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (contextMenu.Visibility == Visibility.Collapsed)
            {
                contextMenu.Visibility = Visibility.Visible;
            } else
            {
                contextMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new logInPage());
        }


        private void contextMenuCollapsed()
        {
            contextMenu.Visibility = Visibility.Collapsed;
        }
    }
}
