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

            contextMenuCollapsed();

            connectingDb();

            identityRole();

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

        //private void statusColor(TextBlock status)
        //{
        //    if (status.Text == "Занят")
        //    {
        //        status.Foreground = Brushes.Red;
        //    } else if (status.Text == "Свободен")
        //    {
        //        status.Foreground = Brushes.Green;
        //    } else
        //    {
        //        status.Foreground = Brushes.Yellow;
        //    }
        //}

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvCars.ItemsSource = cars.Where(x => x.Model.Contains(searchBox.Text) || x.Brand.Contains(searchBox.Text) || x.TransportStatus.StatusName.Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvCars.SelectedItem as Transport;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.Transport.Remove(selected);
                    PageHelper.DbConnect.SaveChanges();

                    cars = PageHelper.DbConnect.Transport;

                    lvCars.ItemsSource = cars.ToList();
                }
                else return;               
            }
            else
            {
                MessageBox.Show("Нет выбранной записи","Внимание!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите добавить запись?", "Внимание!", MessageBoxButton.YesNo))
            {
                PageHelper.MainFrame.Navigate(new addCarPage());
            }
            else return;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvCars.SelectedItem as Transport;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?","Внимание!",MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeCarPage(selected));
                } else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи","Внимание!");
            }
        }

        private void identityRole()
        {
            if (PageHelper.role == 1)
            {
                btnDelete.Visibility = Visibility.Visible;
                btnChange.Visibility = Visibility.Visible;
                btnAdd.Visibility = Visibility.Visible;
            }
            else
            {
                btnDelete.Visibility = Visibility.Hidden;
                btnChange.Visibility = Visibility.Hidden;
                btnAdd.Visibility = Visibility.Hidden;
            }
        }

        private void connectingDb()
        {
            cars = PageHelper.DbConnect.Transport;

            lvCars.ItemsSource = cars.ToList();
        }
    }
}
