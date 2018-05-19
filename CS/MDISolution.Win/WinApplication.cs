using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace MDISolution.Win {
   public partial class MDISolutionWindowsFormsApplication : WinApplication {
      public MDISolutionWindowsFormsApplication() {
         InitializeComponent();
         DelayedViewItemsInitialization = true;
      }

      private void MDISolutionWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        
      }
   }
}
