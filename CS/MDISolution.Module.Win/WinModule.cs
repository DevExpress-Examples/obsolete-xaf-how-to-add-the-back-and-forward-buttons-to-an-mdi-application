using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace MDISolution.Module.Win {
   [ToolboxItemFilter("Xaf.Platform.Win")]
   public sealed partial class MDISolutionWindowsFormsModule : ModuleBase {
      public MDISolutionWindowsFormsModule() {
         InitializeComponent();
      }
   }
}
