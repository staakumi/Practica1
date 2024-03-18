using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Practica1.Hobby_shopDataSetTableAdapters;

namespace Practica1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        Shop_Employees_RusTableAdapter employees = new Shop_Employees_RusTableAdapter();
        Products_RusTableAdapter products = new Products_RusTableAdapter();
        public MainWindow()
        {


            InitializeComponent();
            EmployeesDataGrid.ItemsSource = employees.GetData();
            EmployeesDataGrid.DisplayMemberPath = "Фамилия сотрудника";

            ProductsDataGrid.ItemsSource = products.GetData();
            ProductsDataGrid.DisplayMemberPath = "Название товара";

        }
        
        public void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesDataGrid.Visibility = Visibility.Visible;
            ProductsDataGrid.Visibility = Visibility.Collapsed;
        }
        public void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            EmployeesDataGrid.Visibility = Visibility.Collapsed;
            ProductsDataGrid.Visibility = Visibility.Visible;
        }


        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2(Window2.DataType.Employees); 
            window.Show();
        }
    }

    public partial class Window2 : Window
    {
        private Hobby_shopEntities4 context = new Hobby_shopEntities4();
        public enum DataType
        {
            Employees,
            Products
        }

        public Window2(DataType dataType)
        {
            InitializeComponent();
            EmployeesDgr.ItemsSource = context.Shop_Employees_Rus.ToList();
            EmployeesDgr.DisplayMemberPath = "Фамилия сотрудника";


            ProductsDgr.ItemsSource = context.Products_Rus.ToList();
            ProductsDgr.DisplayMemberPath = "Название товара";

            if (dataType == DataType.Employees)
            {
                EmployeesDgr.Visibility = Visibility.Visible;
                ProductsDgr.Visibility = Visibility.Collapsed;
            }
            else if (dataType == DataType.Products)
            {
                EmployeesDgr.Visibility = Visibility.Collapsed;
                ProductsDgr.Visibility = Visibility.Visible;
            }


        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            Shop_Employees_Rus emp = new Shop_Employees_Rus();
            emp.Имя_сотрудника = NameTbx.Text;

            context.Shop_Employees_Rus.Add(emp);
            context.SaveChanges();
            EmployeesDgr.ItemsSource = context.Shop_Employees_Rus.ToList();
        }
        private void ButtonChangeClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonRemoveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
