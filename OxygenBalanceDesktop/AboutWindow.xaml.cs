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

namespace OxygenBalanceDesktop
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            //this.Resources = this.Owner.Resources;
        }

        //close about window
        private void AboutOK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
