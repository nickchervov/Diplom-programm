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
    /// Логика взаимодействия для changeMesPage.xaml
    /// </summary>
    public partial class changeMesPage : Page
    {
        MesTypes _mesTypes;

        public changeMesPage(MesTypes mesTypes)
        {
            InitializeComponent();

            _mesTypes = mesTypes;

            DataContext = _mesTypes;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "")
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new mesTypesListPage());
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
