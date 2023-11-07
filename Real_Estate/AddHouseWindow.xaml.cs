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
    /// Логика взаимодействия для AddHouseWindow.xaml
    /// </summary>
    public partial class AddHouseWindow : Window
    {
        public AddHouseWindow()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                RealEstate realEstate = new RealEstate();
                realEstate.id_object = Int32.Parse(TextId.Text);
                realEstate.object_type = "house";
                realEstate.number_of_floors = Int32.Parse(TextNumderOfFloors.Text);
                realEstate.rooms = Int32.Parse(TextRooms.Text);
                realEstate.square = Double.Parse(TextSquare.Text);
                if (TextCity.Text != "") { realEstate.address_city = TextCity.Text; }
                if (TextStreet.Text != "") { realEstate.address_street = TextStreet.Text; }
                if (TextHouse.Text != "") { realEstate.address_house = Int32.Parse(TextHouse.Text); }
                if (TextApartment.Text != "") { realEstate.address_number = Int32.Parse(TextApartment.Text); }
                if (TextLatitude.Text != "") { realEstate.coordinate_latitude = Int32.Parse(TextLatitude.Text); }
                if (TextLongitude.Text != "") { realEstate.coordinate_longitude = Int32.Parse(TextLongitude.Text); }
                db.RealEstate.Add(realEstate);
                db.SaveChanges();
            }
            MessageBox.Show("Добавление произошло успешно");
            RealEstateWindow realEstateWindow = new RealEstateWindow();
            realEstateWindow.Show();
            this.Close();
        }
    }
}
