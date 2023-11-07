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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(CompanyEntities db  = new CompanyEntities())
            {
                Clients client = new Clients();
                client.id_client = Int32.Parse(TextId.Text);
                client.name = TextName.Text;
                client.surname = TextName2.Text;
                client.patronymic = TextName3.Text;
                client.mail = TextEmail.Text;
                client.telephone = TextTelephone.Text;
                db.Clients.Add(client);
                db.SaveChanges();
            }
            MessageBox.Show("Добавление произошло успешно");
            Client_Window client_Window = new Client_Window();
            client_Window.Show();
            this.Close();
        }
    }
}
