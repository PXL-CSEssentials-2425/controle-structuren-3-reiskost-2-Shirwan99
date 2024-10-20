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

namespace Reiskost_2
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

        private void colculateButton_Click(object sender, RoutedEventArgs e)
        {
            {
                double aantalPersoon = double.Parse( numberOfPersonsTextBox.Text);
                double totVluchtprijs;
                double totVerblijfprijs;
                double korting;
                double teBetalen;
                double totReisprijs;
                int flightClass = Convert.ToInt32(flightClassTextBox.Text);
                double baseFlightPrice = Convert.ToDouble(baseFlightTextBox.Text);
                double kortingspercentage = Convert.ToDouble(reductionPercentageTextBox.Text);
                
                
                switch (flightClass)
                {
                    case 1:
                        totReisprijs = baseFlightPrice * 1.30;
                        break;
                    case 3:
                        totReisprijs = baseFlightPrice * 0.80;
                        break;
                    default:
                        totReisprijs = baseFlightPrice;
                        break;
                }
                        double totaalVerblijfskost = 0.0;

                for (int i = 1; i <= aantalPersoon; i++)
                        {
                            if (i <= 2)
                            {
                                // Eerste en tweede persoon betalen de volledige verblijfskost
                                totaalVerblijfskost += baseFlightPrice;
                            }
                            else if (i == 3)
                            {
                                // Derde persoon krijgt 50% korting
                                totaalVerblijfskost += totaalVerblijfskost * 0.50;
                            }
                            else
                            {
                                // Vierde persoon en verder krijgen 70% korting
                                totaalVerblijfskost += totaalVerblijfskost * 0.30;
                            }
                        }

                        totVluchtprijs = float.Parse(baseFlightTextBox.Text);
                        korting = totReisprijs * kortingspercentage / 100;
                        float.Parse(numberOfPersonsTextBox.Text);

                        totVerblijfprijs = float.Parse(basePriceTextBox.Text) *
                            (float.Parse(numberOfDayTextBox.Text) *
                            float.Parse(numberOfPersonsTextBox.Text));
                        teBetalen = totReisprijs - korting;
                        totReisprijs = totVluchtprijs + totVerblijfprijs;

                        resultTextBox.Text =
                            $"REISKOST VOLGENS BESTELLING NAAR {destinationTextBox.Text}\r\n\r\n" +
                            $"Totale Vluchtprijs:{totVluchtprijs:C}\r\nTotale verblijfsprijs: {totVerblijfprijs:C}\r\n" +
                            $"Totlae reisprijs:{totReisprijs:C}\r\nKorting: {korting:C}\r\n\r\n" +
                            $"Te betalen{teBetalen:C}";
            }            
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            baseFlightTextBox.Text = "0";
            destinationTextBox.Clear();
            destinationTextBox.Text = "0";
            flightClassTextBox.Text = "2";
            basePriceTextBox.Text = "0";
            numberOfDayTextBox.Text = "1";
            numberOfPersonsTextBox.Text = "1";
            reductionPercentageTextBox.Text = "0";
            resultTextBox.Clear();

            destinationTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}