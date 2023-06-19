using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        DbSet<DriverLicense> driLic;

        public driLicListPage()
        {
            InitializeComponent();

            connectingDb();

            
        }

        private void searchBox_TextChanged(object sender, RoutedEventArgs e)
        {
            lvDriLic.ItemsSource = driLic.Where(x => x.seriesNumber.Contains(searchBox.Text)).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvDriLic.SelectedItem as DriverLicense;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeDriLicPage(selected));
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvDriLic.SelectedItem as DriverLicense;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {

                    var driLicInPersonal = PageHelper.DbConnect.Personal.Select(c => c.idVU).ToArray();

                    if (driLicInPersonal.Contains(selected.id))
                    {
                        MessageBox.Show("Не получилось удалить запись!\nДля начала необходимо удалить запись владельца данного В/У!", "Предупреждение!");
                        return;
                    } else
                    {
                        PageHelper.DbConnect.DriverLicense.Remove(selected);
                        PageHelper.DbConnect.SaveChanges();
                        connectingDb();
                    }
                    
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        public void connectingDb()
        {
            driLic = PageHelper.DbConnect.DriverLicense;

            lvDriLic.ItemsSource = driLic.ToList();
        }
    }
}
