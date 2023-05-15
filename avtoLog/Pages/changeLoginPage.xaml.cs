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
    /// Логика взаимодействия для changeLoginPage.xaml
    /// </summary>
    public partial class changeLoginPage : Page
    {
        Auth _auth;

        public changeLoginPage(Auth auth)
        {
            InitializeComponent();

            _auth = auth;

            DataContext = _auth;

            cbEmp.ItemsSource = PageHelper.DbConnect.Personal.ToList() ;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "" && cbEmp.SelectedItem != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    _auth.personId = (cbEmp.SelectedItem as Personal).id;

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new loginListPage());
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
