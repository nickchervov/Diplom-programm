using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для transTypesListPage.xaml
    /// </summary>
    public partial class transTypesListPage : Page
    {
        DbSet<TransTypes> transTypes;

        public transTypesListPage()
        {
            InitializeComponent();

            connectingDb();
        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvTransTypes.ItemsSource = transTypes.Where(x => x.name.Contains(searchBox.Text)).ToList();
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    var selected = lvTransTypes.SelectedItem as TransTypes;
        //    if (selected != null)
        //    {

        //        if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
        //        {
        //            PageHelper.DbConnect.TransTypes.Remove(selected);
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
            var selected = lvTransTypes.SelectedItem as TransTypes;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeTransPage(selected));
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
            transTypes = PageHelper.DbConnect.TransTypes;

            lvTransTypes.ItemsSource = transTypes.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }
    }
}
