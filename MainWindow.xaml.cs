using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UsersWithObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<User> _users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            DisplayUsers();

        }

        private float NewDrinkwareSize()
        {
            // checks whether entry in size text box can be converted to a float, returns number or displays message and returns -1 if not a positive float.
            bool sizeIsfloat = float.TryParse(txtSizeInOz.Text, out float result);
            if (sizeIsfloat)
            {
                return result;
            }
            else
            {
                MessageBox.Show("Please enter a valid size.");
                return -1;
            }
        }

        private double NewCoolingCoefficient()
        {
            // checks whether entry in price text box can be converted to a double, returns price or displays message and returns -1 if not a positive double.
            bool coefficientIsDouble = double.TryParse(txtCoolingCoefficient.Text, out double result);
            if (coefficientIsDouble)
            {
                return result;
            }
            else
            {
                MessageBox.Show("Please enter a valid cooling coefficient.");
                return -1;
            }
        }
        
        private bool ValidateSizeAndCoolingCoefficient()
        {
            // returns true if both size and cooling coefficient are valid, or false if not.
            if (NewDrinkwareSize() != -1 && NewCoolingCoefficient() != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string NewMaterial()
        {
            // returns string in the Material text box
            string material = txtMaterial.Text;
            return material;
        }

        private string NewColor()
        {
            // returns string in the Color text box
            string color = txtColor.Text;
            return color;
        }
        private string NewHandleType()
        {
            // returns the string in the Handle Type text box (for mugs only)
            string handleType = txtHandleType.Text;
            return handleType;
        }

        private bool NewMugHasLid()
        {
            // returns true if has lid is checked, or false if not checked
            bool hasLid = ckHasLid.IsChecked.Value;
            return hasLid;
        }
        private void btnAddTumbler_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = cbUsers.SelectedIndex;
            if (ValidateSizeAndCoolingCoefficient())
            {
                Tumbler newTumbler = new Tumbler(NewDrinkwareSize(), NewMaterial(), NewCoolingCoefficient(), NewColor());
                _users[selectedIndex].Drinkwares.Add(newTumbler);
            }
            else if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a user");
            }
            DisplayUsers();
            DisplayDrinkware(selectedIndex);
        }

        private void btnAddCoffeeMug_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = cbUsers.SelectedIndex;
            if (ValidateSizeAndCoolingCoefficient() && selectedIndex >= 0)
             {
                 CoffeeMug newMug = new CoffeeMug(NewDrinkwareSize(), NewMaterial(), NewCoolingCoefficient(), NewColor(), NewHandleType(), NewMugHasLid());
                 _users[selectedIndex].Drinkwares.Add(newMug);
             }
            else if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a user");
            }
            DisplayUsers();
            DisplayDrinkware(selectedIndex);
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            if (firstName != "" && lastName != "")
            {
                User newUser = new User(firstName, lastName);
                _users.Add(newUser);
            }
            else
            {
                MessageBox.Show("Please enter a first and last name");
            }
            DisplayUsers();
        }
        private void DisplayUsers()
        {
            // Clears the previous display
            cbUsers.Items.Clear();
            // Displays the list of users to the combo box
            for (int i = 0; i < _users.Count; i++)
            {
                cbUsers.Items.Add(_users[i]);
            }

        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = cbUsers.SelectedIndex;
            DisplayDrinkware(selectedIndex);
        }
        private void DisplayDrinkware(int selectedIndex)
        {
            if (selectedIndex >= 0)
            {
                lvUsersDrinkware.ItemsSource = _users[selectedIndex].Drinkwares;
            }
            else
            {
                MessageBox.Show("Please select a user.");
            }
        }
    }
}
