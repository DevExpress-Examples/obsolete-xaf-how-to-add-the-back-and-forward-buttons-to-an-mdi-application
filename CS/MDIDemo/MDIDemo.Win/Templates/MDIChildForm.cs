using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp;

namespace MDIDemo.Win {
	public partial class MDIChildForm : XtraFormTemplateBase {
		private const string FrameTemplatesDetailViewForm = @"FrameTemplates\MainForm";
		protected override DictionaryNode GetFormStateNode() {
			if(View != null && TemplateInfo != null) {
				return TemplateInfo.GetChildNode(XtraFormTemplateBase.FormStateCustomizationNodeName, "ID", View.Id + "_FormState");
			}
			else {
				return base.GetFormStateNode();
			}
		}
		protected override DictionaryNode GetBarCustomizationNode() {
			if(View != null && TemplateInfo != null) {
				return TemplateInfo.GetChildNode(XtraFormTemplateBase.MenuBarsCustomizationNodeName, "ID", View.Id + "_BarsCustomization");
			}
			else {
				return base.GetBarCustomizationNode();
			}
		}
		public MDIChildForm() {
			InitializeComponent();

			MainMenuBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainMenuBar");
			barSubItemFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "FileSubMenu");
			cObjectsCreation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ObjectsCreation");
			cClose.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Close");
			cFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "File");
			cPrint.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Print");
			cExport.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Export");
			barSubItemEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "EditSubMenu");
			cRecordEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordEdit");
			barSubItemTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ToolsSubMenu");
			cTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Tools");
			cOptions.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Options");
			cDiagnostic.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Diagnostic");
			barSubItemView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ViewSubMenu");
			cRecordsNavigation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordsNavigation");
			cView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "View");
			barSubItemHelp.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "HelpSubMenu");
			cAbout.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "About");
			StandardToolBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainToolbar");
			cFiltersSearch.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Search");
			cFilters.Caption = "Filters";
			//CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Filters");
			StatusBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "StatusBar");

			List <IActionContainer> containers = new List<IActionContainer>();
			containers.AddRange(new IActionContainer[] {
											  cAbout, cTools, cFile, cObjectsCreation, cPrint, cExport, cRecordEdit, 
											  cRecordsNavigation, cFiltersSearch, cFilters,
											  cView, cDiagnostic, cOptions, cClose
										  });
			Initialize(barManager, containers,
				new IActionContainer[] { cObjectsCreation, cClose, cRecordEdit, cView, cPrint, cExport },
				viewSitePanel, null);
		}
		public override IActionContainer DefaultContainer {
			get { return null; }
		}
	}
}
