using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PeriodicTable;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OxygenBalanceDesktop
{
    /// <summary>
    /// Логика взаимодействия для RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        //name of item that needs to be removed
        private string RemoveElementName;
        public RemoveWindow()
        {
            InitializeComponent();
            //any element can be removed so we make collection of all elements
            var RemoveCollection = new ObservableCollection<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            RemoveList.ItemsSource = RemoveCollection;
            //while no element is chosen remove button remains disabled
            RemoveButton.IsEnabled = false;
        }

        //activate button, show selected item
        private void ElementSelected(object sender, SelectionChangedEventArgs e)
        {
            RemoveButton.IsEnabled = true;
            if (RemoveList.SelectedItem == null)
                return;
            RemoveElementName = RemoveList.SelectedItem.ToString();
            Explosives.TryGetValue(RemoveElementName, out ChemicalSubstance removedElement);
            RemoveLabel.Content = removedElement.ToString();
        }

        //remove element from file and lists
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            Explosives.RemoveElement(RemoveElementName);
            RemoveList.SelectedItem = null;
            RemoveList.ItemsSource = new ObservableCollection<string>(Explosives.ChemicalSubstances.Select(c => c.Name));
            RemoveLabel.Content = null;
            Explosives.CreateList(((MainWindow)this.Owner).Culture);
            ((MainWindow)this.Owner).InitializeLists();
            MessageBox.Show(Resources["RemoveMessageStart"] + RemoveElementName + Resources["RemoveMessageEnd"]);
        }
    }
}
