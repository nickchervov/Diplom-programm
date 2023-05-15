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
    /// Логика взаимодействия для changeDriPage.xaml
    /// </summary>
    public partial class changeDriPage : Page
    {
        Personal _dri;

        public changeDriPage(Personal dri)
        {
            InitializeComponent();

            _dri = dri;

            DataContext = _dri;

            cbVU.ItemsSource = PageHelper.DbConnect.DriverLicense.ToList();

            cbVU.SelectedIndex = _dri.idVU - 1;

            if (_dri.pol == "М")
            {
                cbPol.SelectedIndex = 0;
            }
            else
            {
                cbPol.SelectedIndex = 1;
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbAge.Text != "" && tbFIO.Text != "" && tbPosition.Text != "" && tbTabNom.Text != "" && cbPol.SelectedItem != null && cbVU.SelectedItem != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {

                    if (cbPol.SelectedIndex == 0)
                    {
                        _dri.pol = "М";
                    }
                    else
                    {
                        _dri.pol = "Ж";
                    }

                    _dri.idVU = (cbVU.SelectedItem as DriverLicense).id;

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new driListPage());
                }
                else return;
            } 
            else
            {
                MessageBox.Show("Для изменения записи необходимо ввести все значения!", "Предупреждение!");
            }
        }
    }
}
