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
    }
}