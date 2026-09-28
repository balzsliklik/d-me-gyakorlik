using System.Data.SqlTypes;
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

namespace döme_gyakorlik
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

        private void foglalas_Click(object sender, RoutedEventArgs e)
        {
            List<string> extrák = new List<string>();
            if(extra3d.IsChecked == true)
            {
                extrák.Add("3D szemuveg");
            }
            if(extraPopcorn.IsChecked == true)
            {
                extrák.Add("Popcorn");
            }
            if(extraUdito.IsChecked == true)
            {
                extrák.Add("Üdítő");
            }

            string nezettfilm = "";

            switch (filmek.SelectedIndex)
            {
                case 0:
                    nezettfilm = "Lego Batman";
                    break;
                case 1:
                    nezettfilm = "Lego Movie";
                    break;
                case 2:
                    nezettfilm = "Avatar (nem a kék genyos)";
                    break;
                case 3:
                    nezettfilm = "Mi vagyunk Döme | 18+";
                    break;
            }



            if (isNamevalid() && isAgevalid() && isJegyekValid())
            {
                MessageBox.Show($"összesegzett ár: {arosszegzes()}Ft \n {Nev.Text} \n{Kor.Text}\n \nFilm: {nezettfilm} \nExtrák:\n\t{extrák}", "sikeres Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool isNamevalid()
        {
            string name = Nev.Text.Trim();

            if(name == "")
            {
                MessageBox.Show("add meg a neved!");
                Nev.Focus();
                return false;
            }
            if (name.Length < 3)
            {
                MessageBox.Show("a nevednek legalább 3 karakter hosszúnak kell lennie!");
                Nev.Focus();
                return false;
            }

            return true;
        }
        private bool isAgevalid()
        {
            int age = Convert.ToInt32(Kor.Text.Trim());
            if (age < 10)
            {
                MessageBox.Show("😂👍");
                Kor.Focus();
                return false;
            } 
            
            if(filmek.SelectedIndex == 3  && age < 18)
            {
                MessageBox.Show("Tul fiatal vagy ehhez a filmhez "+ "😂");
                Kor.Focus();
                return false;
            }
            return true;
        }private int arosszegzes()
        {
            int arosszegzes = 0;
            int jegyar = 0;

            if(jegyDiak.IsChecked == true)
            {
                jegyar = 1500;
            }
            else if (jegySima.IsChecked == true)
            {
                jegyar = 2500;
            }
            else if (jegyVip.IsChecked == true)
            {
                jegyar = 4000;
            }

            arosszegzes += Convert.ToInt32(jegySzam.Text.Trim()) * jegyar;

            if (extraPopcorn.IsChecked == true)
            {
                arosszegzes += 1200;
            }
            if (extraUdito.IsChecked == true)
            {
                arosszegzes +=800;
            }
            if(extra3d.IsChecked == true)
            {
                arosszegzes += 500;
            }

            return arosszegzes;
        }
        private bool isJegyekValid()
        {
            if(Convert.ToInt32(jegySzam.Text.Trim()) > 10)
            {
                MessageBox.Show("tul sok jegyet szeretnél venni!");
                return false;
            }
            return true;
        }

    }
}