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
    /// Логика взаимодействия для AddOffersWindow.xaml
    /// </summary>
    public partial class AddOffersWindow : Window
    {
        public AddOffersWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            { if (TextId.Text != "" || TextIdClient.Text != "" || TextIdRealtor.Text != "" || TextIdObject.Text != "" || TextPrice.Text != "")
                { Offers offers = new Offers();
                    offers.id_offers = Int32.Parse(TextId.Text);
                    offers.id_client = Int32.Parse(TextIdClient.Text);
                    offers.id_realtor = Int32.Parse(TextIdRealtor.Text);
                    offers.id_object = Int32.Parse(TextIdObject.Text);
                    offers.price = Int32.Parse(TextPrice.Text);
                    
                    db.Offers.Add(offers);
                    db.SaveChanges(); }
                else { MessageBox.Show("Заполните пожалуста все поля"); }
            }
            MessageBox.Show("Добавление произошло успешно");
            OffersWindow offersWindow = new OffersWindow();
            offersWindow.Show();
            this.Close();
        }
    }
}
