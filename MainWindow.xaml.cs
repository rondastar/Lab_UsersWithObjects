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
        static List<User> users = new List<User>();
        static User _currentUser = null;

        static MainWindow mw = new MainWindow();
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
            if(ValidateSizeAndCoolingCoefficient())
            {
                Tumbler newTumbler = new Tumbler(NewDrinkwareSize(), NewMaterial(), NewCoolingCoefficient(), NewColor());
            }
          
        }

        private void btnAddCoffeeMug_Click(object sender, RoutedEventArgs e)
        {
             if (ValidateSizeAndCoolingCoefficient())
             {
                 CoffeeMug newMug = new CoffeeMug(NewDrinkwareSize(), NewMaterial(), NewCoolingCoefficient(), NewColor(), NewHandleType(), NewMugHasLid());
             }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            if (firstName != "" && lastName != "")
            {
                User newUser = new User(firstName, lastName);
                users.Add(newUser);

            }
            else
            {
                MessageBox.Show("Please enter a first and last name");
            }


        }
        private void RefreshUserDisplay()
        {
            cbUsers.Items.Refresh();
        }
        private void DisplayUsers()
        {
            cbUsers.ItemsSource = users;
        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = cbUsers.SelectedIndex;
            _currentUser = users[selectedIndex];
        }
        private void DisplayDrinkware()
        {

            lbUserDrinkware.ItemsSource = _currentUser.Drinkwares;
        }
    }
}
