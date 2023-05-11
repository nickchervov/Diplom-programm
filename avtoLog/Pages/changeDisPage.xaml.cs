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
    /// Логика взаимодействия для changeDisPage.xaml
    /// </summary>
    public partial class changeDisPage : Page
    {
        Personal _dis;

        public changeDisPage(Personal dis)
        {
            InitializeComponent();

            _dis = dis;

            DataContext = _dis;

            if (_dis.pol == "М")
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
            if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
            {

                if (cbPol.SelectedIndex == 0)
                {
                    _dis.pol = "М";
                }
                else
                {
                    _dis.pol = "Ж";
                }

                PageHelper.DbConnect.SaveChangesAsync();
                MessageBox.Show("Данные изменены.", "ОК");
                PageHelper.MainFrame.Navigate(new disListPage());
            }
            else return;
        }
    }
}
