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
            if (PageHelper.DbConnect.Auth.Where(x => x.login == tbLogin.Text && x.password == pbPassword.Password && x.Personal.isAdm == true).FirstOrDefault() != null)
            {
                PageHelper.role = 1; //администраторы

                PageHelper.MainFrame.Navigate(new mainMenu());
            }
            else if (PageHelper.DbConnect.Auth.Where(x => x.login == tbLogin.Text && x.password == pbPassword.Password && x.Personal.isDis == true).FirstOrDefault() != null)
            {
                PageHelper.role = 2; //диспетчеры

                PageHelper.MainFrame.Navigate(new mainMenu());
            }
            else if (PageHelper.DbConnect.Auth.Where(x => x.login == tbLogin.Text && x.password == pbPassword.Password && x.Personal.isDri == true).FirstOrDefault() != null)
            {
                PageHelper.role = 3; //водители

                PageHelper.MainFrame.Navigate(new mainMenu());
            }
            else if (PageHelper.DbConnect.Auth.Where(x => x.login == tbLogin.Text && x.password == pbPassword.Password && (x.Personal.position == "Инженер" || x.Personal.position == "Главный инженер")).FirstOrDefault() != null)
            {
                PageHelper.role = 4; //работники сервиса

                PageHelper.MainFrame.Navigate(new mainMenu());
            }
            else if (PageHelper.DbConnect.Auth.Where(x => x.login == tbLogin.Text && x.password == pbPassword.Password && x.Personal.isPer == true).FirstOrDefault() != null)
            {
                PageHelper.role = 5; //работники по персоналу

                PageHelper.MainFrame.Navigate(new mainMenu());
            }
            else
            {
                MessageBox.Show("Неправильный логин и пароль", "Ошибка!");
            }
        }
    }
}
