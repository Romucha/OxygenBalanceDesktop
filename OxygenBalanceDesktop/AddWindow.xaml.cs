using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PeriodicTable;

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

        public AddWindow()
        {
            InitializeComponent();
            //start position is when balance is active
            RadioBalance.IsChecked = true;
            EnterBalance.IsEnabled = true;
            RadioFormula.IsChecked = false;
            EnterFormula.IsEnabled = false;
            //default values for balance and formula
            BalanceCur = default;
            FormulaCur = default;
            //result button is disabled until we get out new element properly
            
        }

        //balance option is chosen
        private void BalanceClick(object sender, RoutedEventArgs e)
        {
            RadioFormula.IsChecked = false;
            EnterBalance.IsEnabled = true;
            EnterFormula.IsEnabled = false;
            FormulaCur = default;
            EnterFormula.Text = default;
        }

        //formula option is chosen
        private void FormulaClick(object sender, RoutedEventArgs e)
        {
            RadioBalance.IsChecked = false;
            EnterBalance.IsEnabled = false;
            EnterFormula.IsEnabled = true;
            BalanceCur = default;
            EnterBalance.Text = default;
        }

        //get name, no checks, name your explosives whatever you like
        private void NameEntered(object sender, TextCompositionEventArgs e)
        {
            NameCur = ((TextBox)sender).Text;
        }

        private void BalanceEntered(object sender, TextCompositionEventArgs e)
        {
            var cult = ((MainWindow)this.Owner).Culture;
            var dot = cult.NumberFormat.NumberDecimalSeparator;
            var textBox = (TextBox)sender;
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == dot) && (!textBox.Text.Contains(dot) && textBox.Text.Length != 0)))
            {
                e.Handled = true;
                if (textBox.Text == "")
                {
                    textBox.Text = string.Format(cult, "{0:F2}", 0);
                }
                BalanceCur = double.Parse(textBox.Text, cult) / 100;
                try
                {
                    ShowLabel.Content = (new ChemicalSubstance(NameCur, BalanceCur)).ToString();
                }
                catch
                {
                    ShowLabel.Content = "Can't create element " + NameCur;
                }
            }
        }

        private void FormulaEntered(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;
            FormulaCur = textBox.Text;
            try
            {
                ShowLabel.Content = (new ChemicalSubstance(NameCur, FormulaCur)).ToString();
            }
            catch
            {
                ShowLabel.Content = "Can't create element " + NameCur;
            }
        }
    }
}
