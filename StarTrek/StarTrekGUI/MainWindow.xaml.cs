using StarTrek_Lib;
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

namespace StarTrekGUI
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
            szerep_Cb.ItemsSource = DataStore.Instance.HajoSzerepek.OrderBy(x=>x.SzerepNev);
        }

        private void szerep_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var szerepID = (szerep_Cb.SelectedItem as HajoSzerepek)!.SzerepId;
            var osztalyok = DataStore.Instance?.HajoOsztalyok.Where(x=>x.SzerepId == szerepID).Select(x=>x.OsztalyId).ToList(); ;
            var urhalyok = DataStore.Instance?.Urhajok.Where(x => osztalyok.Contains(x.OsztalyId)).ToList();
            urhajo_Cb.ItemsSource = urhalyok;


            if (urhalyok.Any())
            {
                urhajo_Cb.IsEnabled = true;
            }
            else
            {
                urhajo_Cb.IsEnabled=false;
                grid_adatok.Visibility = Visibility.Hidden;
            }
        }

        private void urhajo_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var urhajo = urhajo_Cb.SelectedItem as Urhajok;

            if(urhajo == null)
            {
                grid_adatok.Visibility= Visibility.Hidden;
                return;
            }
            osztaly_tb.Text = DataStore.Instance.HajoOsztalyok.FirstOrDefault(x => x.OsztalyId == urhajo.OsztalyId)?.OsztalyNev;
            faj_tb.Text = DataStore.Instance.Fajok.FirstOrDefault(x => x.FajId == urhajo.FajId)?.FajNev;
            grid_adatok.Visibility = Visibility.Visible;
        }
    }
}