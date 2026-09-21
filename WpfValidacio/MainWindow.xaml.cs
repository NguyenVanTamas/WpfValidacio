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

namespace WpfValidacio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Név ellenőrzése
                if (!IsNameValid())
                {
                    return;
                }

                //Email ellenőrzés
                if (!IsEmailValid())
                {
                    return;
                }

                //Jelszó ellenőrzése
                if (!IsPasswordValid())
                {
                    return;
                }

                //Jelszó újraellenőrzése
                if (!IsPasswordAgainSame())
                {
                    return;
                }

                //Életkor ellenőrzése
                if (!IsAgeValid())
                {
                    return;
                }

                //Felhasználási feltételek elfogadásának ellenőrzése
                if (!AreTermsAccepted())
                {
                    return;
                }

                int age = Convert.ToInt32(txtAge.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Az életkorhoz számot adj meg!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Túl nagy számot adtál meg életkornak!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool IsNameValid()
        {
            string name = txtName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("Add meg a neved!");
                txtName.Focus();
                return false;
            }
            if (name.Length < 3)
            {
                MessageBox.Show("A név legalább 3 karakter hosszú legyen!");
                txtName.Focus();
                return false;
            }
            return true;
        }
        private bool IsEmailValid()
        {
            string email = txtEmail.Text.Trim();

            if (email == "")
            {
                MessageBox.Show("Add meg az e-mail címed!");
                txtEmail.Focus();
                return false;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Az e-mail címnek tartalmaznia kell @ jelet!");
                txtEmail.Focus();
                return false;
            }
            if (!email.Contains("."))
            {
                MessageBox.Show("Az e-mail címnek tartalmaznia kell . jelet!");
                txtEmail.Focus();
                return false;
            }
            if (email.Contains(" "))
            {
                MessageBox.Show("Az e-mail cím nem tartalmazhat szóközt!");
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        private bool IsPasswordValid()
        {
            string password = txtPassword.Password;

            if (password == "")
            {
                MessageBox.Show("Add meg a jelszavad!");
                txtPassword.Focus();
                return false;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("A jelszó legalább 6 karakter hosszú legyen!");
                txtPassword.Focus();
                return false;
            }

            bool hasLowerCase = false;
            bool hasUpperCase = false;
            bool hasNumber = false;
            bool hasSpecialCharacter = false;

            foreach (char character in password)
            {
                if (char.IsLower(character))
                {
                    hasLowerCase = true;
                }
                if (char.IsUpper(character))
                {
                    hasUpperCase = true;
                }
                if (char.IsDigit(character))
                {
                    hasNumber = true;
                }
                if (!char.IsLetterOrDigit(character) || char.IsSymbol(character))
                {
                    hasSpecialCharacter = true;
                }
            }

            if (!hasLowerCase)
            {
                MessageBox.Show("A jelszónak tartalmaznia kell legalább egy kisbetűt!");
                txtPassword.Focus();
                return false;
            }
            if (!hasUpperCase)
            {
                MessageBox.Show("A jelszónak tartalmaznia kell legalább egy nagybetűt!");
                txtPassword.Focus();
                return false;
            }
            if (!hasNumber)
            {
                MessageBox.Show("A jelszónak tartalmaznia kell legalább egy számot!");
                txtPassword.Focus();
                return false;
            }
            if (!hasSpecialCharacter)
            {
                MessageBox.Show("A jelszónak tartalmaznia kell legalább egy speciális karakter!");
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        private bool IsPasswordAgainSame()
        {
            if (txtPassword.Password != txtPasswordAgain.Password)
            {
                MessageBox.Show("A két jelszó nem egyezik meg!");
                txtPasswordAgain.Focus();
                return false;
            }
            return true;
        }
        private bool IsAgeValid()
        {
            if (Convert.ToInt32(txtAge.Text) < 18)
            {
                MessageBox.Show("18 év alatt nem lehet regisztrálni!");
                txtAge.Focus();
                return false;
            }
            return true;
        }
        private bool AreTermsAccepted()
        {
            if (checkTerms.IsChecked == false)
            {
                MessageBox.Show("A felhasználási feltételeket el kell hogy fogadja!");
                checkTerms.Focus();
                return false;
            }
            return true;
        }
    }
}