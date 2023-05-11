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

            if (tbGovNumber.Text.Length > 13)
            {
                MessageBox.Show("Необходимо ввести менее 14 символов государственного номера.", "Внимание!");
                return;
            }
            else
            {
                avto.GovNumber = tbGovNumber.Text;
            }

            avto.tsModel = tbModel.Text;

            if (cbTransportTypeId.SelectedItem == null)
            {
                MessageBox.Show("Тип автотранспорта не выбран");
                return;
            }
            else
            {
                avto.tsTypeId = (cbTransportTypeId.SelectedItem as TsTypes).id;
            }

            if (cbStatusId.SelectedItem == null)
            {
                MessageBox.Show("Статус автотранспорта не выбран");
                return;
            }
            else
            {
                avto.tsStatusId = (cbStatusId.SelectedItem as TsStatus).id;
            }

            if (cbPhotoURL.SelectedItem == null)
            {
                MessageBox.Show("Департамент не выбран");
                return;
            }
            else
            {
                avto.Photo = (cbPhotoURL.SelectedItem as Photos).URLPhoto;
            }

            if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
            {
                PageHelper.DbConnect.Transport.Add(avto);
                PageHelper.DbConnect.SaveChangesAsync();
                MessageBox.Show("Запись добавлена.", "ОК");
                PageHelper.MainFrame.Navigate(new carListPage());
            }           
        }
    }
}
