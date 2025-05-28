using Nyelviskola_Lib;
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

namespace NyelviskolaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore.InitCSV();
            cB_nyelv.ItemsSource = DataStore.Instance!.Nyelvek;
        }

        private void cB_nyelv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (cB_nyelv.SelectedItem as Nyelv)!.NyelvID;
            var tanarok = DataStore.Instance!.Tanarok.Where(x => x.NyelvID == id);
            cB_tanar.ItemsSource = tanarok;
            if (tanarok.Any())
            {
                cB_tanar.IsEnabled = true;
            }
            else
            {
                cB_tanar.IsEnabled = false;
                grid_adatok.Visibility= Visibility.Hidden;
            }
        }

        private void cB_tanar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tanar = cB_tanar.SelectedItem as Tanar;
            if(tanar is null)
            {
                grid_adatok.Visibility = Visibility.Hidden;
                return;
            }
            t_telefon.Text = tanar!.Telefon;
            t_email.Text = tanar!.Email;
            t_oradij.Text = tanar!.Oradij.ToString();
            chB_net.IsChecked = tanar!.Net;
            grid_adatok.Visibility = Visibility.Visible;
        }
    }
}