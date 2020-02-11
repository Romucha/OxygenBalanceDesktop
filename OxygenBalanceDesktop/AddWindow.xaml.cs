﻿using System;
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
using System.Linq;

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
            BalanceCur = 0.0;
            FormulaCur = null;
            //result button is disabled until we get out new element properly
            AddButton.IsEnabled = false;
            
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
            //rework to make it read negative values
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == dot) && (!textBox.Text.Contains(dot) && textBox.Text.Length != 0)))
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
                    ShowLabel.Content = "Can't create element \"" + NameCur + "\"";
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
                ShowLabel.Content = "Can't create element \"" + NameCur + "\"";
                AddButton.IsEnabled = false;
            }
        }

        //add new element into list
        //works weird for some reason
        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (Explosives.ChemicalSubstances.Select(c => c.Name).Contains(NameCur))
            {
                MessageBox.Show("Element \"" + NameCur + "\" already exists");
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
                    Explosives.AddElementFormula(((MainWindow)this.Owner).Culture, NameCur, FormulaCur);
                }                
                MessageBox.Show("Element \"" + NameCur + "\" has been successfully added");
                Explosives.CreateList(((MainWindow)this.Owner).Culture);
                ((MainWindow)this.Owner).InitializeLists();
            }
        }

        private void AddWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Explosives.CreateList(((MainWindow)this.Owner).Culture);
            ((MainWindow)this.Owner).InitializeLists();
        }
    }
}
