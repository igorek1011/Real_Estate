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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Real_Estate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartRotation();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Client_Window client_Window = new Client_Window();
            client_Window.Show();
        }

        private void Realtors_Click(object sender, RoutedEventArgs e)
        {
            RealtorsWindow realtorsWindow = new RealtorsWindow();
            realtorsWindow.Show();
        }
        private async void StartRotation()
        {
            while (true)
            {
                var rotateAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 360,
                    Duration = TimeSpan.FromSeconds(5)
                };

                var rotateTransform = new RotateTransform();
                myImage.RenderTransform = rotateTransform;

                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

                await Task.Delay(TimeSpan.FromSeconds(5));

                // Ждем, пока анимация завершится
                await Task.Delay(TimeSpan.FromSeconds(5));

                // Ждем 10 секунд перед запуском следующей итерации
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        private void RealEstate_Click(object sender, RoutedEventArgs e)
        {
            RealEstateWindow realEstateWindow = new RealEstateWindow();
            realEstateWindow.Show();
        }

        private void Offers_Click(object sender, RoutedEventArgs e)
        {
            OffersWindow offersWindow = new OffersWindow();
            offersWindow.Show();
        }

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
        }
    }
}
