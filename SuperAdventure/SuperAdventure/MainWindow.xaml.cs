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
        public List<Enemy> enemies = new List<Enemy>();
        public List<Item> itemList = new List<Item>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            
            lblLocation.Content = currentRoom.Name;
            lblLocDescript.Content = currentRoom.Description;

            enemies.Clear();
            itemList.Clear();

            foreach (var enemy in currentRoom.enemies)
            {
                enemies.Add(enemy);
            }
            dgEnemies.ItemsSource = enemies;

            foreach (var item in currentRoom.items)
            {
                itemList.Add(item);
            }
            dgItems.ItemsSource = itemList;

            AddContentToBlock();
        }

        private void AddContentToBlock()
        {
            txtCenter.Text += $"You have entered {currentRoom.Name}. They say {currentRoom.Description}!{Environment.NewLine}{Environment.NewLine} Enemies: {Environment.NewLine}";
            PrintEnemies();
            PrintItems();
            txtCenter.Text += $"--------------------------------------------{Environment.NewLine}";
        }

        private void PrintEnemies()
        {
            foreach(var enem in enemies)
            {
                txtCenter.Text += $"{enem.Name} - Health: {enem.Health}{Environment.NewLine}";
            }
        }

        private void PrintItems()
        {
            txtCenter.Text += $"{Environment.NewLine}Items: {Environment.NewLine}";
            foreach(var item in itemList)
            {
                txtCenter.Text += $"{item.Name}{Environment.NewLine}";
            }
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            if (dgEnemies.SelectedItem != null)
            {
                enemies[dgEnemies.SelectedIndex].LoseHealth(player.DealDamage());
                dgEnemies.Items.Refresh();
            }
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
                dgItems.Items.Refresh();
                dgEnemies.Items.Refresh();
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
                dgItems.Items.Refresh();
                dgEnemies.Items.Refresh();
            }
            else
            {
                MessageBox.Show("You cannot go backwards anymore", "First room Encountered");
            }
        }

    }
}
