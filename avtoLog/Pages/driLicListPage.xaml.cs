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
    /// Логика взаимодействия для driLicListPage.xaml
    /// </summary>
    public partial class driLicListPage : Page
    {
        public driLicListPage()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvCars.SelectedItem /*as Transport*/;
            if (selected == null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeDriLicPage());
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }
    }
}
