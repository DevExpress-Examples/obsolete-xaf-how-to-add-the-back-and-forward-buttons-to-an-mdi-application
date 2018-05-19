Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp.Utils
Namespace MDIDemo.Win
    Partial Public Class MDIMainForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
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
            Me.components = New System.ComponentModel.Container()
            Me.barManager = New DevExpress.XtraBars.BarManager(Me.components)
            Me.MainMenuBar = New DevExpress.XtraBars.Bar()
            Me.barSubItemFile = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.cObjectsCreation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cFile = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cPrint = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cExport = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cExit = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.barSubItemEdit = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.cRecordEdit = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.barSubItemView = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.barCheckItemNavigationPaneVisibility = New DevExpress.XtraBars.BarCheckItem()
            Me.cMDINavigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem()
            Me.cRecordsNavigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cView = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.barSubItemTools = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.cTools = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem()
            Me.cDiagnostic = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem()
            Me.cOptions = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem()
            Me.barSubItemWindow = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.barButtonItemCloseAll = New DevExpress.XtraBars.BarButtonItem()
            Me.barMdiChildrenListItem = New DevExpress.XtraBars.BarMdiChildrenListItem()
            Me.barSubItemHelp = New DevExpress.ExpressApp.Win.Templates.MainMenuItem()
            Me.cAbout = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem()
            Me.StandardToolBar = New DevExpress.XtraBars.Bar()
            Me.cFiltersSearch = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.cFilters = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
            Me.StatusBar = New DevExpress.XtraBars.Bar()
            Me.barAndDockingController1 = New DevExpress.XtraBars.BarAndDockingController(Me.components)
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.dockManager1 = New DevExpress.XtraBars.Docking.DockManager()
            Me.dockPanelNavigation = New DevExpress.XtraBars.Docking.DockPanel()
            Me.dockPanelNavigation_Container = New DevExpress.XtraBars.Docking.ControlContainer()
            Me.navigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.NavigationActionContainer()
            Me.xtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
            CType(Me.barManager, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.barAndDockingController1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dockPanelNavigation.SuspendLayout()
            Me.dockPanelNavigation_Container.SuspendLayout()
            CType(Me.xtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' barManager
            ' 
            Me.barManager.Bars.AddRange(New DevExpress.XtraBars.Bar() { Me.MainMenuBar, Me.StandardToolBar, Me.StatusBar})
            Me.barManager.Controller = Me.barAndDockingController1
            Me.barManager.DockControls.Add(Me.barDockControlTop)
            Me.barManager.DockControls.Add(Me.barDockControlBottom)
            Me.barManager.DockControls.Add(Me.barDockControlLeft)
            Me.barManager.DockControls.Add(Me.barDockControlRight)
            Me.barManager.DockManager = Me.dockManager1
            Me.barManager.Form = Me
            Me.barManager.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.barSubItemFile, Me.barSubItemEdit, Me.barSubItemView, Me.barSubItemTools, Me.barSubItemHelp, Me.cFile, Me.cObjectsCreation, Me.cPrint, Me.cExport, Me.cMDINavigation, Me.cExit, Me.cRecordEdit, Me.cRecordsNavigation, Me.cFiltersSearch, Me.cFilters, Me.cView, Me.cTools, Me.cDiagnostic, Me.cOptions, Me.cAbout, Me.barSubItemWindow, Me.barMdiChildrenListItem, Me.barButtonItemCloseAll, Me.barCheckItemNavigationPaneVisibility})
            Me.barManager.MainMenu = Me.MainMenuBar
            Me.barManager.MaxItemId = 34
            Me.barManager.StatusBar = Me.StatusBar
'            Me.barManager.Merge += New DevExpress.XtraBars.BarManagerMergeEventHandler(Me.barManager_Merge);
'            Me.barManager.UnMerge += New DevExpress.XtraBars.BarManagerMergeEventHandler(Me.barManager_UnMerge);
            ' 
            ' MainMenuBar
            ' 
            Me.MainMenuBar.BarName = "Main Menu"
            Me.MainMenuBar.DockCol = 0
            Me.MainMenuBar.DockRow = 0
            Me.MainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.MainMenuBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemFile), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemView), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemTools), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemWindow), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemHelp)})
            Me.MainMenuBar.OptionsBar.MultiLine = True
            Me.MainMenuBar.OptionsBar.UseWholeRow = True
            Me.MainMenuBar.Text = "Main Menu"
            ' 
            ' barSubItemFile
            ' 
            Me.barSubItemFile.Caption = "File"
            Me.barSubItemFile.Id = 0
            Me.barSubItemFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.cObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFile, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cExit, True)})
            Me.barSubItemFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemFile.Name = "barSubItemFile"
            ' 
            ' cObjectsCreation
            '			
            Me.cObjectsCreation.Caption = "Objects creation"
            Me.cObjectsCreation.ContainerId = "ObjectsCreation"
            Me.cObjectsCreation.Id = 18
            Me.cObjectsCreation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cObjectsCreation.Name = "cObjectsCreation"
            ' 
            ' cFile
            ' 
            Me.cFile.Caption = "File"
            Me.cFile.ContainerId = "File"
            Me.cFile.Id = 5
            Me.cFile.MergeOrder = 2
            Me.cFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cFile.Name = "cFile"
            ' 
            ' cPrint
            ' 
            Me.cPrint.Caption = "Print"
            Me.cPrint.ContainerId = "Print"
            Me.cPrint.Id = 6
            Me.cPrint.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cPrint.Name = "cPrint"
            ' 
            ' cExport
            ' 
            Me.cExport.Caption = "Export"
            Me.cExport.ContainerId = "Export"
            Me.cExport.Id = 7
            Me.cExport.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cExport.Name = "cExport"
            ' 
            ' cExit
            ' 
            Me.cExit.Caption = "Exit"
            Me.cExit.ContainerId = "Exit"
            Me.cExit.Id = 8
            Me.cExit.Name = "cExit"
            ' 
            ' barSubItemEdit
            ' 
            Me.barSubItemEdit.Caption = "Edit"
            Me.barSubItemEdit.Id = 1
            Me.barSubItemEdit.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFiltersSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFilters, True)})
            Me.barSubItemEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemEdit.Name = "barSubItemEdit"
            ' 
            ' cRecordEdit
            ' 
            Me.cRecordEdit.Caption = "Record Edit"
            Me.cRecordEdit.ContainerId = "RecordEdit"
            Me.cRecordEdit.Id = 9
            Me.cRecordEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cRecordEdit.Name = "cRecordEdit"
            ' 
            ' barSubItemView
            ' 
            Me.barSubItemView.Caption = "View"
            Me.barSubItemView.Id = 2
            Me.barSubItemView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.barCheckItemNavigationPaneVisibility, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cView, True)})
            Me.barSubItemView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemView.Name = "barSubItemView"
            ' 
            ' barCheckItemNavigationPaneVisibility
            ' 
            Me.barCheckItemNavigationPaneVisibility.Caption = "Navigation Bar"
            Me.barCheckItemNavigationPaneVisibility.Id = 33
            Me.barCheckItemNavigationPaneVisibility.Name = "barCheckItemNavigationPaneVisibility"
'            Me.barCheckItemNavigationPaneVisibility.CheckedChanged += New DevExpress.XtraBars.ItemClickEventHandler(Me.barCheckItemNavigationPaneVisibility_CheckedChanged);
            ' 
            ' cRecordsNavigation
            ' 
            Me.cRecordsNavigation.Caption = "Records Navigation"
            Me.cRecordsNavigation.ContainerId = "RecordsNavigation"
            Me.cRecordsNavigation.Id = 10
            Me.cRecordsNavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cRecordsNavigation.Name = "cRecordsNavigation"
            ' 
            ' cView
            ' 
            Me.cView.Caption = "View"
            Me.cView.ContainerId = "View"
            Me.cView.Id = 12
            Me.cView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cView.Name = "cView"
            ' 
            ' barSubItemTools
            ' 
            Me.barSubItemTools.Caption = "Tools"
            Me.barSubItemTools.Id = 3
            Me.barSubItemTools.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.cTools, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cDiagnostic, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cOptions, True)})
            Me.barSubItemTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemTools.Name = "barSubItemTools"
            ' 
            ' cTools
            ' 
            Me.cTools.Caption = "Tools"
            Me.cTools.ContainerId = "Tools"
            Me.cTools.Id = 13
            Me.cTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cTools.Name = "cTools"
            ' 
            ' cDiagnostic
            ' 
            Me.cDiagnostic.Caption = "Diagnostic"
            Me.cDiagnostic.ContainerId = "Diagnostic"
            Me.cDiagnostic.Id = 16
            Me.cDiagnostic.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cDiagnostic.Name = "cDiagnostic"
            ' 
            ' cOptions
            ' 
            Me.cOptions.Caption = "Options"
            Me.cOptions.ContainerId = "Options"
            Me.cOptions.Id = 14
            Me.cOptions.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cOptions.Name = "cOptions"
            ' 
            ' barSubItemWindow
            ' 
            Me.barSubItemWindow.Caption = "Window"
            Me.barSubItemWindow.Id = 32
            Me.barSubItemWindow.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.barButtonItemCloseAll, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barMdiChildrenListItem, True)})
            Me.barSubItemWindow.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemWindow.Name = "barSubItemWindow"
            ' 
            ' barButtonItemCloseAll
            ' 
            Me.barButtonItemCloseAll.Caption = "Close &All Windows"
            Me.barButtonItemCloseAll.Id = 43
            Me.barButtonItemCloseAll.Name = "barButtonItemCloseAll"
'            Me.barButtonItemCloseAll.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.barButtonItemCloseAll_ItemClick);
            ' 
            ' barMdiChildrenListItem
            ' 
            Me.barMdiChildrenListItem.Caption = "Window List"
            Me.barMdiChildrenListItem.Id = 37
            Me.barMdiChildrenListItem.Name = "barMdiChildrenListItem"
            ' 
            ' barSubItemHelp
            ' 
            Me.barSubItemHelp.Caption = "Help"
            Me.barSubItemHelp.Id = 4
            Me.barSubItemHelp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.cAbout, True)})
            Me.barSubItemHelp.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.barSubItemHelp.Name = "barSubItemHelp"
            ' 
            ' cAbout
            ' 
            Me.cAbout.Caption = "About"
            Me.cAbout.ContainerId = "About"
            Me.cAbout.Id = 15
            Me.cAbout.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cAbout.Name = "cAbout"
            ' 
            ' StandardToolBar
            ' 
            Me.StandardToolBar.BarName = "Main Toolbar"
            Me.StandardToolBar.DockCol = 0
            Me.StandardToolBar.DockRow = 1
            Me.StandardToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.StandardToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.cMDINavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFiltersSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFilters, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordsNavigation, True)})
            Me.StandardToolBar.Text = "Main Toolbar"
            ' 
            ' cFiltersSearch
            ' 
            Me.cFiltersSearch.Caption = "Search"
            Me.cFiltersSearch.ContainerId = "Search"
            Me.cFiltersSearch.Id = 11
            Me.cFiltersSearch.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cFiltersSearch.Name = "cFiltersSearch"
            '
            ' cMDINavigation
            '
            Me.cMDINavigation.Caption = "MDI Navigation"
            Me.cMDINavigation.ContainerId = "MDINavigation"
            Me.cMDINavigation.Id = 0
            Me.cMDINavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cMDINavigation.Name = "cMDINavigation"
            ' 
            ' cFilters
            ' 
            Me.cFilters.Caption = "Filters"
            Me.cFilters.ContainerId = "Filters"
            Me.cFilters.Id = 26
            Me.cFilters.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            Me.cFilters.Name = "cFilters"
            ' 
            ' StatusBar
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
            ' barAndDockingController1
            ' 
            Me.barAndDockingController1.PropertiesBar.AllowLinkLighting = False
            ' 
            ' dockManager1
            ' 
            Me.dockManager1.Controller = Me.barAndDockingController1
            Me.dockManager1.Form = Me
            Me.dockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() { Me.dockPanelNavigation})
            Me.dockManager1.TopZIndexControls.AddRange(New String() { "DevExpress.XtraBars.BarDockControl", "System.Windows.Forms.StatusBar"})
            ' 
            ' dockPanelNavigation
            ' 
            Me.dockPanelNavigation.Controls.Add(Me.dockPanelNavigation_Container)
            Me.dockPanelNavigation.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
            Me.dockPanelNavigation.FloatSize = New System.Drawing.Size(146, 428)
            Me.dockPanelNavigation.ID = New System.Guid("24977e30-0ea6-44aa-8fa4-9abaeb178b5e")
            Me.dockPanelNavigation.Location = New System.Drawing.Point(0, 49)
            Me.dockPanelNavigation.Name = "dockPanelNavigation"
            Me.dockPanelNavigation.Options.AllowDockBottom = False
            Me.dockPanelNavigation.Options.AllowDockTop = False
            Me.dockPanelNavigation.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left
            Me.dockPanelNavigation.SavedIndex = 2
            Me.dockPanelNavigation.Size = New System.Drawing.Size(146, 495)
            Me.dockPanelNavigation.TabStop = False
            Me.dockPanelNavigation.Text = "Navigation"
'            Me.dockPanelNavigation.ClosingPanel += New DevExpress.XtraBars.Docking.DockPanelCancelEventHandler(Me.dockPanelNavigation_ClosingPanel);
            ' 
            ' dockPanelNavigation_Container
            ' 
            Me.dockPanelNavigation_Container.Controls.Add(Me.navigation)
            Me.dockPanelNavigation_Container.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dockPanelNavigation_Container.Location = New System.Drawing.Point(3, 25)
            Me.dockPanelNavigation_Container.Name = "dockPanelNavigation_Container"
            Me.dockPanelNavigation_Container.Size = New System.Drawing.Size(140, 467)
            Me.dockPanelNavigation_Container.TabIndex = 0
            ' 
            ' navigation
            ' 
            Me.navigation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.navigation.Location = New System.Drawing.Point(0, 0)
            Me.navigation.Name = "navigation"
            Me.navigation.Size = New System.Drawing.Size(140, 467)
            ' 
            ' xtraTabbedMdiManager1
            ' 
            Me.xtraTabbedMdiManager1.Controller = Me.barAndDockingController1
            Me.xtraTabbedMdiManager1.MdiParent = Me
'            Me.xtraTabbedMdiManager1.PageAdded += New DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(Me.xtraTabbedMdiManager1_PageAdded);
'            Me.xtraTabbedMdiManager1.SelectedPageChanged += New System.EventHandler(Me.xtraTabbedMdiManager1_SelectedPageChanged);
            ' 
            ' MDIMainForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.Add(Me.dockPanelNavigation)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.IsMdiContainer = True
            Me.Name = "MDIMainForm"
            Me.Text = "MDIMainForm"
            CType(Me.barManager, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.barAndDockingController1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dockPanelNavigation.ResumeLayout(False)
            Me.dockPanelNavigation_Container.ResumeLayout(False)
            CType(Me.xtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private Shadows WithEvents barManager As DevExpress.XtraBars.BarManager
        Private barDockControlTop As DevExpress.XtraBars.BarDockControl
        Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Private barDockControlRight As DevExpress.XtraBars.BarDockControl
        Private MainMenuBar As DevExpress.XtraBars.Bar
        Private StandardToolBar As DevExpress.XtraBars.Bar
        Private StatusBar As DevExpress.XtraBars.Bar
        Private barAndDockingController1 As DevExpress.XtraBars.BarAndDockingController
        Private dockManager1 As DevExpress.XtraBars.Docking.DockManager
        Private cFile As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cObjectsCreation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cPrint As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cExport As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cExit As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private barSubItemFile As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private barSubItemEdit As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private barSubItemView As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private barSubItemTools As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private barSubItemHelp As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private cMDINavigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
        Private cRecordEdit As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cRecordsNavigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cFiltersSearch As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cFilters As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cView As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Private cTools As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
        Private cDiagnostic As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
        Private cOptions As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
        Private cAbout As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerMenuBarItem
        Private navigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.NavigationActionContainer
        Private WithEvents xtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
        Private barSubItemWindow As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Private barMdiChildrenListItem As DevExpress.XtraBars.BarMdiChildrenListItem
        Private WithEvents barButtonItemCloseAll As BarButtonItem
        Private WithEvents dockPanelNavigation As DevExpress.XtraBars.Docking.DockPanel
        Private dockPanelNavigation_Container As DevExpress.XtraBars.Docking.ControlContainer
        Private WithEvents barCheckItemNavigationPaneVisibility As DevExpress.XtraBars.BarCheckItem

        #End Region

    End Class
End Namespace
