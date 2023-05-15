using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для changeCarPage.xaml
    /// </summary>
    public partial class changeCarPage : Page
    {
        Transport _avto;

        public changeCarPage(Transport avto)
        {
            InitializeComponent();

            _avto = avto;
            DataContext = _avto;

            cbTransportTypeId.ItemsSource = PageHelper.DbConnect.TsTypes.ToList();           

            if (_avto.tsTypeId == 1)
            {
                cbTransportTypeId.SelectedIndex = 0;
            }
            else if (_avto.tsTypeId == 2)
            {
                cbTransportTypeId.SelectedIndex = 1;
            }
            else if (_avto.tsTypeId == 3)
            {
                cbTransportTypeId.SelectedIndex = 2;
            }
            else
            {
                cbTransportTypeId.SelectedIndex = 3;
            }

            cbPhotoURL.ItemsSource = PageHelper.DbConnect.Photos.ToList();

            if (_avto.Photo == "/Images/camry.png")
            {
                cbPhotoURL.SelectedIndex = 0;
            }
            else if (_avto.Photo == "/Images/gaz.png")
            {
                cbPhotoURL.SelectedIndex = 1;
            }
            else if (_avto.Photo == "/Images/gaznext.png")
            {
                cbPhotoURL.SelectedIndex = 2;
            }
            else if (_avto.Photo == "/Images/kamaz.png")
            {
                cbPhotoURL.SelectedIndex = 3;
            } 
            else
            {
                cbPhotoURL.SelectedIndex = 4;
            }

            cbStatusId.ItemsSource = PageHelper.DbConnect.TsStatus.ToList();

            if (_avto.tsStatusId == 1)
            {
                cbStatusId.SelectedIndex = 0;
            } else if(_avto.tsStatusId == 2)
            {
                cbStatusId.SelectedIndex = 1;
            } else
            {
                cbStatusId.SelectedIndex = 2;
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbGovNumber.Text != "" && tbModel.Text != "" && cbTransportTypeId.SelectedItem != null && cbStatusId.SelectedItem != null && cbPhotoURL.SelectedItem != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {

                    _avto.tsTypeId = (cbTransportTypeId.SelectedItem as TsTypes).id;

                    _avto.tsStatusId = (cbStatusId.SelectedItem as TsStatus).id;

                    _avto.Photo = (cbPhotoURL.SelectedItem as Photos).URLPhoto;

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new carListPage());
                }
                else return;               
            } else
            {
                MessageBox.Show("Для изменения записи необходимо ввести все значения!","Предупреждение!");
            }          
        }
    }
}
