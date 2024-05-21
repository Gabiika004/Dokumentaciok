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
using MySql.Data.MySqlClient;

namespace Bookclub_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MemberService service;
        private List<Member> members;
        public MainWindow()
        {
            InitializeComponent();
            service = new MemberService();
            members = new List<Member>();
            GetAllCars();
            LoadDataGrid();
        }

        private void GetAllCars()
        {
            try
            {
                members = service.ReadAllBooks();
            }
            catch (MySqlException e)
            {
                MessageBox.Show($"Hiba: {e}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDataGrid()
        {
            if (members == null)
            {
                MessageBox.Show("Hoppá a lista nem létezik, vegye fel a kapcsolatot az adminisztrátorral!","Üres lista", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else if(members.Count == 0 )
            {
                MessageBox.Show("Hoppá, úgy tűnik a lista üres!", "Nem létező lista", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MemberDataGrid.ItemsSource = members;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DeOrActivateMember();
        }

        private void DeOrActivateMember()
        {
            var selectedMember = MemberDataGrid.SelectedItem as Member;
           
            if (selectedMember != null)
            {
                string message = selectedMember.Banned ? "aktiválni" : "kitiltani";
               var result = MessageBox.Show($"Valóban szeretné {message} '{selectedMember.Name}' nevű tagot az adatbázisból?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.No) return;
                try
                {
                    service.UpdateMemberBannedStatus(selectedMember);
                    GetAllCars();
                    LoadDataGrid();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"Hiba: {e}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Nem választott ki tagot!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}