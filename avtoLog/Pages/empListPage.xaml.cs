using avtoLog.DbModel;
using avtoLog.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для empListPage.xaml
    /// </summary>
    public partial class empListPage : Page
    {
        DbSet<Personal> emp;

        DbSet<Auth> auth;
        public empListPage()
        {
            InitializeComponent();

            connectingDb();
        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvEmp.ItemsSource = emp.Where(x => x.FIO.Contains(searchBox.Text) || x.position.Contains(searchBox.Text) || x.tabNumber.ToString().Contains(searchBox.Text)).ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvEmp.SelectedItem as Personal;
            if (selected != null)
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    auth = PageHelper.DbConnect.Auth;

                    var disInWay = PageHelper.DbConnect.Waybillses.Select(c => c.idDis).ToArray();

                    var cusInWay = PageHelper.DbConnect.Waybillses.Select(c => c.idCus).ToArray();

                    var driInWay = PageHelper.DbConnect.Waybillses.Select(c => c.idDri).ToArray();

                    var perInLogins = PageHelper.DbConnect.Auth.Select(c => c.personId).ToArray();

                    if (disInWay.Contains(selected.id) || cusInWay.Contains(selected.id) || driInWay.Contains(selected.id))
                    {
                        MessageBox.Show("Не получилось удалить запись!\nДля начала необходимо удалить связанный путевой лист!", "Предупреждение!");
                        return;

                    } else
                    {
                        if (perInLogins.Contains(selected.id))
                        {
                            PageHelper.DbConnect.Auth.Remove(auth.Where(x => x.personId == selected.id).FirstOrDefault());
                            PageHelper.DbConnect.Personal.Remove(selected);
                            PageHelper.DbConnect.SaveChanges();
                            connectingDb();
                        } else
                        {
                            PageHelper.DbConnect.Personal.Remove(selected);
                            PageHelper.DbConnect.SaveChanges();
                            connectingDb();
                        }                      
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvEmp.SelectedItem as Personal;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeEmpPage(selected));
                }
                else return;
            }
            else
            {
                MessageBox.Show("Нет выбранной записи", "Внимание!");
            }
        }

        private void connectingDb()
        {
            emp = PageHelper.DbConnect.Personal;

            lvEmp.ItemsSource = emp.ToList();
        }

        private void btnBackImg_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }
    }
}
