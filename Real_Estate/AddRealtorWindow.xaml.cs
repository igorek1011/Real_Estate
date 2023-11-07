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
    /// Логика взаимодействия для AddRealtorWindow.xaml
    /// </summary>
    public partial class AddRealtorWindow : Window
    {
        public AddRealtorWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                Realtors realtors = new Realtors();
                realtors.id_realtor = Int32.Parse(TextId.Text);
                realtors.name = TextName.Text;
                realtors.surname = TextName2.Text;
                realtors.patronymic = TextName3.Text;
                realtors.commission = Int32.Parse(TextCommission.Text);
                db.Realtors.Add(realtors);
                db.SaveChanges();
            }
            MessageBox.Show("Добавление произошло успешно");
            RealtorsWindow realtorsWindow = new RealtorsWindow();
            realtorsWindow.Show();
            this.Close();
        }
        
    }
}
