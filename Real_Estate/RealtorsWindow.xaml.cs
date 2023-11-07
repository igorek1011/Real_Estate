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
    /// Логика взаимодействия для RealtorsWindow.xaml
    /// </summary>
    public partial class RealtorsWindow : Window
        
    {
        private List<Realtors> realtors;
        public RealtorsWindow()
        {
            InitializeComponent();
            using (CompanyEntities db = new CompanyEntities())
            {
                realtors = db.Realtors.ToList();
            }
            // Пример данных о клиентах (можно заменить своими данными)

            realtorsDataGrid.ItemsSource = realtors;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (realtorsDataGrid.SelectedItem != null && realtorsDataGrid.SelectedItem is Realtors selectedRealtor)
                {

                    Realtors realtor = db.Realtors.Find(selectedRealtor.id_realtor);
                    //realtor.id_realtor = selectedrealtor.id_realtor;
                    realtor.name = selectedRealtor.name;
                    MessageBox.Show(realtor.name);
                    realtor.surname = selectedRealtor.surname;
                    realtor.patronymic = selectedRealtor.patronymic;
                    realtor.commission = selectedRealtor.commission;
                    db.SaveChanges();
                    realtorsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    realtors = db.Realtors.ToList();
                    realtorsDataGrid.ItemsSource = realtors;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                if (realtorsDataGrid.SelectedItem != null && realtorsDataGrid.SelectedItem is Realtors selectedrealtor)
                {
                    var customer = db.Realtors.Single(o => o.id_realtor == selectedrealtor.id_realtor);
                    db.Realtors.Remove(customer);
                    db.SaveChanges();
                    realtorsDataGrid.ItemsSource = null; // Очистка источника данных DataGrid
                    realtors = db.Realtors.ToList();
                    realtorsDataGrid.ItemsSource = realtors; // Обновление источника данных DataGrid

                }

            }


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRealtorWindow addRealtorWindow = new AddRealtorWindow();
            addRealtorWindow.Show();
            this.Close();
        }
        private void RealtorsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedRealtor = (Realtors)e.Row.Item;
                using (CompanyEntities db = new CompanyEntities())
                {
                    var existingRealtor = db.Realtors.Find(editedRealtor.id_realtor);
                    if (existingRealtor != null)
                    {
                        editedRealtor.name = editedRealtor.name;
                        editedRealtor.surname = editedRealtor.surname;
                        editedRealtor.patronymic = editedRealtor.patronymic;
                        editedRealtor.commission = editedRealtor.commission;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
