Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Utils

Partial Public Class MDIChildForm
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (Not components Is Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.mainBarManager = New DevExpress.XtraBars.BarManager(Me.components)
      Me.MainMenuBar = New DevExpress.XtraBars.Bar
      Me.barSubItemFile = New DevExpress.ExpressApp.Win.Templates.MainMenuItem
      Me.cObjectsCreation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.cFile = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.cClose = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.cPrint = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.cExport = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.barSubItemEdit = New DevExpress.ExpressApp.Win.Templates.MainMenuItem
      Me.cRecordEdit = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.barSubItemTools = New DevExpress.ExpressApp.Win.Templates.MainMenuItem
      Me.cTools = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
      Me.cOptions = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
      Me.cDiagnostic = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
      Me.barSubItemView = New DevExpress.ExpressApp.Win.Templates.MainMenuItem
      Me.cRecordsNavigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.cView = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.barSubItemHelp = New DevExpress.ExpressApp.Win.Templates.MainMenuItem
      Me.cAbout = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
      Me.StandardToolBar = New DevExpress.XtraBars.Bar
      Me.cFiltersSearch = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
      Me.StatusBar = New DevExpress.XtraBars.Bar
      Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl
      Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl
      Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl
      Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl
      Me.viewSitePanel = New DevExpress.XtraEditors.PanelControl
      CType(Me.mainBarManager, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.cFilters = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()

      '
      'mainBarManager
      '
      Me.mainBarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.MainMenuBar, Me.StandardToolBar, Me.StatusBar})
      Me.mainBarManager.DockControls.Add(Me.barDockControlTop)
      Me.mainBarManager.DockControls.Add(Me.barDockControlBottom)
      Me.mainBarManager.DockControls.Add(Me.barDockControlLeft)
      Me.mainBarManager.DockControls.Add(Me.barDockControlRight)
      Me.mainBarManager.Form = Me
      Me.mainBarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barSubItemFile, Me.cFilters, Me.barSubItemEdit, Me.barSubItemView, Me.barSubItemTools, Me.barSubItemHelp, Me.cFile, Me.cObjectsCreation, Me.cClose, Me.cPrint, Me.cExport, Me.cRecordEdit, Me.cRecordsNavigation, Me.cFiltersSearch, Me.cView, Me.cTools, Me.cOptions, Me.cDiagnostic, Me.cAbout})
      Me.mainBarManager.MainMenu = Me.MainMenuBar
      Me.mainBarManager.MaxItemId = 19
      Me.mainBarManager.StatusBar = Me.StatusBar
      '
      'MainMenuBar
      '
      Me.MainMenuBar.BarName = "Main Menu"
      Me.MainMenuBar.DockCol = 0
      Me.MainMenuBar.DockRow = 0
      Me.MainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
      Me.MainMenuBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemFile), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemTools), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemView), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemHelp)})
      Me.MainMenuBar.OptionsBar.MultiLine = True
      Me.MainMenuBar.OptionsBar.UseWholeRow = True
      Me.MainMenuBar.Text = "Main Menu"
      '
      'barSubItemFile
      '
      Me.barSubItemFile.Caption = "File"
      Me.barSubItemFile.Id = 0
      Me.barSubItemFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFilters, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFile, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cClose, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cExport, True)})
      Me.barSubItemFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.barSubItemFile.Name = "barSubItemFile"
      '
      'cObjectsCreation
      '
      Me.cObjectsCreation.Caption = "Objects Creation"
      Me.cObjectsCreation.ContainerId = "ObjectsCreation"
      Me.cObjectsCreation.Id = 17
      Me.cObjectsCreation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cObjectsCreation.Name = "cObjectsCreation"
      '
      'cFile
      '
      Me.cFile.Caption = "File"
      Me.cFile.ContainerId = "File"
      Me.cFile.Id = 5
      Me.cFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cFile.Name = "cFile"
      '
      'cClose
      '
      Me.cClose.Caption = "Close"
      Me.cClose.ContainerId = "Close"
      Me.cClose.Id = 18
      Me.cClose.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cClose.Name = "cClose"
      '
      'cPrint
      '
      Me.cPrint.Caption = "Print"
      Me.cPrint.ContainerId = "Print"
      Me.cPrint.Id = 6
      Me.cPrint.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cPrint.Name = "cPrint"
      '
      'cExport
      '
      Me.cExport.Caption = "Export"
      Me.cExport.ContainerId = "Export"
      Me.cExport.Id = 7
      Me.cExport.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cExport.Name = "cExport"
      '
      'barSubItemEdit
      '
      Me.barSubItemEdit.Caption = "Edit"
      Me.barSubItemEdit.Id = 1
      Me.barSubItemEdit.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordEdit, True)})
      Me.barSubItemEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.barSubItemEdit.Name = "barSubItemEdit"
      '
      'cRecordEdit
      '
      Me.cRecordEdit.Caption = "Record Edit"
      Me.cRecordEdit.ContainerId = "RecordEdit"
      Me.cRecordEdit.Id = 9
      Me.cRecordEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cRecordEdit.Name = "cRecordEdit"
      '
      'barSubItemTools
      '
      Me.barSubItemTools.Caption = "Tools"
      Me.barSubItemTools.Id = 3
      Me.barSubItemTools.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cTools, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cOptions, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cDiagnostic, True)})
      Me.barSubItemTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.barSubItemTools.Name = "barSubItemTools"
      '
      'cTools
      '
      Me.cTools.Caption = "Tools"
      Me.cTools.ContainerId = "Tools"
      Me.cTools.Id = 13
      Me.cTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cTools.Name = "cTools"
      '
      'cOptions
      '
      Me.cOptions.Caption = "Options"
      Me.cOptions.ContainerId = "Options"
      Me.cOptions.Id = 14
      Me.cOptions.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cOptions.Name = "cOptions"
      '
      'cDiagnostic
      '
      Me.cDiagnostic.Caption = "Diagnostic"
      Me.cDiagnostic.ContainerId = "Diagnostic"
      Me.cDiagnostic.Id = 16
      Me.cDiagnostic.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cDiagnostic.Name = "cDiagnostic"
      '
      'barSubItemView
      '
      Me.barSubItemView.Caption = "View"
      Me.barSubItemView.Id = 2
      Me.barSubItemView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cView, True)})
      Me.barSubItemView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.barSubItemView.Name = "barSubItemView"
      '
      'cRecordsNavigation
      '
      Me.cRecordsNavigation.Caption = "Records Navigation"
      Me.cRecordsNavigation.ContainerId = "RecordsNavigation"
      Me.cRecordsNavigation.Id = 10
      Me.cRecordsNavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cRecordsNavigation.Name = "cRecordsNavigation"
      '
      'cView
      '
      Me.cView.Caption = "View"
      Me.cView.ContainerId = "View"
      Me.cView.Id = 12
      Me.cView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cView.Name = "cView"
      '
      'barSubItemHelp
      '
      Me.barSubItemHelp.Caption = "Help"
      Me.barSubItemHelp.Id = 4
      Me.barSubItemHelp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cAbout, True)})
      Me.barSubItemHelp.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.barSubItemHelp.Name = "barSubItemHelp"
      '
      'cAbout
      '
      Me.cAbout.Caption = "About"
      Me.cAbout.ContainerId = "About"
      Me.cAbout.Id = 15
      Me.cAbout.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cAbout.Name = "cAbout"
      '
      'StandardToolBar
      '
      Me.StandardToolBar.BarName = "Main Toolbar"
      Me.StandardToolBar.DockCol = 0
      Me.StandardToolBar.DockRow = 1
      Me.StandardToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
      Me.StandardToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFilters, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cClose, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFiltersSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordsNavigation, True)})
      Me.StandardToolBar.Text = "Main Toolbar"
      ' 
      ' cFilters
      ' 
      Me.cFilters.Caption = CaptionHelper.GetLocalizedText(FrameTemplatesDetailViewForm, "Filters", "Filters")
      Me.cFilters.ContainerId = "Filters"
      Me.cFilters.Id = 26
      Me.cFilters.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cFilters.Name = "cFilters" 

      '
      'cFiltersSearch
      '
      Me.cFiltersSearch.Caption = "Search"
      Me.cFiltersSearch.ContainerId = "Search"
      Me.cFiltersSearch.Id = 11
      Me.cFiltersSearch.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
      Me.cFiltersSearch.Name = "cFiltersSearch"
      '
      'StatusBar
      '
      Me.StatusBar.BarName = "StatusBar"
      Me.StatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
      Me.StatusBar.DockCol = 0
      Me.StatusBar.DockRow = 0
      Me.StatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
      Me.StatusBar.OptionsBar.AllowQuickCustomization = False
      Me.StatusBar.OptionsBar.DisableClose = True
      Me.StatusBar.OptionsBar.DisableCustomization = True
      Me.StatusBar.OptionsBar.DrawDragBorder = False
      Me.StatusBar.OptionsBar.DrawSizeGrip = True
      Me.StatusBar.OptionsBar.UseWholeRow = True
      Me.StatusBar.Text = "Status Bar"
      '
      'viewSitePanel
      '
      Me.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
      Me.viewSitePanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.viewSitePanel.Location = New System.Drawing.Point(0, 49)
      Me.viewSitePanel.Name = "viewSitePanel"
      Me.viewSitePanel.Size = New System.Drawing.Size(792, 495)
      Me.viewSitePanel.TabIndex = 4
      '
      'MDIChildForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(792, 566)
      Me.Controls.Add(Me.viewSitePanel)
      Me.Controls.Add(Me.barDockControlLeft)
      Me.Controls.Add(Me.barDockControlRight)
      Me.Controls.Add(Me.barDockControlBottom)
      Me.Controls.Add(Me.barDockControlTop)
      Me.Name = "MDIChildForm"
      Me.Text = "SimpleForm"
      CType(Me.mainBarManager, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Private mainBarManager As DevExpress.XtraBars.BarManager
   Private barDockControlTop As DevExpress.XtraBars.BarDockControl
   Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
   Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
   Private barDockControlRight As DevExpress.XtraBars.BarDockControl
   Private MainMenuBar As DevExpress.XtraBars.Bar
   Private StandardToolBar As DevExpress.XtraBars.Bar
   Private StatusBar As DevExpress.XtraBars.Bar
   Private cFile As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cObjectsCreation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cClose As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cPrint As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cExport As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private barSubItemFile As DevExpress.ExpressApp.Win.Templates.MainMenuItem
   Private barSubItemEdit As DevExpress.ExpressApp.Win.Templates.MainMenuItem
   Private barSubItemView As DevExpress.ExpressApp.Win.Templates.MainMenuItem
   Private barSubItemTools As DevExpress.ExpressApp.Win.Templates.MainMenuItem
   Private barSubItemHelp As DevExpress.ExpressApp.Win.Templates.MainMenuItem
   Private cRecordEdit As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cRecordsNavigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cFiltersSearch As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cView As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
   Private cTools As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
   Private cOptions As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
   Private cAbout As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
   Private cDiagnostic As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
   Private viewSitePanel As DevExpress.XtraEditors.PanelControl
   Private cFilters As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
#End Region

End Class

