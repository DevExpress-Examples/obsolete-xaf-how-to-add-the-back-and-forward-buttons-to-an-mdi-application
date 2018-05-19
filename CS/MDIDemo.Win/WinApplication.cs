using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;

namespace MDIDemo.Win
{
    public partial class MDIDemoWindowsFormsApplication : WinApplication
    {
        public MDIDemoWindowsFormsApplication()
        {
            InitializeComponent();
        }

        private void MDIDemoWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
        }
    }
}
