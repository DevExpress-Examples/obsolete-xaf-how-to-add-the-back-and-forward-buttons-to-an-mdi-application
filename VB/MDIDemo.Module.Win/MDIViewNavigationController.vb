Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.NodeWrappers

Public Class MDIViewNavigationController
	Inherits DevExpress.ExpressApp.WindowController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components)
      navigationHistory = New NavigationHistory(Of ViewShortcut)()
   End Sub
   Private Const HistoryDepth As Integer = 10
   Private navigationHistory As NavigationHistory(Of ViewShortcut)
   Private isNavigating As Boolean = False
   Private MDIParent As Windows.Forms.Form
   Private currentShortcut As ViewShortcut

   Protected Overrides Sub OnActivated()
      MyBase.OnActivated()
      AddHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
   End Sub
   Protected Overrides Sub OnDeactivating()
      MyBase.OnDeactivating()
      RemoveHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
      ResetMDIParent(Nothing)
   End Sub
   Private Sub Window_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Not Window.Template Is Nothing Then
         ResetMDIParent(CType(Window.Template, Windows.Forms.Form))
      End If
   End Sub
   Private Sub ResetMDIParent(ByVal form As Windows.Forms.Form)
      If Not MDIParent Is Nothing Then
         RemoveHandler MDIParent.MdiChildActivate, AddressOf MDIViewNavigationController_MdiChildActivate
      End If
      MDIParent = form
      If Not MDIParent Is Nothing Then
         AddHandler MDIParent.MdiChildActivate, AddressOf MDIViewNavigationController_MdiChildActivate
      End If
   End Sub
   Private Sub MDIViewNavigationController_MdiChildActivate(ByVal sender As Object, ByVal e As EventArgs)
      CheckAndDeleteUnexistingItems()
      UpdateHistoryItemsInfo()
      Dim newMDIChild As XtraFormTemplateBase = CType(MDIParent.ActiveMdiChild, XtraFormTemplateBase)
      If Not newMDIChild Is Nothing AndAlso Not newMDIChild.View Is Nothing Then
         Dim currentView As DevExpress.ExpressApp.View = newMDIChild.View
         currentShortcut = currentView.CreateShortcut()
         If (Not isNavigating) Then
            navigationHistory.Add(GetViewCaption(currentView), GetImageName(currentView), currentView.CreateShortcut())
         End If
      End If
      RefreshActionsState()
   End Sub
   Private Sub CheckAndDeleteUnexistingItems()
      Dim wasRemoved As Boolean = FindFormByViewShortcut(currentShortcut) Is Nothing
      If wasRemoved Then
         DeleteFromNavigationHistory(currentShortcut)
      End If
   End Sub
   Private Function FindFormByViewShortcut(ByVal shortcut As ViewShortcut) As XtraFormTemplateBase
      For Each child As XtraFormTemplateBase In MDIParent.MdiChildren
         If Not child.View Is Nothing Then
            If child.View.CreateShortcut().Equals(currentShortcut) Then
               Return child
            End If
         End If
      Next child
      Return Nothing
   End Function
   Private Sub UpdateHistoryItemsInfo()
      Dim page As XtraFormTemplateBase = FindFormByViewShortcut(currentShortcut)
      If Not page Is Nothing AndAlso Not page.View Is Nothing AndAlso TypeOf page.View Is DetailView Then
         Dim currentPositionIndex As Integer = navigationHistory.CurrentPositionIndex
         navigationHistory.CurrentPositionIndex = -1
         Do While navigationHistory.CanForward
            navigationHistory.Forward()
            If navigationHistory.CurrentPosition.Item.Equals(currentShortcut) Then
               navigationHistory.UpdateCurrentItem(GetViewCaption(page.View), GetImageName(page.View), page.View.CreateShortcut())
            End If
         Loop
         navigationHistory.CurrentPositionIndex = currentPositionIndex
      End If
   End Sub
   Private Function GetViewCaption(ByVal view As DevExpress.ExpressApp.View) As String
      Dim caption As String = view.Caption
      If TypeOf view Is DetailView AndAlso (Not String.IsNullOrEmpty(view.GetCurrentObjectCaption())) Then
         caption = view.GetCurrentObjectCaption()
      End If
      Return caption
   End Function
   Private Function GetImageName(ByVal view As DevExpress.ExpressApp.View) As String
      If (Not view.Info Is Nothing) Then
         Return view.Info.GetAttributeValue(VisualItemInfoNodeWrapper.ImageNameAttribute)
      Else
         Return Nothing
      End If
   End Function
   Private Sub DeleteFromNavigationHistory(ByVal shortcut As ViewShortcut)
      Dim currentPositionIndex As Integer = navigationHistory.CurrentPositionIndex
      Dim deletedPositionIndex As Integer
      Do While navigationHistory.IndexOf(shortcut) <> -1
         deletedPositionIndex = navigationHistory.IndexOf(shortcut)
         navigationHistory.CurrentPositionIndex = deletedPositionIndex
         navigationHistory.DeleteCurrentItem()
         If (deletedPositionIndex > currentPositionIndex) Then
            currentPositionIndex = currentPositionIndex
         Else
            currentPositionIndex = currentPositionIndex - 1
         End If
         If navigationHistory.CurrentPositionIndex > -1 AndAlso navigationHistory.Count > navigationHistory.CurrentPositionIndex + 1 Then
            Dim nextItem As HistoryItem(Of ViewShortcut) = navigationHistory.CurrentPosition
            navigationHistory.CurrentPositionIndex += 1
            Dim previuosItem As HistoryItem(Of ViewShortcut) = navigationHistory.CurrentPosition
            If nextItem.Item.Equals(previuosItem.Item) Then
               navigationHistory.DeleteCurrentItem()
               If (navigationHistory.CurrentPositionIndex > currentPositionIndex) Then
                  currentPositionIndex = currentPositionIndex
               Else
                  currentPositionIndex = currentPositionIndex - 1
               End If
            End If
         End If

      Loop
      If (currentPositionIndex < 0) Then
         navigationHistory.CurrentPositionIndex = 0
      Else
         navigationHistory.CurrentPositionIndex = currentPositionIndex
      End If
   End Sub
   Private Sub RefreshActionsState()
      mdiBackAction.Enabled.SetItemValue("Can back", navigationHistory.CanBack)
      mdiForwardAction.Enabled.SetItemValue("Can forward", navigationHistory.CanForward)
      UpdateActionsItems()
   End Sub
   Private Sub UpdateActionsItems()
      Dim list As List(Of HistoryItem(Of ViewShortcut)) = New List(Of HistoryItem(Of ViewShortcut))()
      For Each item As HistoryItem(Of ViewShortcut) In navigationHistory
         list.Add(item)
      Next item

      Dim currentIndex As Integer = navigationHistory.CurrentPositionIndex
      mdiBackAction.Items.Clear()
      Dim count As Integer = 0
      Do While count <= HistoryDepth AndAlso navigationHistory.CanBack
         navigationHistory.Back()
         Dim info As VisualItemInfoNodeWrapper = New VisualItemInfoNodeWrapper(New DictionaryNode(""))
         info.Caption = list(currentIndex - count).Caption
         info.ImageName = list(currentIndex - count).ImageName
         mdiBackAction.Items.Add(New ChoiceActionItem(info.Node, list(currentIndex - count).Item))
         count += 1
         count = count
      Loop
      If mdiBackAction.Items.Count > 0 Then
         mdiBackAction.SelectedIndex = 0
      End If
      navigationHistory.CurrentPositionIndex = currentIndex

      mdiForwardAction.Items.Clear()
      count = 0
      Do While count <= HistoryDepth AndAlso navigationHistory.CanForward
         navigationHistory.Forward()
         Dim info As VisualItemInfoNodeWrapper = New VisualItemInfoNodeWrapper(New DictionaryNode(""))
         info.Caption = list(currentIndex + count).Caption
         info.ImageName = list(currentIndex + count).ImageName
         mdiForwardAction.Items.Add(New ChoiceActionItem(info.Node, list(currentIndex + count).Item))
         count += 1
         count = count
      Loop
      If mdiForwardAction.Items.Count > 0 Then
         mdiForwardAction.SelectedIndex = 0
      End If
      navigationHistory.CurrentPositionIndex = currentIndex
   End Sub

   Private Sub mdiForwardAction_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs) Handles mdiForwardAction.Execute
      Dim action As SingleChoiceAction = TryCast(sender, SingleChoiceAction)
      Dim indexOfAction As Integer = action.Items.IndexOf(e.SelectedChoiceActionItem)
      NavigateTo(navigationHistory.CurrentPositionIndex + indexOfAction + 1)
   End Sub

   Private Sub mdiBackAction_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs) Handles mdiBackAction.Execute
      Dim action As SingleChoiceAction = TryCast(sender, SingleChoiceAction)
      Dim indexOfAction As Integer = action.Items.IndexOf(e.SelectedChoiceActionItem)
      NavigateTo(navigationHistory.CurrentPositionIndex - indexOfAction - 1)
   End Sub
   Private Sub NavigateTo(ByVal historyItemIndex As Integer)
      navigationHistory.CurrentPositionIndex = historyItemIndex
      Dim viewShortcut As ViewShortcut = navigationHistory.CurrentPosition.Item
      isNavigating = True
      Try
         For Each child As XtraFormTemplateBase In MDIParent.MdiChildren
            If child.View.CreateShortcut().Equals(viewShortcut) Then
               child.Activate()
               Exit For
            End If
         Next child
      Finally
         isNavigating = False
      End Try
      RefreshActionsState()
   End Sub
End Class
