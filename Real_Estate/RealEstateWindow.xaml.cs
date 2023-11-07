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
    /// Логика взаимодействия для RealEstateWindow.xaml
    /// </summary>
    public partial class RealEstateWindow : Window
    {
        private List<RealEstate> realEstats;
        public RealEstateWindow()
        {
            InitializeComponent();
            using (CompanyEntities db = new CompanyEntities())
            {
                 realEstats= db.RealEstate.ToList();
            }
            // Пример данных о клиентах (можно заменить своими данными)

            realestatsDataGrid.ItemsSource = realEstats;
        }
        private void RealEstatsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedRealtor = (RealEstate)e.Row.Item;
                using (CompanyEntities db = new CompanyEntities())
                {
                    var existingRealtor = db.Realtors.Find(editedRealtor.id_realtor);
                    if (existingRealtor != null)
                    {
                        editedRealtor.name = editedRealtor.name;
                        editedRealtor.surname = editedRealtor.surname;
                        editedRealtor.patronymic = editedRealtor.patronymic;
                        editedRealtor.name = editedRealtor.name;
                        editedRealtor.surname = editedRealtor.surname;
                        editedRealtor.patronymic = editedRealtor.patronymic;
                        editedRealtor.commission = editedRealtor.commission;
                        editedRealtor.name = editedRealtor.name;
                        editedRealtor.surname = editedRealtor.surname;
                        editedRealtor.patronymic = editedRealtor.patronymic;
                        editedRealtor.commission = editedRealtor.commission;
                        editedRealtor.commission = editedRealtor.commission;
                        db.SaveChanges();
                    }
                }
            }*/
        }


        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (realestatsDataGrid.SelectedItem != null && realestatsDataGrid.SelectedItem is RealEstate selectedRealEstate)
                {

                    RealEstate realEstate = db.RealEstate.Find(selectedRealEstate.id_object);
                   // realEstate.id_object = selectedRealEstate.id_realtor
                    realEstate.object_type = selectedRealEstate.object_type;
                    realEstate.rooms = selectedRealEstate.rooms;
                    realEstate.square = selectedRealEstate.square;
                    realEstate.floor = selectedRealEstate.floor;
                    realEstate.number_of_floors = selectedRealEstate.number_of_floors;
                    realEstate.address_city = selectedRealEstate.address_city;
                    realEstate.address_street = selectedRealEstate.address_street;
                    realEstate.address_house = selectedRealEstate.address_house;
                    realEstate.address_number = selectedRealEstate.address_number;
                    realEstate.coordinate_latitude = selectedRealEstate.coordinate_latitude;
                    realEstate.coordinate_longitude = selectedRealEstate.coordinate_longitude;
                    db.SaveChanges();
                    MessageBox.Show("Изменение произошло успешно");
                    realestatsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    realEstats = db.RealEstate.ToList();
                    realestatsDataGrid.ItemsSource = realEstats;
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (realestatsDataGrid.SelectedItem != null && realestatsDataGrid.SelectedItem is RealEstate selectedRealEstate)
                {
                    var customer = db.RealEstate.Single(o => o.id_object == selectedRealEstate.id_object);
                    db.RealEstate.Remove(customer);
                    db.SaveChanges();
                    realestatsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    realEstats = db.RealEstate .ToList();
                    realestatsDataGrid.ItemsSource = realEstats; // Обновление источника данных DataGrid

                }

            }
        }
        private void AddLandButton_Click(object sender, RoutedEventArgs e)
        {
            AddLandWindow addLandWindow = new AddLandWindow();
            addLandWindow.Show();
            this.Close();
        }
        private void AddHouseButton_Click(object sender, RoutedEventArgs e)
        {
            AddHouseWindow addHouseWindow = new AddHouseWindow();
            addHouseWindow.Show();
            this.Close();
        }
        private void AddApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            AddApartamentWindow addApartamentWindow = new AddApartamentWindow();
            addApartamentWindow.Show();
            this.Close();
        }
    }
}
