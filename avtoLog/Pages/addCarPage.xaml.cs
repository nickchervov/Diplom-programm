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
            avto.TransportTypeId = Convert.ToInt32(tbTransportTypeId.Text);
            avto.DepartmentsId = Convert.ToInt32(tbDepartmentsId.Text);
            avto.StatusId = Convert.ToInt32(tbStatusId.Text);

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
