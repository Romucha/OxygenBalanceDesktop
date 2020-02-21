using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PeriodicTable;
using System.Linq;
using System.IO;

namespace OxygenBalanceDesktop
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        //double value to store balance
        private double BalanceCur;

        //string value to store formula
        private string FormulaCur;

        //string value to store name
        private string NameCur;

        private bool IsAddRequired;

        public AddWindow()
        {
            InitializeComponent();
            //start position is when balance is active
            RadioBalance.IsChecked = true;
            EnterBalance.IsEnabled = true;
            RadioFormula.IsChecked = false;
            EnterFormula.IsEnabled = false;
            //default values for balance and formula
            BalanceCur = 0.0;
            FormulaCur = null;
            //result button is disabled until we get out new element properly
            AddButton.IsEnabled = false;
            IsAddRequired = false;
            
        }

        //balance option is chosen
        private void BalanceClick(object sender, RoutedEventArgs e)
        {

            //if we switch we reset everything
            RadioFormula.IsChecked = false;
            EnterBalance.IsEnabled = true;
            EnterFormula.IsEnabled = false;
            FormulaCur = null;
            EnterFormula.Text = null;
            AddButton.IsEnabled = false;
            ShowLabel.Content = null;
        }

        //formula option is chosen
        private void FormulaClick(object sender, RoutedEventArgs e)
        {

            //if we switch we reset everything
            RadioBalance.IsChecked = false;
            EnterBalance.IsEnabled = false;
            EnterFormula.IsEnabled = true;
            BalanceCur = 0.0;
            EnterBalance.Text = null;
            AddButton.IsEnabled = false;
            ShowLabel.Content = null;
        }

        //get name, no checks, name your explosives whatever you like
        private void NameEntered(object sender, TextCompositionEventArgs e)
        {
            NameCur = ((TextBox)sender).Text;
            if (NameCur == null)
                AddButton.IsEnabled = false;
            if (BalanceCur != 0F || FormulaCur != null)
            {
                AddButton.IsEnabled = true;
            }
        }

        //get balance and show new element in label
        private void BalanceEntered(object sender, TextCompositionEventArgs e)
        {
            var cult = ((MainWindow)this.Owner).Culture;
            var dot = cult.NumberFormat.NumberDecimalSeparator;
            var textBox = (TextBox)sender;
            var numberPattern = string.Format(@"(^\-?)\d+");
            if (
                !(e.Text[0] == '-' && textBox.Text.Length == 0) &&//negative
                !(char.IsDigit(e.Text, 0) && textBox.Text.Length >= 0) &&//integer
                !(e.Text == dot && !textBox.Text.Contains(dot) && Regex.IsMatch(textBox.Text, numberPattern))//float
                )
            {
                e.Handled = true;
                if (textBox.Text == "")
                {
                    textBox.Text = string.Format(cult, "{0:F2}", 0);
                }
                BalanceCur = double.Parse(textBox.Text, cult);
                try
                {
                    ShowLabel.Content = (new ChemicalSubstance(NameCur, BalanceCur)).ToString();
                    if (NameCur != null)
                    {
                        AddButton.IsEnabled = true;
                    }
                }
                catch
                {
                    ShowLabel.Content = Resources["FailedToCreateElement"] + "\"" + NameCur + "\"";
                    AddButton.IsEnabled = false;
                }
            }

        }

        //get formula and show new element in label
        private void FormulaEntered(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;
            FormulaCur = textBox.Text;
            try
            {
                ShowLabel.Content = (new ChemicalSubstance(NameCur, FormulaCur)).ToString();
                if (NameCur != null)
                {
                    AddButton.IsEnabled = true;
                }
            }
            catch
            {
                ShowLabel.Content = Resources["FailedToCreateElement"] + "\"" + NameCur + "\".";
                AddButton.IsEnabled = false;
            }
        }

        //add new element into list
        //works weird for some reason
        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (Explosives.ChemicalSubstances.Select(c => c.Name).Contains(NameCur))
            {
                MessageBox.Show(Resources["RemoveMessageStart"] + NameCur + "\" " + Resources["AlreadyExists"]);
                return;
            }
            else
            {
                if ((bool)RadioBalance.IsChecked)
                {
                    Explosives.AddElementBalance(((MainWindow)this.Owner).Culture, NameCur, BalanceCur);
                }
                else
                {
                    Explosives.AddElementFormula(NameCur, FormulaCur);
                }
                ((MainWindow)this.Owner).InitializeLists();
                MessageBox.Show(Resources["RemoveMessageStart"] + NameCur + "\" " + Resources["SuccessfulyAdded"]);
                IsAddRequired = true;
            }
        }
    }
}
