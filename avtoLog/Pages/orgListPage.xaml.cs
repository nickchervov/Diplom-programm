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
    /// Логика взаимодействия для orgListPage.xaml
    /// </summary>
    public partial class orgListPage : Page
    {
        DbSet<org> orgs;

        public orgListPage()
        {
            InitializeComponent();

            connectingDb();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvOrgs.ItemsSource = orgs.Where(x => x.name.Contains(searchBox.Text) || x.city.Contains(searchBox.Text)).ToList();
        }

        private void connectingDb()
        {
            orgs = PageHelper.DbConnect.org;

            lvOrgs.ItemsSource = orgs.ToList();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvOrgs.SelectedItem as org;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeOrgPage(selected));
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
            var selected = lvOrgs.SelectedItem as org;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.org.Remove(selected);
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
    }
}
