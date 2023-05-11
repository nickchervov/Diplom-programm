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
    /// Логика взаимодействия для changeDepPage.xaml
    /// </summary>
    public partial class changeDepPage : Page
    {
        Departments _dep;

        public changeDepPage(Departments dep)
        {
            InitializeComponent();

            _dep = dep;
            DataContext = _dep;

            cbOrgId.ItemsSource = PageHelper.DbConnect.org.ToList();

            if (_dep.orgId == 1)
            {
                cbOrgId.SelectedIndex = 0;
            }
            else if (_dep.orgId == 3)
            {
                cbOrgId.SelectedIndex = 1;
            }
            else
            {
                cbOrgId.SelectedIndex = 2;
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            _dep.orgId = (cbOrgId.SelectedItem as org).id;

            PageHelper.DbConnect.SaveChangesAsync();
            MessageBox.Show("Данные изменены.", "ОК");
            PageHelper.MainFrame.Navigate(new depListPage());
        }
    }
}
