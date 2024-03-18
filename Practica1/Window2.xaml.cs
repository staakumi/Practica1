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
using System.Windows.Shapes;

namespace Practica1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Hobby_shopEntities4 context = new Hobby_shopEntities4();


        public Window2()
        {
            InitializeComponent();
            EmployeesDgr.ItemsSource = context.Shop_Employees_Rus.ToList();
            EmployeesDgr.DisplayMemberPath = "Фамилия сотрудника";


            ProductsDgr.ItemsSource = context.Products_Rus.ToList();
            ProductsDgr.DisplayMemberPath = "Название товара";




        }
        private void ShowEmployees_ClickEF(object sender, RoutedEventArgs e)
        {
            EmployeesDgr.Visibility = Visibility.Visible;
            ProductsDgr.Visibility = Visibility.Collapsed;
        }
        private void ShowProducts_ClickEF(Object sender, RoutedEventArgs e)
        {
            EmployeesDgr.Visibility = Visibility.Collapsed;
            ProductsDgr.Visibility = Visibility.Visible;
        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            Shop_Employees emp = new Shop_Employees();
            emp.Employees_Last_Name = NameTbx.Text;

            context.Shop_Employees.Add(emp);
            context.SaveChanges();
            EmployeesDgr.ItemsSource = context.Shop_Employees.ToList();
        }
        private void ButtonChangeClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonRemoveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
