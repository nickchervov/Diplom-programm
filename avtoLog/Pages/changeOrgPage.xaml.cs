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
    /// Логика взаимодействия для changeOrgPage.xaml
    /// </summary>
    public partial class changeOrgPage : Page
    {
        org _org;

        public changeOrgPage(org orgs)
        {
            InitializeComponent();

            _org = orgs;
            DataContext = _org;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {   
          
            if (tbCity.Text != "" && tbCountry.Text != "" && tbName.Text != "" && tbPostCode.Text != "" && tbStreet.Text != "" )
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    if (tbPostCode.Text.Length != 6)
                    {
                        MessageBox.Show("Индекс должен состоять из 6 символов!", "Ошибка!"); return;
                    }
                    else if (checkPostcodeInNumber(tbPostCode.Text))
                    {
                        _org.postcode = tbPostCode.Text;
                    }
                    else
                    {
                        MessageBox.Show("Индекс должен состоять из цифр!", "Ошибка!"); return;
                    }

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new orgListPage());
                }
                else return;
            }
            else
            {
                MessageBox.Show("Для изменения записи необходимо ввести все значения!", "Предупреждение!");
            }
        }

        bool checkPostcodeInNumber(string postcode)
        {
            foreach (char c in postcode)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
