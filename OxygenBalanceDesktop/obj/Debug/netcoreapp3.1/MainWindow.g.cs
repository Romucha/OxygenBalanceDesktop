﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7CDD6CBFF37D4F29048B954132F3D39B254C38AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OxygenBalanceDesktop;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OxygenBalanceDesktop {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxygenBalanceDesktop.MainWindow BaseWindow;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu MainMenu;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FuelShow;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OxidizerShow;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ThirdShow;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThirdDoseShow;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CalculateButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Fuel;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Oxidizer;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ThirdOne;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider ThirdSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OxygenBalanceDesktop;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BaseWindow = ((OxygenBalanceDesktop.MainWindow)(target));
            return;
            case 2:
            this.MainMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            
            #line 29 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 30 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AboutClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 32 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SwitchToEnglish);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 33 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SwitchToRussian);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.FuelShow = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.OxidizerShow = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ThirdShow = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ThirdDoseShow = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\MainWindow.xaml"
            this.ThirdDoseShow.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ThirdTyped);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CalculateButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\MainWindow.xaml"
            this.CalculateButton.Click += new System.Windows.RoutedEventHandler(this.CalculateBalance);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Fuel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\MainWindow.xaml"
            this.Fuel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FuelSelected);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Oxidizer = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\..\MainWindow.xaml"
            this.Oxidizer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OxidizerSelected);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ThirdOne = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\MainWindow.xaml"
            this.ThirdOne.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ThirdSelected);
            
            #line default
            #line hidden
            return;
            case 16:
            this.ThirdSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 49 "..\..\..\MainWindow.xaml"
            this.ThirdSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.DoseChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

