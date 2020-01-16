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
using System.IO;

namespace OxygenBalanceDesktop
{
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {   
            InitializeComponent();
        }

        //close the result window
        private void ResultClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResultSave(object sender, EventArgs e)
        {
            //create save file dialog
            Microsoft.Win32.SaveFileDialog saveDiag = new Microsoft.Win32.SaveFileDialog();

            //default file name
            saveDiag.FileName = "Explosive";
            //default file extension
            saveDiag.DefaultExt = "expl";
            //filter
            saveDiag.Filter = "Calculated explosives (.expl)|*.expl";
            if(saveDiag.ShowDialog() == true)
            {
                //output
                string output = "";
                //add info about fuel and its dose
                output += FuelInfo.Content + "\n";
                output += FuelDose.Content + "\n\n";
                //add info about oxidizer and its dose
                output += OxidizerInfo.Content + "\n";
                output += OxidizerDose.Content + "\n";
                //add info about third component if it exists
                if (ThirdInfo.Content != "")
                {
                    output += ThirdInfo.Content + "\n";
                    output += ThirdDose.Content + "\n";
                }
                File.WriteAllText(saveDiag.FileName, output);
            }
        }
    }
}
