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
    /// Логика взаимодействия для driListPage.xaml
    /// </summary>
    public partial class driListPage : Page
    {
        DbSet<Personal> dri;

        DbSet<Auth> auth;

        public driListPage()
        {
            InitializeComponent();

            connectingDb();

        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvDri.ItemsSource = dri.Where(x => x.FIO.Contains(searchBox.Text) || x.tabNumber.ToString().Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvDri.SelectedItem as Personal;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    auth = PageHelper.DbConnect.Auth;

                    PageHelper.DbConnect.Auth.Remove(auth.Where(x => x.personId == selected.id).FirstOrDefault());
                    PageHelper.DbConnect.Personal.Remove(selected);
                    PageHelper.DbConnect.SaveChanges();

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
            var selected = lvDri.SelectedItem as Personal;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeDriPage(selected));
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
            dri = PageHelper.DbConnect.Personal;

            lvDri.ItemsSource = dri.Where(x => x.isDri == true).ToList();

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
