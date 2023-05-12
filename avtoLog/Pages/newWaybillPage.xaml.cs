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
    /// Логика взаимодействия для newWaybillPage.xaml
    /// </summary>
    public partial class newWaybillPage : Page
    {
        public newWaybillPage()
        {
            InitializeComponent();

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
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Waybillses way = new Waybillses();

            if (tbNom.Text != "" && dpStartDate.Text != "" && dpEndDate.Text != "" && cbMes.SelectedItem != null && cbTrans.SelectedItem != null && cbDis.SelectedItem != null && cbCus.SelectedItem != null && cbTs.SelectedItem != null && cbOrg.SelectedItem != null && tbRoute.Text != "" && cbDri.SelectedItem != null)
            {
                try
                {
                    way.nom = Convert.ToInt32(tbNom.Text);
                }
                catch { MessageBox.Show("Поле номер листа должен состоять из цифр", "Ошибка"); }

                way.startDate = Convert.ToDateTime(dpStartDate.Text);

                way.endDate = Convert.ToDateTime(dpEndDate.Text);

                way.mesTypeId = (cbMes.SelectedItem as MesTypes).id;

                way.transTypeId = (cbTrans.SelectedItem as TransTypes).id;

                way.idDis = (cbDis.SelectedItem as Personal).id;

                way.idCus = (cbCus.SelectedItem as Personal).id;

                way.transportId = (cbTs.SelectedItem as Transport).id;

                way.orgId = (cbOrg.SelectedItem as org).id;

                way.routee = tbRoute.Text;

                way.idDri = (cbDri.SelectedItem as Personal).id;

                if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.DbConnect.Waybillses.Add(way);
                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Запись добавлена.", "ОК");
                    PageHelper.MainFrame.Navigate(new waybillList());
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
