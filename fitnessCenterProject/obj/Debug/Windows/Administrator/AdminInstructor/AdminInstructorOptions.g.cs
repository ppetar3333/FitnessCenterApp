﻿#pragma checksum "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9B49142865B70FAF7D9D3ACCEE61817565C873FB955123A45C1347E1B938E02A"
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
using fitnessCenterProject.Windows.Administrator.AdminInstructor;


namespace fitnessCenterProject.Windows.Administrator.AdminInstructor {
    
    
    /// <summary>
    /// AdminInstructorOptions
    /// </summary>
    public partial class AdminInstructorOptions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid instructorsInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/fitnessCenterProject;component/windows/administrator/admininstructor/admininstru" +
                    "ctoroptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
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
            
            #line 13 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.createInstrucors);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateInstrucors);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteInstrucors);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.close);
            
            #line default
            #line hidden
            return;
            case 5:
            this.instructorsInfo = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\..\..\Windows\Administrator\AdminInstructor\AdminInstructorOptions.xaml"
            this.instructorsInfo.AutoGeneratedColumns += new System.EventHandler(this.changeVisibilityInstructors);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

