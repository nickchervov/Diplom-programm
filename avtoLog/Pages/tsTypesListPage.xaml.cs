using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для tsTypesListPage.xaml
    /// </summary>
    public partial class tsTypesListPage : Page
    {
        DbSet<TsTypes> tsTypes;

        public tsTypesListPage()
        {
            InitializeComponent();

            connectingDb();
        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvTsTypes.ItemsSource = tsTypes.Where(x => x.name.Contains(searchBox.Text)).ToList();
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    var selected = lvTsTypes.SelectedItem as TsTypes;
        //    if (selected != null)
        //    {

        //        if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
        //        {
        //            PageHelper.DbConnect.TsTypes.Remove(selected);
        //            PageHelper.DbConnect.SaveChanges();

        //            connectingDb();
        //        }
        //        else return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Нет выбранной записи", "Внимание!");
        //    }
        //}

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvTsTypes.SelectedItem as TsTypes;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeTsTypesPage(selected));
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
            tsTypes = PageHelper.DbConnect.TsTypes;

            lvTsTypes.ItemsSource = tsTypes.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

    }
}

