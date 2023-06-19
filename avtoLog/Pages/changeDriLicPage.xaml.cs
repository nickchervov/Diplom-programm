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
using AutoMapper;

namespace avtoLog.Pages
{
    /// <summary>
    /// Логика взаимодействия для changeDriLicPage.xaml
    /// </summary>
    public partial class changeDriLicPage : Page
    {
        DriverLicense _driLic;


        public changeDriLicPage(DriverLicense driLic)
        {
            InitializeComponent();

            _driLic = driLic;

            DataContext = _driLic;

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerNom.Text != "" && dpEndDate.Text != "" && dpRecDate.Text != "")
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    _driLic.receiptDate = Convert.ToDateTime(dpRecDate.Text);

                    if (Convert.ToDateTime(dpEndDate.Text) < Convert.ToDateTime(dpRecDate.Text))
                    {
                        MessageBox.Show("Дата окончания не может быть раньше даты получения!", "Ошибка!");
                        return;
                    }
                    else
                    {
                        _driLic.endDate = Convert.ToDateTime(dpEndDate.Text);
                    }

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new driLicListPage());
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
