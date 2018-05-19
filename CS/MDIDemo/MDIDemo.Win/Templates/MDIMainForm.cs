using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.ExpressApp.Templates;
using DevExpress.XtraBars.Docking;
using DevExpress.ExpressApp.Utils;
using DevExpress.XtraBars;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp;

namespace MDIDemo.Win {
	public partial class MDIMainForm : XtraFormTemplateBase {
		private const string NavigationVisibilityAttributeName = "NavigationVisibility";
		private const string NavigationWidthAttributeName = "NavigationWidth";
		private const string NavigationDockAttributeName = "NavigationDock";
		private const string FrameTemplatesMainFormLocalizationPath = @"FrameTemplates\MainForm";
		protected override void SetFormIcon(DevExpress.ExpressApp.View view) { }
		protected override void SetViewCore(DevExpress.ExpressApp.View view) {
			//do nothing. We don't show any views
		}
		#region IFrameTemplate Members
		public override IActionContainer DefaultContainer {
			get { return cView; }
		}
		#endregion
		private DockVisibility navigationPaneVisibility = DockVisibility.Visible;
		private void dockPanelNavigation_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e) {
			barCheckItemNavigationPaneVisibility.Down = false;
		}
		private void barCheckItemNavigationPaneVisibility_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			if(barCheckItemNavigationPaneVisibility.Down) {
				dockPanelNavigation.Visibility = navigationPaneVisibility;
			}
			else {
				navigationPaneVisibility = dockPanelNavigation.Visibility;
				dockPanelNavigation.Visibility = DockVisibility.Hidden;
			}
		}
		private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e) {
			DevExpress.ExpressApp.View view = ((XtraFormTemplateBase)e.Page.MdiChild).View;
			if(view != null) {
				e.Page.Image = ImageLoader.Instance.GetImageInfo(view.Info.GetAttributeValue(DevExpress.ExpressApp.NodeWrappers.VisualItemInfoNodeWrapper.ImageNameAttribute)).Image;
			}
		}
		private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, System.EventArgs e) {
			if(xtraTabbedMdiManager1.SelectedPage != null) {
				this.Text = xtraTabbedMdiManager1.SelectedPage.MdiChild.Text;
			}
			else {
				this.Text = Application.ProductName;
			}
		}
		private void barButtonItemCloseAll_ItemClick(object sender, ItemClickEventArgs e) {
			foreach(Form child in this.MdiChildren) {
				child.Close();
				if(child.Visible) {
					break;
				}
			}
		}
		private void barManager_Merge(object sender, DevExpress.XtraBars.BarManagerMergeEventArgs e) {
			MergeChildBars(e.ChildManager);
		}

		private void barManager_UnMerge(object sender, DevExpress.XtraBars.BarManagerMergeEventArgs e) {
			UnMergeChildBars(e.ChildManager);
		}
		protected void MergeChildBars(BarManager childBarManager) {
			foreach(Bar childBar in childBarManager.Bars) {
				if(childBar == childBarManager.MainMenu || childBar == childBarManager.StatusBar) {
					continue;
				}
				childBar.Visible = false;
			}
		}
		protected void UnMergeChildBars(BarManager childBarManager) {
		}
		public override void ReloadSettings() {
			base.ReloadSettings();
			if(TemplateInfo != null) {
				dockPanelNavigation.Width = TemplateInfo.GetAttributeIntValue(NavigationWidthAttributeName, dockPanelNavigation.Width);
				if(!string.IsNullOrEmpty(TemplateInfo.GetAttributeValue(NavigationDockAttributeName))) {
					dockPanelNavigation.Dock = (DockingStyle)Enum.Parse(typeof(DockingStyle), TemplateInfo.GetAttributeValue(NavigationDockAttributeName));
				}
				if(!string.IsNullOrEmpty(TemplateInfo.GetAttributeValue(NavigationVisibilityAttributeName))) {
					navigationPaneVisibility = (DockVisibility)Enum.Parse(typeof(DockVisibility), TemplateInfo.GetAttributeValue(NavigationVisibilityAttributeName), true);
				}
				barCheckItemNavigationPaneVisibility.Down = (navigationPaneVisibility == DockVisibility.AutoHide || navigationPaneVisibility == DockVisibility.Visible);
			}
		}
		public override void SaveSettings() {
			base.SaveSettings();
			if(TemplateInfo != null) {
				TemplateInfo.SetAttribute(NavigationWidthAttributeName, dockPanelNavigation.Width);
				TemplateInfo.SetAttribute(NavigationDockAttributeName, dockPanelNavigation.Dock.ToString());
				TemplateInfo.SetAttribute(NavigationVisibilityAttributeName, dockPanelNavigation.Visibility.ToString());
			}
		}
		public MDIMainForm() {
			InitializeComponent();

			MainMenuBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "MainMenu");
			barSubItemFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "FileSubMenu");
			cObjectsCreation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ObjectsCreation");
			cFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "File");
			cPrint.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Print");
			cExport.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Export");
			cExit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Exit");
			barSubItemEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "EditSubMenu");
			cRecordEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "RecordEdit");
			barSubItemView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ViewSubMenu");
			barCheckItemNavigationPaneVisibility.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "NavigationBar");
			cRecordsNavigation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "RecordsNavigation");
			cView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "View");
			barSubItemTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ToolsSubMenu");
			cTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Tools");
			cDiagnostic.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Diagnostic");
			cOptions.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Options");
			barSubItemHelp.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "HelpSubMenu");
			cAbout.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "About");
			StandardToolBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "MainToolbar");
			cFiltersSearch.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Search");
			cFilters.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Filters");
			StatusBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "StatusBar");

			//this.templateInfo = templateInfo;
			List<IActionContainer> containers = new List<IActionContainer>();
			containers.AddRange(new IActionContainer[] {
				cMDINavigation, cAbout, cTools, cFile, cObjectsCreation, cPrint, cExport, cExit, cRecordEdit, 
				cRecordsNavigation, cFiltersSearch, cFilters,
				cView, cOptions, navigation, cDiagnostic});
			Initialize(barManager, containers,
				new IActionContainer[] { cObjectsCreation, cRecordEdit, cView, cPrint, cExport },
				null, navigation);
		}
	}
}
