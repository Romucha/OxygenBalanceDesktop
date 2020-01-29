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
using System.Globalization;

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
        //was made a list to get proper sort method
        List<string> ThirdList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeLists();
            RussianSwitch.Click += ResetClick;
            RussianSwitch.Click += SwitchCulture;
            EnglishSwitch.Click += ResetClick;
            EnglishSwitch.Click += SwitchCulture;


            //setting default language
            var path = "Resources/LocalDictionary." + System.Threading.Thread.CurrentThread.CurrentUICulture.Name + ".xaml";
            this.Resources = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative) };
        }

        //selection of 1st and 2nd element
        private void ElementSelected(object sender, RoutedEventArgs e)
        {
            //our current combobox
            var chosenBox = (ComboBox)sender;
            //item we selected
            if (chosenBox.SelectedItem == null)
                return;
            string chosenElement = chosenBox.SelectedItem.ToString();
            //if there same selected items third component and list get nullified            
            if (ThirdOne.SelectedItem != null && chosenElement == ThirdOne.SelectedItem.ToString())
            {
                ThirdOne.SelectedIndex = -1;
                ThirdShow.Content = null;
                ThirdCur = null;

            }
            ThirdList.Remove(chosenElement);
            //buffer that can be either FuelCur or OxidizerCur
            var bufCur = (chosenBox == Fuel) ? FuelCur : OxidizerCur;
            //check if buffer is not null
            if (bufCur != null)
            {
                //then check if third list doesn't contain FuelCur
                if (!ThirdList.Contains(bufCur.Name))
                {
                    //add to third list
                    ThirdList.Add(bufCur.Name);
                }
            }

            //try to get substance from list and store it in variable
            if (chosenElement != null)
            {
                Explosives.TryGetValue(chosenElement, out ChemicalSubstance buf);
                bufCur = buf;

                //show the chosen option
                ((chosenBox == Fuel) ? FuelShow : OxidizerShow).Content = buf.ToString();

                //remove new FuelCur from third list
                ThirdList.Remove(bufCur.Name);
                //sort third list to get proper view
                ThirdList.Sort();
                ThirdOne.ItemsSource = new List<string>(ThirdList);
                //set new value of FuelCur or OxidizerCur
                if (chosenBox == Fuel)
                    FuelCur = bufCur;
                else
                    OxidizerCur = bufCur;
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
                ThirdShow.Content = ((buf.Balance > 0.0) ? Resources["Phlegmatizer"] : Resources["Sensitizer"]) + "\n" + buf.ToString();
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
                MessageBox.Show(Resources["ChooseComponentFirst"].ToString());
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
                //create new window of results
                ResultWindow resultWindow = new ResultWindow();
                resultWindow.Owner = this;
                resultWindow.Resources = this.Resources;

                //fill its labels
                //fuel
                resultWindow.FuelInfo.Content = Resources["FuelInfo"] + "\n" + FuelCur.ToString();
                resultWindow.FuelDose.Content = Resources["FuelDose"] + "\n" + string.Format($"{x:0.0000}") + "%";
                //oxidizer
                resultWindow.OxidizerInfo.Content = Resources["OxidizerInfo"] + "\n" + OxidizerCur.ToString();
                resultWindow.OxidizerDose.Content = Resources["OxidizerDose"] + "\n" + string.Format($"{y:0.0000}") + "%";
                //third component (optional)
                if (ThirdCur != null && ThirdDose != 0.0)
                {
                    resultWindow.ThirdInfo.Content = ((ThirdCur.Balance > 0.0) ? Resources["Phlegmatizer"] : Resources["Sensitizer"]) + "\n" + ThirdCur.ToString();
                    resultWindow.ThirdDose.Content = ((ThirdCur.Balance > 0.0) ? Resources["PhlegmatizerDose"] : Resources["SensitizerDose"]) + "\n" + string.Format($"{d:0.0000}") + "%";
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
            aboutWindow.Resources = this.Resources;
            aboutWindow.Show();
        }

        //switch cultures
        private void SwitchCulture(object sender, EventArgs e)
        {
            //change language if new one is different from previous
            var menu = (MenuItem)sender;
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name != menu.Tag.ToString())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(menu.Tag.ToString());
                string path = "Resources/LocalDictionary" + (menu.Tag.ToString() == "ru-RU" ? ".ru-RU" : ".en-US") + ".xaml";
                this.Resources = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative) };
                //make new list of explosives
                Explosives.CreateList(System.Threading.Thread.CurrentThread.CurrentUICulture);
                //recreate all comboboxes
                InitializeLists();
            }            
        }

        //initialize all three comboboxes of explosives at the beginning and when language is switched
        public void InitializeLists()
        {
            FuelList = new ObservableCollection<string>(Explosives.ChemicalSubstances.Where(c => c.Balance < 0.0).Select(c => c.Name));
            Fuel.ItemsSource = FuelList;
            OxidizerList = new ObservableCollection<string>(Explosives.ChemicalSubstances.Where(c => c.Balance > 0.0).Select(c => c.Name));
            Oxidizer.ItemsSource = OxidizerList;
            ThirdList = new List<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            ThirdOne.ItemsSource = ThirdList;
        }
    }
}
