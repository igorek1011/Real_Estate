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
using static System.Net.Mime.MediaTypeNames;

namespace Real_Estate
{
    /// <summary>
    /// Логика взаимодействия для Client_Window.xaml
    /// </summary>
    public partial class Client_Window : Window
    {
        private List<Clients> clients;

        public Client_Window()
        {
            InitializeComponent();
            using(CompanyEntities db = new CompanyEntities())
            {
                clients = db.Clients.ToList();
            }
            // Пример данных о клиентах (можно заменить своими данными)
            
            clientsDataGrid.ItemsSource = clients;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (clientsDataGrid.SelectedItem != null && clientsDataGrid.SelectedItem is Clients selectedClient)
                {
                    
                    Clients client = db.Clients.Find(selectedClient.id_client);
                    //client.id_client = selectedClient.id_client;
                    client.name = selectedClient.name;
                    MessageBox.Show(client.name);
                    client.surname = selectedClient.surname;
                    client.patronymic = selectedClient.patronymic;
                    client.mail = selectedClient.mail;
                    client.telephone = selectedClient.telephone;
                    db.SaveChanges();
                    clientsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    clients = db.Clients.ToList();
                    clientsDataGrid.ItemsSource = clients;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (clientsDataGrid.SelectedItem != null && clientsDataGrid.SelectedItem is Clients selectedClient)
                {
                    var customer = db.Clients.Single(o => o.id_client == selectedClient.id_client);
                    db.Clients.Remove(customer);
                    db.SaveChanges();
                    clientsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    clients = db.Clients.ToList();
                    clientsDataGrid.ItemsSource = clients; // Обновление источника данных DataGrid
                  
                }

            }

                
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            this.Close();
        }
        private void ClientsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedClient = (Clients)e.Row.Item;
                using (CompanyEntities db = new CompanyEntities())
                {
                    var existingClient = db.Clients.Find(editedClient.id_client);
                    if (existingClient != null)
                    {
                        existingClient.name = editedClient.name;
                        existingClient.surname = editedClient.surname;
                        existingClient.patronymic = editedClient.patronymic;
                        existingClient.telephone = editedClient.telephone;
                        existingClient.mail = editedClient.mail;
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
