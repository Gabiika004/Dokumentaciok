using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<Car> cars;
        public MainWindow()
        {
            InitializeComponent();

            cars = new List<Car>
            {
                new Car(1, "ABC123", "Toyota", "Corolla", 50),
                new Car(2, "XYZ789", "Ford", "Focus", 60),
                new Car(3, "XYZ789", "Ford", "Focus", 60),
                new Car(4, "XYZ789", "Ford", "Focus", 60),
                new Car(5, "XYZ789", "Ford", "Focus", 60),
                new Car(6, "XYZ789", "Ford", "Focus", 60),
                new Car(7, "XYZ789", "Ford", "Focus", 60),
                new Car(8, "XYZ789", "Ford", "Focus", 60),
                new Car(9, "XYZ789", "Ford", "Focus", 60),
                new Car(10, "XYZ789", "Ford", "Focus", 60),
                new Car(11, "XYZ789", "Ford", "Focus", 60),           
                new Car(7, "XYZ789", "Ford", "Focus", 60),
                new Car(8, "XYZ789", "Ford", "Focus", 60),
                new Car(9, "XYZ789", "Ford", "Focus", 60),
                new Car(10, "XYZ789", "Ford", "Focus", 60),
                new Car(11, "XYZ789", "Ford", "Focus", 60),
            };
            CarDataGrid.ItemsSource = cars;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Ellenőrizd, hogy van-e kiválasztott elem
            if (CarDataGrid.SelectedItem != null)
            {
                // Castold a kiválasztott elemet Car típusra
                var selectedCars = CarDataGrid.SelectedItems as List<Car>;

                // Ellenőrizd, hogy a kiválasztott autó tényleg létezik a listában
                if (selectedCars.Count > 0)
                {
                    var result = MessageBox.Show("Valóban szeretné törölni a kiválasztottt autót?", "Törlés",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if (result != MessageBoxResult.Yes) return;
                    // Töröld a kiválasztott autót a listából
                    
                    // Frissítsd a DataGrid forrását a módosított lista alapján
                    CarDataGrid.ItemsSource = null;
                    CarDataGrid.ItemsSource = cars;
                }
            }
            else
            {
                MessageBox.Show("Nem választott ki autót!");
            }
        }

    }
}