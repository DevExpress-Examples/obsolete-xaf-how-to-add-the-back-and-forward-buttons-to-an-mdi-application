using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;

namespace MDIDemo.Win {
	class MDIStrategy : DevExpress.ExpressApp.Win.WinShowViewStrategyBase {
		private List<WinWindow> delayedToShow = new List<WinWindow>();
		protected override void ShowViewFromCommonView(ShowViewParameters parameters, ShowViewSource showViewSource) {
			WinWindow existWindow = FindWindowByView(parameters.CreatedView);
			if(existWindow != null) {
				existWindow.Show();
			}
			else {
				ShowViewInNewWindow(showViewSource.SourceFrame, parameters.CreatedView, TemplateContext.View, parameters.Controllers);
			}
		}
		protected override void ShowViewCore(ShowViewParameters parameters, ShowViewSource showViewSource) {
			if(parameters.TargetWindow == TargetWindow.Current && showViewSource.SourceFrame == MainWindow) {
				parameters.TargetWindow = TargetWindow.Default;
			}
			base.ShowViewCore(parameters, showViewSource);
		}
		protected override void ShowViewFromLookupView(ShowViewParameters parameters, ShowViewSource showViewSource) {
			ShowInModalWindow(parameters, showViewSource.SourceFrame);
		}
		protected override void BeforeShowWindow(WinWindow window) {
			if(window != MainWindow) {
				window.Form.MdiParent = MainWindow.Form;                
			}
		}
		public MDIStrategy(XafApplication application) : base(application) { }
		public override void ShowStartupWindow() {
			delayedToShow.Clear();
			try {
				base.ShowStartupWindow();
			}
			finally {
				System.Windows.Forms.Application.DoEvents();
				foreach(WinWindow child in delayedToShow) {
					ShowWindow(child);
				}
			}
		}
		protected override void ShowWindow(WinWindow window) {
			if(!window.IsMain && MainWindow == null) {
				delayedToShow.Add(window);
			}
			else {
				base.ShowWindow(window);
			}
		}
	}
}
