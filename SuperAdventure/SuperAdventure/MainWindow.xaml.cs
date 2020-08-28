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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SuperAdventure.models;

namespace SuperAdventure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Player player = new Player("Zerku");
        public static RoomGenerator generator = new RoomGenerator();
        public Room currentRoom = generator.rooms.First();

        public MainWindow()
        {
            InitializeComponent();
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            
            lblLocation.Content = currentRoom.Name;
            lblLocDescript.Content = currentRoom.Description;
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           if (currentRoom != generator.rooms.Last())
            {
                currentRoom = generator.rooms.Find(currentRoom).Next.Value;
                UpdateLabels();
            }
           else
            {
                MessageBox.Show("You cannot go further", "Last Room");
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (currentRoom != generator.rooms.First())
            {
                currentRoom = generator.rooms.Find(currentRoom).Previous.Value;
                UpdateLabels();
            }
            else
            {
                MessageBox.Show("You cannot go backwards anymore", "First room Encountered");
            }
        }
    }
}
