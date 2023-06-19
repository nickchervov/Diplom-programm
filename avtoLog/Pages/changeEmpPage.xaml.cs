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
    /// Логика взаимодействия для changeEmpPage.xaml
    /// </summary>
    public partial class changeEmpPage : Page
    {

        Personal _emp;

        public changeEmpPage(Personal emp)
        {
            InitializeComponent();

            _emp = emp;

            DataContext = _emp;

            cbDep.ItemsSource = PageHelper.DbConnect.Departments.ToList();

            cbDep.SelectedIndex = _emp.departmentId - 1;

            if (_emp.pol == "М")
            {
                cbPol.SelectedIndex = 0;
            }
            else
            {
                cbPol.SelectedIndex = 1;
            }

            if (_emp.isDri == true)
            {
                cbIsDri.SelectedIndex = 0;
            } else
            {
                cbIsDri.SelectedIndex = 1;
            }

            if (_emp.isDis == true)
            {
                cbIsDis.SelectedIndex = 0;
            }
            else
            {
                cbIsDis.SelectedIndex = 1;
            }

            if (_emp.isAdm == true)
            {
                cbIsAdm.SelectedIndex = 0;
            }
            else
            {
                cbIsAdm.SelectedIndex = 1;
            }

            if (_emp.isPer == true)
            {
                cbIsPer.SelectedIndex = 0;
            }
            else
            {
                cbIsPer.SelectedIndex = 1;
            }

            if (_emp.isSer == true)
            {
                cbIsSer.SelectedIndex = 0;
            }
            else
            {
                cbIsSer.SelectedIndex = 1;
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new empListPage());
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbAge.Text != "" && tbFIO.Text != "" && tbPosition.Text != "" && tbTabNom.Text != "" && cbDep.SelectedItem != null && cbIsAdm.SelectedItem != null && cbIsDis.SelectedItem != null && cbIsDri.SelectedItem != null && cbIsPer.SelectedItem != null && cbPol.SelectedItem != null && cbIsSer.SelectedItem != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание!", MessageBoxButton.YesNo))
                {
                    if (cbPol.SelectedIndex == 0)
                    {
                        _emp.pol = "М";
                    }
                    else
                    {
                        _emp.pol = "Ж";
                    }

                    if (cbIsDri.SelectedIndex == 0)
                    {
                        _emp.isDri = true;
                    }
                    else
                    {
                        _emp.isDri = false;
                    }

                    if (cbIsDis.SelectedIndex == 0)
                    {
                        _emp.isDis = true;
                    }
                    else
                    {
                        _emp.isDis = false;
                    }

                    if (cbIsAdm.SelectedIndex == 0)
                    {
                        _emp.isAdm = true;
                    }
                    else
                    {
                        _emp.isAdm = false;
                    }

                    if (cbIsPer.SelectedIndex == 0)
                    {
                        _emp.isPer = true;
                    }
                    else
                    {
                        _emp.isPer = false;
                    }

                    if (cbIsSer.SelectedIndex == 0)
                    {
                        _emp.isSer = true;
                    }
                    else
                    {
                        _emp.isSer = false;
                    }

                    try { _emp.tabNumber = Convert.ToInt32(tbTabNom.Text); } catch { MessageBox.Show("Табельный номер должен состоять из цифр!", "Предупреждение!"); return; }

                    _emp.departmentId = (cbDep.SelectedItem as Departments).id;

                    PageHelper.DbConnect.SaveChangesAsync();
                    MessageBox.Show("Данные изменены.", "ОК");
                    PageHelper.MainFrame.Navigate(new empListPage());
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
