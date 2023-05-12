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
    /// Логика взаимодействия для tsPhotoListPage.xaml
    /// </summary>
    public partial class tsPhotoListPage : Page
    {
        DbSet<Photos> photos;

        DbSet<Transport> ts;

        public tsPhotoListPage()
        {
            InitializeComponent();

            connectingDb();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvPhoto.ItemsSource = photos.Where(x => x.codeName.Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvPhoto.SelectedItem as Photos;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {

                    try {
                        PageHelper.DbConnect.Photos.Remove(selected);
                        PageHelper.DbConnect.SaveChanges();
                    } 
                    catch
                    {
                        MessageBox.Show("Не получилось удалить запись! Имеется связанная запись","Предупреждение!");
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

        private void connectingDb()
        {
            photos = PageHelper.DbConnect.Photos;

            lvPhoto.ItemsSource = photos.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

    }
}
