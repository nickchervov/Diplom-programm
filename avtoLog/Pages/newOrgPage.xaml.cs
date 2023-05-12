using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для newOrgPage.xaml
    /// </summary>
    public partial class newOrgPage : Page
    {
        public newOrgPage()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            org orgs = new org();

            if (tbName.Text != "" && tbCountry.Text != "" && tbPostCode.Text != "" && tbCity.Text != "" && tbStreet.Text != "")
            {
                orgs.name = tbName.Text;
                orgs.country = tbCountry.Text;
                orgs.postcode = tbPostCode.Text;
                orgs.city = tbCity.Text;
                orgs.street = tbStreet.Text;

                if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.org.Add(orgs);
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Запись добавлена.", "ОК");
                    PageHelper.MainFrame.Navigate(new orgListPage());
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
