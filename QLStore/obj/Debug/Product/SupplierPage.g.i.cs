﻿#pragma checksum "..\..\..\Product\SupplierPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F5C4C2BE4F3FD26AE05D5765D32791F3AA209DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QLStore.Product;
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


namespace QLStore.Product {
    
    
    /// <summary>
    /// ProductTypePage
    /// </summary>
    public partial class ProductTypePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listProductType;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbIdtype;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNameType;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDescrip;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditProduct;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon IconEdit;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon IconDelete;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\Product\SupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon IconAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/QLStore;component/product/supplierpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Product\SupplierPage.xaml"
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
            this.listProductType = ((System.Windows.Controls.ListView)(target));
            
            #line 57 "..\..\..\Product\SupplierPage.xaml"
            this.listProductType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListProductType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbIdtype = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbNameType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbDescrip = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnEditProduct = ((System.Windows.Controls.Button)(target));
            
            #line 207 "..\..\..\Product\SupplierPage.xaml"
            this.btnEditProduct.Click += new System.Windows.RoutedEventHandler(this.BtnEditProduct_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.IconEdit = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 215 "..\..\..\Product\SupplierPage.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.IconDelete = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 9:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 223 "..\..\..\Product\SupplierPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.IconAdd = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
