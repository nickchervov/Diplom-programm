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
    /// Логика взаимодействия для logInPage.xaml
    /// </summary>
    public partial class logInPage : Page
    {
        public logInPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (PageHelper.DbConnect.Employees.Where(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password && x.PositionId == 1).FirstOrDefault() != null)
            {
                PageHelper.role = 1;

                PageHelper.MainFrame.Navigate(new carListPage());
            } else if (PageHelper.DbConnect.Employees.Where(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password && x.PositionId == 2).FirstOrDefault() != null)
            {
                PageHelper.role = 1;

                PageHelper.MainFrame.Navigate(new carListPage());
            } else if (PageHelper.DbConnect.Employees.Where(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password && x.PositionId == 3).FirstOrDefault() != null)
            {
                PageHelper.role = 1;

                PageHelper.MainFrame.Navigate(new carListPage());
            } else if (PageHelper.DbConnect.Employees.Where(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password && x.PositionId > 3).FirstOrDefault() != null)
            {
                PageHelper.role = 0;

                PageHelper.MainFrame.Navigate(new carListPage());
            }
            else
            {
                MessageBox.Show("Неправильный логин и пароль", "Ошибка!");
            }
        }
    }
}
