﻿using avtoLog.DbModel;
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
    /// Логика взаимодействия для newEmpPage.xaml
    /// </summary>
    public partial class newEmpPage : Page
    {
        public newEmpPage()
        {
            InitializeComponent();

            cbVU.ItemsSource = PageHelper.DbConnect.DriverLicense.ToList();

            cbDep.ItemsSource = PageHelper.DbConnect.Departments.ToList();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new mainMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Personal emp = new Personal();

            emp.tabNumber = Convert.ToInt32(tbTabNom.Text);
            emp.FIO = tbFIO.Text;
            emp.position = tbPosition.Text;
            emp.departmentId = (cbDep.SelectedItem as Departments).id;
            emp.age = Convert.ToInt32(tbAge.Text);

            if (cbPol.SelectedIndex == 0)
            {
                emp.pol = "М";
            } else
            {
                emp.pol = "Ж";
            }

            if (cbVU.SelectedItem == null)
            {
                emp.idVU = 1;
            } else
            {
                emp.idVU = (cbVU.SelectedItem as DriverLicense).id;
            }

            if (cbIsDri.SelectedIndex == 0)
            {
                emp.isDri = true;
            } else
            {
                emp.isDri = false;
            }

            if (cbIsDis.SelectedIndex == 0)
            {
                emp.isDis = true;
            }
            else
            {
                emp.isDis = false;
            }

            if (cbIsAdm.SelectedIndex == 0)
            {
                emp.isAdm = true;
            } else
            {
                emp.isAdm = false;
            }

            if (cbIsPer.SelectedIndex == 0)
            {
                emp.isPer = true;
            }
            else
            {
                emp.isPer = false;
            }           

            if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
            {
                PageHelper.DbConnect.Personal.Add(emp);
                PageHelper.DbConnect.SaveChangesAsync();
                MessageBox.Show("Запись добавлена.", "ОК");
                PageHelper.MainFrame.Navigate(new empListPage());
            }
        }
    }
}