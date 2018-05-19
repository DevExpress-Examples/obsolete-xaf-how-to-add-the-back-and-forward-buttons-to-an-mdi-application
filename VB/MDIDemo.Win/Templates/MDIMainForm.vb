Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.XtraBars.Docking
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp

Namespace MDIDemo.Win
    Partial Public Class MDIMainForm
        Inherits XtraFormTemplateBase
        Private Const NavigationVisibilityAttributeName As String = "NavigationVisibility"
        Private Const NavigationWidthAttributeName As String = "NavigationWidth"
        Private Const NavigationDockAttributeName As String = "NavigationDock"
        Private Const FrameTemplatesMainFormLocalizationPath As String = "FrameTemplates\MainForm"
        #Region "IFrameTemplate Members"
        Public Overrides ReadOnly Property DefaultContainer() As IActionContainer
            Get
                Return cView
            End Get
        End Property
        #End Region
        Private navigationPaneVisibility As DockVisibility = DockVisibility.Visible
        Private Sub dockPanelNavigation_ClosingPanel(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking.DockPanelCancelEventArgs) Handles dockPanelNavigation.ClosingPanel
            barCheckItemNavigationPaneVisibility.Down = False
        End Sub
        Private Sub barCheckItemNavigationPaneVisibility_CheckedChanged(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barCheckItemNavigationPaneVisibility.CheckedChanged
            If barCheckItemNavigationPaneVisibility.Down Then
                dockPanelNavigation.Visibility = navigationPaneVisibility
            Else
                navigationPaneVisibility = dockPanelNavigation.Visibility
                dockPanelNavigation.Visibility = DockVisibility.Hidden
            End If
        End Sub
        Private Sub xtraTabbedMdiManager1_PageAdded(ByVal sender As Object, ByVal e As DevExpress.XtraTabbedMdi.MdiTabPageEventArgs) Handles xtraTabbedMdiManager1.PageAdded
            Dim view As DevExpress.ExpressApp.View = (CType(e.Page.MdiChild, XtraFormTemplateBase)).View
            If view IsNot Nothing Then
                e.Page.Image = ImageLoader.Instance.GetImageInfo(view.Info.GetAttributeValue(DevExpress.ExpressApp.NodeWrappers.VisualItemInfoNodeWrapper.ImageNameAttribute)).Image
            End If
        End Sub
        Private Sub xtraTabbedMdiManager1_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles xtraTabbedMdiManager1.SelectedPageChanged
            If xtraTabbedMdiManager1.SelectedPage IsNot Nothing Then
                Me.Text = xtraTabbedMdiManager1.SelectedPage.MdiChild.Text
            Else
                Me.Text = Application.ProductName
            End If
        End Sub
        Private Sub barButtonItemCloseAll_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barButtonItemCloseAll.ItemClick
            For Each child As Form In Me.MdiChildren
                child.Close()
                If child.Visible Then
                    Exit For
                End If
            Next child
        End Sub
        Private Sub barManager_Merge(ByVal sender As Object, ByVal e As DevExpress.XtraBars.BarManagerMergeEventArgs) Handles barManager.Merge
            MergeChildBars(e.ChildManager)
        End Sub

        Private Sub barManager_UnMerge(ByVal sender As Object, ByVal e As DevExpress.XtraBars.BarManagerMergeEventArgs) Handles barManager.UnMerge
            UnMergeChildBars(e.ChildManager)
        End Sub
        Protected Sub MergeChildBars(ByVal childBarManager As BarManager)
            For Each childBar As Bar In childBarManager.Bars
                If childBar Is childBarManager.MainMenu OrElse childBar Is childBarManager.StatusBar Then
                    Continue For
                End If
                childBar.Visible = False
            Next childBar
        End Sub
        Protected Sub UnMergeChildBars(ByVal childBarManager As BarManager)
        End Sub
        Public Overrides Sub ReloadSettings()
            MyBase.ReloadSettings()
            If TemplateInfo IsNot Nothing Then
                dockPanelNavigation.Width = TemplateInfo.GetAttributeIntValue(NavigationWidthAttributeName, dockPanelNavigation.Width)
                If (Not String.IsNullOrEmpty(TemplateInfo.GetAttributeValue(NavigationDockAttributeName))) Then
                    dockPanelNavigation.Dock = CType(System.Enum.Parse(GetType(DockingStyle), TemplateInfo.GetAttributeValue(NavigationDockAttributeName)), DockingStyle)
                End If
                If (Not String.IsNullOrEmpty(TemplateInfo.GetAttributeValue(NavigationVisibilityAttributeName))) Then
                    navigationPaneVisibility = CType(System.Enum.Parse(GetType(DockVisibility), TemplateInfo.GetAttributeValue(NavigationVisibilityAttributeName), True), DockVisibility)
                End If
                barCheckItemNavigationPaneVisibility.Down = (navigationPaneVisibility = DockVisibility.AutoHide OrElse navigationPaneVisibility = DockVisibility.Visible)
            End If
        End Sub
        Public Overrides Sub SaveSettings()
            MyBase.SaveSettings()
            If TemplateInfo IsNot Nothing Then
                TemplateInfo.SetAttribute(NavigationWidthAttributeName, dockPanelNavigation.Width)
                TemplateInfo.SetAttribute(NavigationDockAttributeName, dockPanelNavigation.Dock.ToString())
                TemplateInfo.SetAttribute(NavigationVisibilityAttributeName, dockPanelNavigation.Visibility.ToString())
            End If
        End Sub
        Public Sub New()
            InitializeComponent()

            MainMenuBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "MainMenu", "MainMenu")
            barSubItemFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "FileSubMenu", "FileSubMenu")
            cObjectsCreation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ObjectsCreation", "ObjectsCreation")
            cFile.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "File", "File")
            cPrint.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Print", "Print")
            cExport.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Export", "Export")
            cExit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Exit", "Exit")
            barSubItemEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "EditSubMenu","EditSubMenu")
            cRecordEdit.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "RecordEdit", "RecordEdit")
            barSubItemView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ViewSubMenu", "ViewSubMenu")
            barCheckItemNavigationPaneVisibility.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "NavigationBar", "NavigationBar")
            cRecordsNavigation.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "RecordsNavigation", "RecordsNavigation")
            cView.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "View", "View")
            barSubItemTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "ToolsSubMenu", "ToolsSubMenu")
            cTools.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Tools", "Tools")
            barSubItemWindow.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Window", "Window")
            barButtonItemCloseAll.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "CloseAllWindows", "Close &All Windows")
            barMdiChildrenListItem.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Window List", "Window List")
            cDiagnostic.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Diagnostic", "Diagnostic")
            cOptions.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Options", "Options")
            barSubItemHelp.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "HelpSubMenu", "HelpSubMenu")
            cAbout.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "About", "About")
            StandardToolBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "MainToolbar", "MainToolbar")
            cFiltersSearch.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Search", "Search")
            cFilters.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "Filters", "Filters")
            StatusBar.Text = CaptionHelper.GetLocalizedText(FrameTemplatesMainFormLocalizationPath, "StatusBar", "StatusBar")

            'this.templateInfo = templateInfo;
            Dim containers As New List(Of IActionContainer)()
            containers.AddRange(New IActionContainer() { cMDINavigation, cAbout, cTools, cFile, cObjectsCreation, cPrint, cExport, cExit, cRecordEdit, cRecordsNavigation, cFiltersSearch, cFilters, cView, cOptions, navigation, cDiagnostic})
            Initialize(barManager, containers, New IActionContainer() { cObjectsCreation, cRecordEdit, cView, cPrint, cExport }, Nothing, navigation)
        End Sub
    End Class
End Namespace
