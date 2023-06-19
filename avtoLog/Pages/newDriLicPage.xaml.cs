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
    /// Логика взаимодействия для newDriLicPage.xaml
    /// </summary>
    public partial class newDriLicPage : Page
    {
        public newDriLicPage()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DriverLicense driLic = new DriverLicense();

            if (tbSerNom.Text != "" && dpRecDate.Text != "" && dpEndDate.Text != "")
            {
                driLic.seriesNumber = tbSerNom.Text;

                driLic.receiptDate = Convert.ToDateTime(dpRecDate.Text);

                if (Convert.ToDateTime(dpEndDate.Text) < Convert.ToDateTime(dpRecDate.Text))
                {
                    MessageBox.Show("Дата окончания не может быть раньше даты получения!","Ошибка!");
                    return;
                } 
                else
                {
                    driLic.endDate = Convert.ToDateTime(dpEndDate.Text);
                }


                if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.DriverLicense.Add(driLic);
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Запись добавлена.", "ОК");
                    PageHelper.MainFrame.Navigate(new driLicListPage());
                }
            } 
            else
            {
                MessageBox.Show("Для добавления записи необходимо ввести все данные!", "Ошибка!");
                return;
            }
        }
    }
}
