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

namespace UsersWithObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnAddTumbler_Click(object sender, RoutedEventArgs e)
        {
            if(float.TryParse(txtSizeInOz.Text, out float resultSize))
            {
                float sizeInOz = resultSize;
                if (double.TryParse(txtCoolingCoefficient.Text, out double resultCoefficient))
                {
                    double coolingCoefficient = resultCoefficient;
                    string material = txtMaterial.Text;
                    string color = txtColor.Text;
                    if (material != "" && color != "")
                    {
                        Tumbler newTumbler = new Tumbler(sizeInOz, material, coolingCoefficient, color);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number as cooling coefficient");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid size");
            }
        }

        private void btnAddCoffeeMug_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(txtSizeInOz.Text, out float resultSize))
            {
                float sizeInOz = resultSize;
                if (double.TryParse(txtCoolingCoefficient.Text, out double resultCoefficient))
                {
                    double coolingCoefficient = resultCoefficient;
                    string material = txtMaterial.Text;
                    string color = txtColor.Text;
                    string handleType = txtHandleType.Text;
                    bool hasLid = ckHasLid.IsChecked.Value;
                    if (material != "" && color != "")
                    {
                        CoffeeMug newMug = new CoffeeMug(sizeInOz, material, coolingCoefficient, color, handleType, hasLid);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number as cooling coefficient");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid size");
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
        private void DisplayUsers()
        {
            cbUsers.ItemsSource = users;
        }
       
    }
}
