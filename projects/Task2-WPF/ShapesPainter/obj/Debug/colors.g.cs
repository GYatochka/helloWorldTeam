﻿#pragma checksum "..\..\colors.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9400627451331F1A662EB2EB91B238881999B344"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ShapesPainter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ShapesPainter {
    
    
    /// <summary>
    /// colors
    /// </summary>
    public partial class colors : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse ellipse;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle selected_rec;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selected_color_label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button palette_button;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\colors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button select;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ShapesPainter;component/colors.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\colors.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.image = ((System.Windows.Controls.Image)(target));
            
            #line 16 "..\..\colors.xaml"
            this.image.MouseMove += new System.Windows.Input.MouseEventHandler(this.MouseMoveEvent);
            
            #line default
            #line hidden
            
            #line 16 "..\..\colors.xaml"
            this.image.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseDowsnEvent);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ellipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.selected_rec = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.selected_color_label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.palette_button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\colors.xaml"
            this.palette_button.Click += new System.Windows.RoutedEventHandler(this.palette_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.select = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\colors.xaml"
            this.select.Click += new System.Windows.RoutedEventHandler(this.select_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

