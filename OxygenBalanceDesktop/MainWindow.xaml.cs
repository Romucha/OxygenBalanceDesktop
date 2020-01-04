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
using PeriodicTable;
using System.IO;
using System.Collections.ObjectModel;

namespace OxygenBalanceDesktop
{    
    public partial class MainWindow : Window
    {
        //chosen fuel
        private ChemicalSubstance FuelCur { get; set; }

        //chosen oxidizer
        private ChemicalSubstance OxidizerCur { get; set; }

        //chosen third substance
        private ChemicalSubstance ThirdCur { get; set; }

        //dose of third substance
        private double ThirdDose { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var FuelList = new ObservableCollection<ChemicalSubstance>(Explosives.ChemicalSubstances.Where(c => c.Balance < 0.0));
            Fuel.ItemsSource = FuelList.Select(c => c.Name);
            var OxidizerList = new ObservableCollection<ChemicalSubstance>(Explosives.ChemicalSubstances.Where(c => c.Balance > 0.0));
            Oxidizer.ItemsSource = OxidizerList.Select(c => c.Name);
            var ThirdList = new ObservableCollection<ChemicalSubstance>(Explosives.ChemicalSubstances.Where(c => c != FuelCur | c != OxidizerCur));
            ThirdOne.ItemsSource = ThirdList.Select(c => c.Name);
        }

        //selection of 1st element
        private void FuelSelected(object sender, RoutedEventArgs e)
        {            
            //try to get substance from list and store it in variable
            Explosives.TryGetValue(Fuel.SelectedItem.ToString(), out ChemicalSubstance buf);
            FuelCur = buf;

            //show the chosen option
            FuelShow.Content = buf.ToString();

        }

        //selection of 2nd element
        private void OxidizerSelected(object sender, RoutedEventArgs e)
        {            
            //try to get substance from list and store it in variable
            Explosives.TryGetValue(Oxidizer.SelectedItem.ToString(), out ChemicalSubstance buf);
            OxidizerCur = buf;

            //show the chosen option
            OxidizerShow.Content = buf.ToString();
        }

        //selection of 3rd element
        private void ThirdSelected(object sender, RoutedEventArgs e)
        {
            Explosives.TryGetValue(ThirdOne.SelectedItem.ToString(), out ChemicalSubstance buf);
            ThirdShow.Content = ((buf.Balance > 0.0) ? "Phlegmatizer" : "Sensitizer") + ":\n" + buf.ToString();

            ThirdCur = buf;
        }

        //WIP
        private void ThirdOpened(object sender, EventArgs e)
        {
            //clear all in third component list
            ThirdOne.ItemsSource = null;
            //add all explosives but the ones that were selected in first two lists
            ThirdOne.ItemsSource = new ObservableCollection<ChemicalSubstance>(Explosives.ChemicalSubstances.Where(c => c != FuelCur | c != OxidizerCur)).Select(c => c.Name);
        }

        //slider changes are shown in textbox
        private void DoseChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ThirdDoseShow.Text= $"{ThirdSlider.Value:0.00}";
        }

        //make only digits and "." inputable
        private void ThirdTyped(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!ThirdDoseShow.Text.Contains(".") && ThirdDoseShow.Text.Length != 0)))
            {
                e.Handled = true;
                //check if value is between 0 and 100
                if (double.Parse(ThirdDoseShow.Text) > 100.00)
                {
                    ThirdDoseShow.Text = "100.00";
                }

                if (double.Parse(ThirdDoseShow.Text) < 0.0)
                {
                    ThirdDoseShow.Text = "0.00";
                }
                //make slider correlate with textbox
                ThirdSlider.Value = double.Parse(ThirdDoseShow.Text);
            }
        }
    }
}
