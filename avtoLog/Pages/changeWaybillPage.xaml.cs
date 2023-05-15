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
    /// Логика взаимодействия для changeWaybillPage.xaml
    /// </summary>
    public partial class changeWaybillPage : Page
    {
        Waybillses _way;

        public changeWaybillPage(Waybillses way)
        {
            InitializeComponent();

            _way = way;

            DataContext = _way;

            cbOrg.ItemsSource = PageHelper.DbConnect.org.ToList();

            cbDis.ItemsSource = PageHelper.DbConnect.Personal.Where(x => x.isDis == true).ToList();

            cbDri.ItemsSource = PageHelper.DbConnect.Personal.Where(x => x.isDri == true).ToList();

            cbCus.ItemsSource = PageHelper.DbConnect.Personal.Where(x => x.isDis == false && x.isDri == false).ToList();

            cbTs.ItemsSource = PageHelper.DbConnect.Transport.ToList();

            cbMes.ItemsSource = PageHelper.DbConnect.MesTypes.ToList();

            cbTrans.ItemsSource = PageHelper.DbConnect.TransTypes.ToList();

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbRoute.Text != "" && dpEndDate.Text != "" && dpStartDate.Text != "" && cbCus.SelectedItem != null && cbDis.SelectedItem != null && cbDri.SelectedItem != null && cbMes.SelectedItem != null && cbOrg.SelectedItem != null && cbTrans.SelectedItem != null && cbTs.SelectedItem != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {

                    try { _way.startDate = Convert.ToDateTime(dpStartDate.Text); } catch { MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка!"); }

                    try { _way.endDate = Convert.ToDateTime(dpEndDate.Text); } catch { MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка!"); }

                    _way.mesTypeId = (cbMes.SelectedItem as MesTypes).id;

                    _way.transTypeId = (cbTrans.SelectedItem as TransTypes).id;

                    _way.idDis = (cbDis.SelectedItem as Personal).id;




                    _way.idCus = (cbCus.SelectedItem as Personal).id;

                    _way.transportId = (cbTs.SelectedItem as Transport).id;

                    _way.orgId = (cbOrg.SelectedItem as org).id;

                    _way.routee = tbRoute.Text;

                    _way.idDri = (cbDri.SelectedItem as Personal).id;

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new waybillList());
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
