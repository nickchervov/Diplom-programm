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
using System.Xml.Linq;

namespace avtoLog.Pages
{
    /// <summary>
    /// Логика взаимодействия для newLoginPage.xaml
    /// </summary>
    public partial class newLoginPage : Page
    {
        public newLoginPage()
        {
            InitializeComponent();

            var checkPersonInAuth = PageHelper.DbConnect.Auth.Select(c => c.personId).ToArray();

            cbEmp.ItemsSource = PageHelper.DbConnect.Personal.Where(x => !checkPersonInAuth.Contains(x.id)).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();

            if (cbEmp.SelectedItem != null && tbLogin.Text != "" && tbPassword.Text != "")
            {
                auth.personId = (cbEmp.SelectedItem as Personal).id;

                auth.login = tbLogin.Text;

                auth.password = tbPassword.Text;

                if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.Auth.Add(auth);
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Запись добавлена.", "ОК");
                    PageHelper.MainFrame.Navigate(new loginListPage());
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
