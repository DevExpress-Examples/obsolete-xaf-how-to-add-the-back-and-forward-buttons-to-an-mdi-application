Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp

Namespace MDIDemo.Win
    Partial Public Class MDIChildForm
        Inherits XtraFormTemplateBase
        Private Const FrameTemplatesDetailViewForm As String = "FrameTemplates\DetailViewForm"
        Protected Overrides Function GetFormStateNode() As DictionaryNode
            If View IsNot Nothing AndAlso TemplateInfo IsNot Nothing Then
                Return TemplateInfo.GetChildNode(XtraFormTemplateBase.FormStateCustomizationNodeName, "ID", View.Id & "_FormState")
            Else
                Return MyBase.GetFormStateNode()
            End If
        End Function
        Protected Overrides Function GetBarCustomizationNode() As DictionaryNode
            If View IsNot Nothing AndAlso TemplateInfo IsNot Nothing Then
                Return TemplateInfo.GetChildNode(XtraFormTemplateBase.MenuBarsCustomizationNodeName, "ID", View.Id & "_BarsCustomization")
            Else
                Return MyBase.GetBarCustomizationNode()
            End If
        End Function
        Public Sub New()
            InitializeComponent()

            MainMenuBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainMenu", "MainMenu")
            barSubItemFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "FileSubMenu", "FileSubMenu")
            cObjectsCreation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ObjectsCreation", "ObjectsCreation")
            cFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "File", "File")
            cPrint.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Print", "Print")
            cExport.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Export", "Export")
            barSubItemEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "EditSubMenu", "EditSubMenu")
            cRecordEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordEdit", "RecordEdit")
            barSubItemView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ViewSubMenu", "ViewSubMenu")
            cRecordsNavigation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "RecordsNavigation", "RecordsNavigation")
            cView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "View", "View")
            barSubItemTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "ToolsSubMenu", "Tools")
            cTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Tools", "Tools")
            cDiagnostic.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Diagnostic", "Diagnostic")
            cOptions.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Options", "Options")
            barSubItemHelp.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "HelpSubMenu", "HelpSubMenu")
            cAbout.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "About", "About")
            StandardToolBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "MainToolbar", "MainToolbar")
            cFiltersSearch.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Search", "Search")
            cFilters.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Filters", "Filters")
            Dim containers As New List(Of IActionContainer)()
            containers.AddRange(New IActionContainer() { cAbout, cTools, cFile, cObjectsCreation, cPrint, cExport, cRecordEdit, cRecordsNavigation, cFiltersSearch, cFilters, cView, cDiagnostic, cOptions, cClose })
            Initialize(barManager, containers, New IActionContainer() { cObjectsCreation, cClose, cRecordEdit, cView, cPrint, cExport }, viewSitePanel, Nothing)
        End Sub
        Public Overrides ReadOnly Property DefaultContainer() As IActionContainer
            Get
                Return Nothing
            End Get
        End Property
    End Class
End Namespace
