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
    /// Логика взаимодействия для waybillList.xaml
    /// </summary>
    public partial class waybillList : Page
    {   
        DbSet<Waybillses> way;

        public waybillList()
        {
            InitializeComponent();

            connectingDb();

            

        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvWay.ItemsSource = way.Where(x => x.nom.ToString().Contains(searchBox.Text)  || x.Personal.FIO.Contains(searchBox.Text) || x.org.name.Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvWay.SelectedItem as Waybillses;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    
                    PageHelper.DbConnect.Waybillses.Remove(selected);
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
            var selected = lvWay.SelectedItem as Waybillses;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeWaybillPage(selected));
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
            way = PageHelper.DbConnect.Waybillses;
            

            lvWay.ItemsSource = way.ToList();
          
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

    }
}

