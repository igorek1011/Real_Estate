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
    /// Логика взаимодействия для AddDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        public AddDealWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (TextId.Text != "" || TextId.Text != "" || TextIdOffers.Text != "" || TextIdRequirement.Text != "" )
                {
                    Deal deal = new Deal();
                    deal.id_deal = Int32.Parse(TextId.Text);
                    deal.id_offers = Int32.Parse(TextIdOffers.Text);
                    deal.id_requirement = Int32.Parse(TextIdRequirement.Text);
                    

                    db.Deal.Add(deal);
                    db.SaveChanges();
                }
                else { MessageBox.Show("Заполните пожалуста все поля"); }
            }
            MessageBox.Show("Добавление произошло успешно");
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
            this.Close();
        }
    }
}
