﻿#pragma checksum "..\..\..\..\UserInterface\UserControls\supplier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A5354C6A1A0F7A269AFE47DE0CB8C602D72A0F1C2AB349748B7861798FE0563"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace UserInterface.UserControls {
    
    
    /// <summary>
    /// supplier
    /// </summary>
    public partial class supplier : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox item_quantity;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox item_id;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_product;
        
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
            System.Uri resourceLocater = new System.Uri("/Customer Management System;component/userinterface/usercontrols/supplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
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
            this.item_quantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 8 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
            this.item_quantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.item_quantity_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
            this.item_quantity.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.item_quantity_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.item_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 12 "..\..\..\..\UserInterface\UserControls\supplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label_product = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

