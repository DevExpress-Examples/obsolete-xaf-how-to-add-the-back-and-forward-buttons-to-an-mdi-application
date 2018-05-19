Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils

Imports DevExpress.ExpressApp.Win.Templates
Partial Public Class MDIChildForm
   Inherits XtraFormTemplateBase
   Private Const FrameTemplatesDetailViewForm As String = "FrameTemplates\DetailViewForm"
   Protected Overrides Function GetFormStateNode() As DictionaryNode
      If Not View Is Nothing AndAlso Not TemplateInfo Is Nothing Then
         Return TemplateInfo.GetChildNode("FormState", "ID", View.Id)
      End If
      Return MyBase.GetFormStateNode()
   End Function
   <Obsolete("Use the DetailViewForm() constructor")> _
   Public Sub New(ByVal application As XafApplication, ByVal templateInfo As DictionaryNode)
      Me.New()
   End Sub
   <Obsolete("Use the DetailViewForm() constructor")> _
   Public Sub New(ByVal application As XafApplication)
      Me.New()
   End Sub
   Public Sub New()
      InitializeComponent()

      MainMenuBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainMenuBar")
      barSubItemFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "FileSubMenu")
      cObjectsCreation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ObjectsCreation")
      cClose.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Close")
      cFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "File")
      cPrint.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Print")
      cExport.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Export")
      barSubItemEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "EditSubMenu")
      cRecordEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordEdit")
      barSubItemTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ToolsSubMenu")
      cTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Tools")
      cOptions.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Options")
      cDiagnostic.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Diagnostic")
      barSubItemView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ViewSubMenu")
      cRecordsNavigation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordsNavigation")
      cView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "View")
      barSubItemHelp.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "HelpSubMenu")
      cAbout.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "About")
      StandardToolBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainToolbar")
      cFiltersSearch.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Search")
      StatusBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "StatusBar")
      cFilters.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Filters", "Filters")

      Dim containers As List(Of IActionContainer) = New List(Of IActionContainer)()
      containers.AddRange(New IActionContainer() {cAbout, cTools, cFilters, cFile, cObjectsCreation, cPrint, cExport, cRecordEdit, cRecordsNavigation, cFiltersSearch, cView, cDiagnostic, cOptions, cClose})
      Initialize(mainBarManager, containers, New IActionContainer() {cObjectsCreation, cClose, cRecordEdit, cView, cPrint, cExport}, viewSitePanel, Nothing)
   End Sub
   Public Overrides ReadOnly Property DefaultContainer() As IActionContainer
      ' Bug AB13554
      Get
         Return cView
      End Get
   End Property
End Class
