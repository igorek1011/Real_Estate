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

namespace Real_Estate
{
    /// <summary>
    /// Логика взаимодействия для DealWindow.xaml
    /// </summary>
    public partial class DealWindow : Window
    {
        private List<Deal> deals;
        public DealWindow()
        {
            InitializeComponent();

            using (CompanyEntities db = new CompanyEntities())
            {
                deals = db.Deal.ToList();
            }
            // Пример данных о клиентах (можно заменить своими данными)

            DealsDataGrid.ItemsSource = deals;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           using (CompanyEntities db = new CompanyEntities())
            {
                if (DealsDataGrid.SelectedItem != null && DealsDataGrid.SelectedItem is Deal selectedDeal)
                {

                    Deal deal = db.Deal.Find(selectedDeal.id_deal);
                    //realtor.id_realtor = selectedDeal.id_realtor;
                    deal.id_offers = selectedDeal.id_offers;
                    deal.id_requirement = selectedDeal.id_requirement;
                    db.SaveChanges();
                    MessageBox.Show("Изменения произошли успешно");
                    DealsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    deals = db.Deal.ToList();
                    DealsDataGrid.ItemsSource = deals;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (DealsDataGrid.SelectedItem != null && DealsDataGrid.SelectedItem is Deal selectedDeal)
                {
                    var customer = db.Deal.Single(o => o.id_deal == selectedDeal.id_deal);
                    db.Deal.Remove(customer);
                    db.SaveChanges();
                    DealsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    deals = db.Deal.ToList();
                    DealsDataGrid.ItemsSource = deals; // Обновление источника данных DataGrid

                }

            }


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow adddealWindow = new AddDealWindow();
            adddealWindow.Show();
            this.Close();
        }
        private void DealsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {


        }
    }
}
