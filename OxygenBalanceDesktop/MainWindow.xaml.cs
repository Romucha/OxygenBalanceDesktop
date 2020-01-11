﻿using System;
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

        //fuel list
        private ObservableCollection<string> FuelList { get; set; }

        //oxidizer list
        private ObservableCollection<string> OxidizerList { get; set; }

        //third component list
        //ObservableCollection<string> ThirdList { get; set; }
        //was made a list to get proper sort methods
        List<string> ThirdList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FuelList = new ObservableCollection<string>(Explosives.ChemicalSubstances.Where(c => c.Balance < 0.0).Select(c => c.Name));
            Fuel.ItemsSource = FuelList;
            OxidizerList = new ObservableCollection<string>(Explosives.ChemicalSubstances.Where(c => c.Balance > 0.0).Select(c => c.Name));
            Oxidizer.ItemsSource = OxidizerList;
            //ThirdList = new ObservableCollection<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            ThirdList = new List<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            ThirdOne.ItemsSource = ThirdList;
        }

        //selection of 1st element
        private void FuelSelected(object sender, RoutedEventArgs e)
        {    
            //if there same selected items third component and list get nullified            
            if (Fuel.SelectedItem == ThirdOne.SelectedItem)
            {
                ThirdOne.SelectedIndex = -1;
                ThirdShow.Content = null;
                ThirdCur = null;
            }

            //check if FuelCur is not null
            if (FuelCur != null)
            {
                //then check if third list doesn't contain FuelCur
                if (!ThirdList.Contains(FuelCur.Name))
                {
                    //add to third list
                    ThirdList.Add(FuelCur.Name);                    
                }
            }

            //try to get substance from list and store it in variable
            Explosives.TryGetValue(Fuel.SelectedItem.ToString(), out ChemicalSubstance buf);
            FuelCur = buf;

            //show the chosen option
            FuelShow.Content = buf.ToString();

            //remove new FuelCur from third list
            ThirdList.Remove(FuelCur.Name);
            //sort third list to get proper view
            ThirdList.Sort();
        }

        //selection of 2nd element
        private void OxidizerSelected(object sender, RoutedEventArgs e)
        {
            //if there same selected items third component and list get nullified            
            if (Oxidizer.SelectedItem == ThirdOne.SelectedItem)
            {
                ThirdOne.SelectedIndex = -1;
                ThirdShow.Content = null;
                ThirdCur = null;
            }

            //check if OxidizerCur is not null
            if (OxidizerCur != null)
            {
                //then check if third list doesn't contain OxidizerCur
                if (!ThirdList.Contains(OxidizerCur.Name))
                {
                    //add to third list
                    ThirdList.Add(OxidizerCur.Name);
                }
            }

            //try to get substance from list and store it in variable
            Explosives.TryGetValue(Oxidizer.SelectedItem.ToString(), out ChemicalSubstance buf);
            OxidizerCur = buf;

            //show the chosen option
            OxidizerShow.Content = buf.ToString();

            //remove new OxidizerCur from third list
            ThirdList.Remove(OxidizerCur.Name);
            //sort third list to get proper view
            ThirdList.Sort();
        }

        //selection of 3rd element
        private void ThirdSelected(object sender, RoutedEventArgs e)
        {
            if (ThirdOne.SelectedItem != null)
            {
                Explosives.TryGetValue(ThirdOne.SelectedItem.ToString(), out ChemicalSubstance buf);
                ThirdCur = buf;
                //show chosen option
                ThirdShow.Content = ((buf.Balance > 0.0) ? "Phlegmatizer" : "Sensitizer") + ":\n" + buf.ToString();
            }
        }

        //slider changes are shown in textbox
        private void DoseChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ThirdDoseShow.Text= $"{ThirdSlider.Value:0.00}";
            ThirdDose = ThirdSlider.Value;
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
                ThirdDose = double.Parse(ThirdDoseShow.Text);
            }
        }

        //show results of calculation
        private void CalculateBalance(object sender, EventArgs e)
        {
            //balance of components
            var b1 = FuelCur.Balance;
            var b2 = OxidizerCur.Balance;
            var b3 = ThirdCur.Balance;
            //dose of third component
            var d = ThirdDose;

            //dose of first component
            var x = ((100 - d) * b2 + d * b3) / (b2 - b1);
            //dose of second component
            var y = 100 - d - x;
            MessageBox.Show($"{x:0.00}% of {FuelCur.Name} + {y:0.00}% of {OxidizerCur.Name} + {d:0.00}% of {ThirdCur.Name} = 0.00%");
        }        
    }
}
