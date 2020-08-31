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

        public void UpdatePlayerInfo()
        {
            lblExp.Content = player.Exp;
            lblGold.Content = player.Gold;
            lblLevel.Content = player.PlayerLevel;
            lblWeapon.Content = player.GetWeapon().Name;
            lblDamage.Content = player.GetWeapon().Damage;
            lblWeaponHealth.Content = player.GetWeapon().Health;
        }

        public void UpdateLabels()
        {
            
            lblLocation.Content = currentRoom.Name;
            lblLocDescript.Content = currentRoom.Description;
            UpdatePlayerInfo();

            dgEnemies.ItemsSource = currentRoom.enemies;
            dgItems.ItemsSource = currentRoom.items;

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
            foreach(var enem in currentRoom.enemies)
            {
                txtCenter.Text += $"{enem.Name} - Health: {enem.Health}{Environment.NewLine}";
            }
        }

        private void PrintItems()
        {
            txtCenter.Text += $"{Environment.NewLine}Items: {Environment.NewLine}";
            foreach(var item in currentRoom.items)
            {
                txtCenter.Text += $"{item.Name}{Environment.NewLine}";
            }
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            if (dgEnemies.SelectedItem != null)
            {
                if (currentRoom.enemies[dgEnemies.SelectedIndex].Health - player.DealDamage() > 0)
                {
                    currentRoom.enemies[dgEnemies.SelectedIndex].LoseHealth(player.DealDamage());
                    dgEnemies.Items.Refresh();
                    txtCenter.Text += $"You dealt {player.DealDamage()} with {player.GetWeapon().Name} to {currentRoom.enemies[dgEnemies.SelectedIndex].Name}{Environment.NewLine}";
                    UpdatePlayerInfo();
                }
                else
                {
                    var rewards = new DeathRewards();
                    player.GainExp(rewards.Exp);
                    player.GetGold(rewards.Gold);
                    txtCenter.Text += $"You killed {currentRoom.enemies[dgEnemies.SelectedIndex].Name}!{Environment.NewLine}You gained {rewards.Gold} Gold & {rewards.Exp} Exp!{Environment.NewLine}";
                    currentRoom.enemies.Remove(currentRoom.enemies[dgEnemies.SelectedIndex]);
                    dgEnemies.Items.Refresh();
                    UpdatePlayerInfo();

                    if (currentRoom.enemies.Count == 0)
                    {
                        txtCenter.Text += "Congrats, you have cleared this room!";
                    }
                }
            }
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItem != null)
            {
                player.GrabItem(currentRoom.items[dgItems.SelectedIndex]);

                if (currentRoom.items[dgItems.SelectedIndex].GetType() == typeof(Relic))
                {
                    txtCenter.Text += $" You picked up {currentRoom.items[dgItems.SelectedIndex].Name}{Environment.NewLine}";
                }
                else if (currentRoom.items[dgItems.SelectedIndex].GetType() == typeof(Weapon))
                {
                    txtCenter.Text += $"You picked up a weapon named {currentRoom.items[dgItems.SelectedIndex].Name} with {player.GetWeapon().Damage}{Environment.NewLine}";
                }
                currentRoom.items.Remove(currentRoom.items[dgItems.SelectedIndex]);
                dgItems.Items.Refresh();
                UpdatePlayerInfo();
            }
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
