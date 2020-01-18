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
        internal ChemicalSubstance FuelCur { get; private set; }

        //chosen oxidizer
        internal ChemicalSubstance OxidizerCur { get; private set; }

        //chosen third substance
        internal ChemicalSubstance ThirdCur { get; private set; }

        //dose of third substance
        internal double ThirdDose { get; private set; }

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
            ThirdList.Remove((string)Fuel.SelectedItem);
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
            if (Fuel.SelectedItem != null)
            {
                Explosives.TryGetValue(Fuel.SelectedItem.ToString(), out ChemicalSubstance buf);
                FuelCur = buf;

                //show the chosen option
                FuelShow.Content = buf.ToString();

                //remove new FuelCur from third list
                ThirdList.Remove(FuelCur.Name);
                //sort third list to get proper view
                ThirdList.Sort();
                ThirdOne.ItemsSource = new List<string>(ThirdList);
            }
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
            ThirdList.Remove((string)Oxidizer.SelectedItem);
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
            if (Oxidizer.SelectedItem != null)
            {
                Explosives.TryGetValue(Oxidizer.SelectedItem.ToString(), out ChemicalSubstance buf);
                OxidizerCur = buf;

                //show the chosen option
                OxidizerShow.Content = buf.ToString();

                //remove new OxidizerCur from third list
                ThirdList.Remove(OxidizerCur.Name);
                //sort third list to get proper view
                ThirdList.Sort();
                ThirdOne.ItemsSource = new List<string>(ThirdList);
            }
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
            if (FuelCur == null | OxidizerCur == null)
                MessageBox.Show("Choose components first!");
            else
            {
                //balance of components
                var b1 = FuelCur.Balance;
                var b2 = OxidizerCur.Balance;
                var b3 = (ThirdCur == null) ? 0.0 : ThirdCur.Balance;
                //dose of third component
                var d = (ThirdCur == null) ? 0.0 : ThirdDose;
                //dose of first component
                var x = ((100 - d) * b2 + d * b3) / (b2 - b1);
                //dose of second component
                var y = 100 - d - x;
                //MessageBox.Show($"{x:0.00}% of {FuelCur.Name} + {y:0.00}% of {OxidizerCur.Name}" + ((ThirdCur == null) ? "" : $" + {d:0.00}% of {ThirdCur.Name}") + " = 0.00%");
                //create new window of results
                ResultWindow resultWindow = new ResultWindow();
                resultWindow.Owner = this;

                //fill its labels
                //fuel
                resultWindow.FuelInfo.Content = "Fuel:\n" + FuelCur.ToString();
                resultWindow.FuelDose.Content = "Fuel dose:\n" + x.ToString();
                //oxidizer
                resultWindow.OxidizerInfo.Content = "Oxidizer:\n" + OxidizerCur.ToString();
                resultWindow.OxidizerDose.Content = "Oxidizer dose:\n" + y.ToString();
                //third component (optional)
                if (ThirdCur != null && ThirdDose != 0.0)
                {
                    var name = (ThirdCur.Balance > 0.0) ? "Phlegmatizer" : "Sensitizer";
                    resultWindow.ThirdInfo.Content = name + ":\n" + ThirdCur.ToString();
                    resultWindow.ThirdDose.Content = name + " dose:\n" + d.ToString();
                }

                //show it
                resultWindow.Show();
            }
        }        

        //reset all things
        private void ResetClick(object sender, EventArgs e)
        {
            //reset current values (maybe not necessary)
            FuelCur = null;
            OxidizerCur = null;
            ThirdCur = null;
            ThirdDose = 0.0;
            //reset all lists
            Fuel.SelectedIndex = -1;
            Oxidizer.SelectedIndex = -1;
            ThirdOne.SelectedIndex = -1;
            //reset dose and slider too
            ThirdDoseShow.Text = "0.00";
            ThirdSlider.Value = ThirdSlider.Minimum;
            //restore third list to default
            ThirdList = new List<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            ThirdOne.ItemsSource = ThirdList;
            //reset all labels
            FuelShow.Content = "";
            OxidizerShow.Content = "";
            ThirdShow.Content = "";
        }

        //close application
        private void CloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //show info about program
        private void AboutClick(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Owner = this;
            aboutWindow.Show();
        }

        //switch to English
        private void SwitchToEnglish(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        //switch to Russian
        private void SwitchToRussian(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
        }
    }
}
