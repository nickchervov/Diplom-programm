using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace avtoLog.Pages
{
    /// <summary>
    /// Логика взаимодействия для addCarPage.xaml
    /// </summary>
    public partial class addCarPage : Page
    {
        public addCarPage()
        {
            InitializeComponent();

            cbTransportTypeId.ItemsSource = PageHelper.DbConnect.TsTypes.ToList();

            cbPhotoURL.ItemsSource = PageHelper.DbConnect.Photos.ToList();

            cbStatusId.ItemsSource = PageHelper.DbConnect.TsStatus.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Transport avto = new Transport();

            if (tbGovNumber.Text != "" && tbModel.Text != "" && cbPhotoURL.SelectedItem != null && cbStatusId.SelectedItem != null && cbTransportTypeId.SelectedItem != null)
            {
                avto.GovNumber = tbGovNumber.Text;             
                avto.tsModel = tbModel.Text;
                avto.tsTypeId = (cbTransportTypeId.SelectedItem as TsTypes).id;
                avto.tsStatusId = (cbStatusId.SelectedItem as TsStatus).id;
                avto.Photo = (cbPhotoURL.SelectedItem as Photos).URLPhoto;

                if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.Transport.Add(avto);
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Запись добавлена.", "ОК");
                    PageHelper.MainFrame.Navigate(new carListPage());
                }
            } else
            {
                MessageBox.Show("Для добавления записи необходимо ввести все данные!", "Ошибка!");
                return;
            }
        }
    }
}
