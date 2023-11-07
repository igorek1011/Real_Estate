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
    /// Логика взаимодействия для OffersWindow.xaml
    /// </summary>
    public partial class OffersWindow : Window
    {
        private List<Offers> offers;
        public OffersWindow()
        {
            InitializeComponent();
            
            using (CompanyEntities db = new CompanyEntities())
            {
                offers = db.Offers.ToList();
            }
            // Пример данных о клиентах (можно заменить своими данными)

            OffersDataGrid.ItemsSource = offers;
        }
       
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           using (CompanyEntities db = new CompanyEntities())
            {
                if (OffersDataGrid.SelectedItem != null && OffersDataGrid.SelectedItem is Offers selectedOffers)
                {

                    Offers offer = db.Offers.Find(selectedOffers.id_offers);
                    //realtor.id_realtor = selectedOffers.id_realtor;
                    offer.id_offers = selectedOffers.id_offers; 
                    offer.id_client = selectedOffers.id_client;
                    offer.id_realtor = selectedOffers.id_realtor;
                    offer.price = selectedOffers.price;
                    db.SaveChanges();
                    MessageBox.Show("Изменения произошли успешно");
                    OffersDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    offers = db.Offers.ToList();
                    OffersDataGrid.ItemsSource = offers;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (OffersDataGrid.SelectedItem != null && OffersDataGrid.SelectedItem is Offers selectedoffers)
                {
                    var customer = db.Offers.Single(o => o.id_offers == selectedoffers.id_offers);
                    db.Offers.Remove(customer);
                    db.SaveChanges();
                    OffersDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    offers = db.Offers.ToList();
                    OffersDataGrid.ItemsSource = offers; // Обновление источника данных DataGrid

                }

            }


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddOffersWindow addOffersWindow = new AddOffersWindow();
            addOffersWindow.Show();
            this.Close();
        }
        private void OffersDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           
            
        }
    }
}
