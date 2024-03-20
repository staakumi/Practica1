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
            EmployeesDgr.ItemsSource = context.Shop_Employees.ToList();
            


            ProductsDgr.ItemsSource = context.Products.ToList();
            




        }
        private void ShowEmployees_ClickEF(object sender, RoutedEventArgs e)
        {
            IDTbx.Visibility = Visibility.Visible;
            SurnameTbx.Visibility = Visibility.Visible;
            NameTbx.Visibility = Visibility.Visible;
            MiddleNameTbx.Visibility = Visibility.Visible;
            AgeTbx.Visibility = Visibility.Visible;

            IDPro.Visibility = Visibility.Collapsed;
            NamePro.Visibility = Visibility.Collapsed;
            PricePro.Visibility = Visibility.Collapsed;

            EmployeesDgr.Visibility = Visibility.Visible;
            ProductsDgr.Visibility = Visibility.Collapsed;
        }
        private void ShowProducts_ClickEF(object sender, RoutedEventArgs e)
        {
            IDTbx.Visibility = Visibility.Collapsed;
            SurnameTbx.Visibility = Visibility.Collapsed;
            NameTbx.Visibility = Visibility.Collapsed;
            MiddleNameTbx.Visibility = Visibility.Collapsed;
            AgeTbx.Visibility = Visibility.Collapsed;

            IDPro.Visibility= Visibility.Visible;
            NamePro.Visibility= Visibility.Visible;
            PricePro.Visibility= Visibility.Visible;

            EmployeesDgr.Visibility = Visibility.Collapsed;
            ProductsDgr.Visibility = Visibility.Visible;
        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            if(EmployeesDgr.Visibility == Visibility.Visible)
            {

            Shop_Employees emp = new Shop_Employees();
            emp.ID_Employees_Info = Convert.ToInt32(IDTbx.Text);
            emp.Employees_Last_Name = SurnameTbx.Text;
            emp.Employees_First_Name = NameTbx.Text;
            emp.Employees_Middle_Name = MiddleNameTbx.Text;
            emp.Employees_Age = Convert.ToInt32(AgeTbx.Text);
            context.Shop_Employees.Add(emp);
            context.SaveChanges();
            EmployeesDgr.ItemsSource = context.Shop_Employees.ToList();

            }
            else
            {
                Products emp2 = new Products();
                emp2.ID_Products_Info = Convert.ToInt32(IDPro.Text);
                emp2.Products_Name = NamePro.Text;
                emp2.Products_Price = Convert.ToInt32(PricePro.Text);
                context.Products.Add(emp2);
                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Products.ToList();
            }
        }
        private void ButtonChangeClick(object sender, RoutedEventArgs e)
        {
            if(EmployeesDgr.SelectedItem != null)
            {
                    var selected = EmployeesDgr.SelectedItem as Shop_Employees;
                selected.ID_Employees_Info = Convert.ToInt32(IDPro.Text);
                selected.Employees_First_Name = NameTbx.Text;
                selected.Employees_Last_Name = SurnameTbx.Text;
                selected.Employees_Middle_Name = MiddleNameTbx.Text;
                selected.Employees_Age = Convert.ToInt32(AgeTbx.Text);

                context.SaveChanges();
                EmployeesDgr.ItemsSource = context.Shop_Employees.ToList();
            }
            if(ProductsDgr.SelectedItem != null)
            {
                var selectedPro = ProductsDgr.SelectedItem as Products;
                selectedPro.ID_Products_Info = Convert.ToInt32(IDPro.Text);
                selectedPro.Products_Name = NamePro.Text;
                selectedPro.Products_Price = Convert.ToInt32(PricePro.Text);

                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Products.ToList();
            }
        }
        private void ButtonRemoveClick(object sender, RoutedEventArgs e)
        {
            if(EmployeesDgr.SelectedItem != null)
            {
                context.Shop_Employees.Remove(EmployeesDgr.SelectedItem as Shop_Employees);

                context.SaveChanges();
                EmployeesDgr.ItemsSource = context.Shop_Employees.ToList();
            }
            if(ProductsDgr.SelectedItem != null)
            {
                context.Products.Remove(ProductsDgr.SelectedItem as Products);
                 
                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Products.ToList();
            }

        }
        private void EmployeesDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesDgr.SelectedItem != null)
            {
                var selected = EmployeesDgr.SelectedItem as Shop_Employees;

                IDTbx.Text = selected.ID_Employees_Info.ToString();
                NameTbx.Text = selected.Employees_First_Name;
                SurnameTbx.Text = selected.Employees_Last_Name;
                MiddleNameTbx.Text = selected.Employees_Middle_Name;
                AgeTbx.Text = selected.Employees_Age.ToString();
            }
        }

        private void ProductsDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsDgr.SelectedItem != null)
            {
                var selectedPro = ProductsDgr.SelectedItem as Products;

                IDPro.Text = selectedPro.ID_Products_Info.ToString();
                NamePro.Text = selectedPro.Products_Name;
                PricePro.Text = selectedPro.Products_Price.ToString();
            }
        }
    }
}
