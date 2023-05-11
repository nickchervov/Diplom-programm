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
    /// Логика взаимодействия для newDepPage.xaml
    /// </summary>
    public partial class newDepPage : Page
    {
        public newDepPage()
        {
            InitializeComponent();

            cbOrgId.ItemsSource = PageHelper.DbConnect.org.ToList();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Departments dep = new Departments();
          
            dep.name = tbName.Text;

            if (cbOrgId.SelectedItem == null)
            {
                MessageBox.Show("Тип автотранспорта не выбран");
                return;
            }
            else
            {
                dep.orgId = (cbOrgId.SelectedItem as org).id;
            }
          
            if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
            {
                PageHelper.DbConnect.Departments.Add(dep);
                PageHelper.DbConnect.SaveChangesAsync();
                MessageBox.Show("Запись добавлена.", "ОК");
                PageHelper.MainFrame.Navigate(new depListPage());
            }
        }
    }
}
