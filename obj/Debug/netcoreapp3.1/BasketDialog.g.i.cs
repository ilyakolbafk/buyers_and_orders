#pragma checksum "..\..\..\BasketDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A4298AD17958F70DFE56EA25666EE1607404EAAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Buyers_and_orders;
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


namespace Buyers_and_orders {
    
    
    /// <summary>
    /// BasketDialog
    /// </summary>
    public partial class BasketDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\BasketDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckoutButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\BasketDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomerProductGrid;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\BasketDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu DataGridContextMenu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\BasketDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem RemoveProductFromBasket;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\BasketDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Cost;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Buyers_and_orders;component/basketdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BasketDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CheckoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\BasketDialog.xaml"
            this.CheckoutButton.Click += new System.Windows.RoutedEventHandler(this.CheckoutButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CustomerProductGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\BasketDialog.xaml"
            this.CustomerProductGrid.ContextMenuOpening += new System.Windows.Controls.ContextMenuEventHandler(this.CustomerProductGrid_OnContextMenuOpening);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGridContextMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 4:
            this.RemoveProductFromBasket = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\..\BasketDialog.xaml"
            this.RemoveProductFromBasket.Click += new System.Windows.RoutedEventHandler(this.RemoveProductFromBasket_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Cost = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

