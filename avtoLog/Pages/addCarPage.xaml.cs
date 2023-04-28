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

            cbTransportTypeId.ItemsSource = PageHelper.DbConnect.TransportTypes.ToList();

            cbDepartmentsId.ItemsSource = PageHelper.DbConnect.Departments.ToList();

            cbStatusId.ItemsSource = PageHelper.DbConnect.TransportStatus.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Transport avto = new Transport();

            avto.Brand = tbBrand.Text;
            avto.Model = tbModel.Text;

            if (cbTransportTypeId.SelectedItem == null)
            {
                MessageBox.Show("Тип автотранспорта не выбран");
                return;
            } else
            {
                avto.TransportTypeId = (cbTransportTypeId.SelectedItem as TransportTypes).Id;
            }

            if (cbDepartmentsId.SelectedItem == null)
            {
                MessageBox.Show("Департамент не выбран");
                return;
            } else
            {
                avto.DepartmentsId = (cbDepartmentsId.SelectedItem as Departments).Id;
            }

            if (cbStatusId.SelectedItem == null)
            {
                MessageBox.Show("Статус автотранспорта не выбран");
                return;
            }
            else
            {
                avto.StatusId = (cbStatusId.SelectedItem as TransportStatus).Id;
            }

            if(tbGovNumber.Text.Length > 7)
            {
                MessageBox.Show("Необходимо ввести менее 7 символов государственного номера.", "Внимание!");
                return;
            }
            else
            {
                avto.GovNumber = tbGovNumber.Text;
            }

            if (tbVinNumber.Text.Length > 17)
            {
                MessageBox.Show("Необходимо ввести менее 17 символов VIN-номера.","Внимание!");
                return;
            }
            else
            {
                avto.VinNumber = tbVinNumber.Text;
            }

            avto.Photo = tbPhoto.Text;

            PageHelper.DbConnect.Transport.Add(avto);
            PageHelper.DbConnect.SaveChangesAsync();
            MessageBox.Show("Запись добавлена.", "ОК");
            PageHelper.MainFrame.Navigate(new carListPage());
        }
    }
}
