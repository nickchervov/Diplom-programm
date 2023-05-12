using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        DbSet<Transport> cars;

        public carListPage()
        {
            InitializeComponent();

            connectingDb();

        }


        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvCars.ItemsSource = cars.Where(x => x.tsModel.Contains(searchBox.Text) || x.TsStatus.statusName.Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvCars.SelectedItem as Transport;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    try
                    {
                        PageHelper.DbConnect.Transport.Remove(selected);
                        PageHelper.DbConnect.SaveChanges();
                    } 
                    catch
                    {
                        MessageBox.Show("Не получилось удалить запись! Имеется связанная запись", "Предупреждение!");
                    }

                    connectingDb();
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvCars.SelectedItem as Transport;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeCarPage(selected));
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        private void connectingDb()
        {
            cars = PageHelper.DbConnect.Transport;

            lvCars.ItemsSource = cars.ToList();
        }

        private void btnBackImg_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

    }
}
