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

        }

        private void newWaybillBtn_Click(object sender, RoutedEventArgs e)
        {

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

        }

        private void newOrgBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void depListBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newDepBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void empListBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newEmpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void driLicListBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newDriLicBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void driListBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newDriBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void disListBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newDisBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tsTypesListBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mesTypesListBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void transTypesListBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
