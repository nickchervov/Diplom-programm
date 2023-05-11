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
    /// Логика взаимодействия для mainMenu.xaml
    /// </summary>
    public partial class mainMenu : Page
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void waybillListBtn_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new waybillList());
        }

        private void newWaybillBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new newWaybillPage());
            }
            else return;
        }

        private void transportListBtn_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new carListPage());
        }

        private void newTsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new addCarPage());
            }
            else return;
        }

        private void orgListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new orgListPage());
        }

        private void newOrgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new newOrgPage());
            }
            else return;
        }

        private void depListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new depListPage());
        }

        private void newDepBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new newDepPage());
            }
            else return;
        }

        private void empListBtn_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new empListPage());
        }

        private void newEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new newEmpPage());
            }
            else return;
        }

        private void driLicListBtn_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new driLicListPage());
        }

        private void newDriLicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new newDriLicPage());
            }
            else return;
        }

        private void driListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new driListPage());
        }
        

        private void disListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new disListPage());
        }


        private void tsTypesListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new tsTypesListPage());
        }

        private void mesTypesListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mesTypesListPage());
        }

        private void transTypesListBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new transTypesListPage());
        }
    }
}
