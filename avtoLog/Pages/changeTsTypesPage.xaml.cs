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
    /// Логика взаимодействия для changeTsTypesPage.xaml
    /// </summary>
    public partial class changeTsTypesPage : Page
    {
        TsTypes _tsTypes;

        public changeTsTypesPage(TsTypes tsTypes)
        {
            InitializeComponent();

            _tsTypes = tsTypes;

            DataContext = _tsTypes;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.DbConnect.SaveChangesAsync();
            MessageBox.Show("Данные изменены.", "ОК");
            PageHelper.MainFrame.Navigate(new tsTypesListPage());
        }
    }
}
