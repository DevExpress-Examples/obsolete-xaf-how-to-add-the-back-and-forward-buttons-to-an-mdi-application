Imports System.ComponentModel
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base


Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Utils

Namespace MDISolution.Module.Win.Controllers
   Partial Public Class MDIViewNavigationController
	   Inherits WindowController

	  Public Sub New()
		 InitializeComponent()
		 RegisterActions(components)
		 navigationHistory = New NavigationHistory(Of ViewShortcut)()
	  End Sub
	  Private Const HistoryDepth As Integer = 10
	  Private navigationHistory As NavigationHistory(Of ViewShortcut)
	  Private isNavigating As Boolean = False
	  Private MDIParent As Form
	  Private currentShortcut As ViewShortcut

	  Protected Overrides Sub OnActivated()
		 MyBase.OnActivated()
		 AddHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
	  End Sub
	  Protected Overrides Sub OnDeactivated()
		 MyBase.OnDeactivated()
		 RemoveHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
		 ResetMDIParent(Nothing)
	  End Sub
	  Private Sub Window_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
		 If Window.Template IsNot Nothing Then
			ResetMDIParent(CType(Window.Template, Form))
		 End If
	  End Sub
	  Private Sub MDIViewNavigationController_MdiChildActivate(ByVal sender As Object, ByVal e As EventArgs)
		 CheckAndDeleteUnexistingItems()
		 UpdateHistoryItemsInfo()
		 Dim newMDIChild As XtraFormTemplateBase = CType(MDIParent.ActiveMdiChild, XtraFormTemplateBase)
		 If newMDIChild IsNot Nothing AndAlso newMDIChild.View IsNot Nothing Then
			Dim currentView As DevExpress.ExpressApp.View = newMDIChild.View
			currentShortcut = currentView.CreateShortcut()
			If Not isNavigating Then
			   navigationHistory.Add(GetViewCaption(currentView), GetImageName(currentView), currentView.CreateShortcut())
			End If
		 End If
		 RefreshActionsState()
	  End Sub
	  Private Sub mdiForwardAction_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs) Handles mdiForwardAction.Execute
		 Dim action As SingleChoiceAction = TryCast(sender, SingleChoiceAction)
		 Dim indexOfAction As Integer = action.Items.IndexOf(e.SelectedChoiceActionItem)
		 NavigateTo(navigationHistory.CurrentPositionIndex + indexOfAction + 1)
	  End Sub
	  Private Sub mdiBackAction_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs) Handles mdiBackAction.Execute
		 Dim action As SingleChoiceAction = TryCast(sender, SingleChoiceAction)
		 Dim indexOfAction As Integer = action.Items.IndexOf(e.SelectedChoiceActionItem)
		 NavigateTo(navigationHistory.CurrentPositionIndex - indexOfAction - 1)
	  End Sub
	  Private Sub ResetMDIParent(ByVal form As Form)
		 If MDIParent IsNot Nothing Then
			RemoveHandler MDIParent.MdiChildActivate, AddressOf MDIViewNavigationController_MdiChildActivate
		 End If
		 MDIParent = form
		 If MDIParent IsNot Nothing Then
			AddHandler MDIParent.MdiChildActivate, AddressOf MDIViewNavigationController_MdiChildActivate
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
		 Return If(view.Model IsNot Nothing, view.Model.ImageName, Nothing)
	  End Function
	  Private Function FindFormByViewShortcut(ByVal shortcut As ViewShortcut) As XtraFormTemplateBase
		 For Each child As XtraFormTemplateBase In MDIParent.MdiChildren
			 If (Not child.Disposing) AndAlso child.View IsNot Nothing Then
				 If child.View IsNot Nothing Then
					 If child.View.CreateShortcut().Equals(currentShortcut) Then
						 Return child
					 End If
				 End If
			 End If
		 Next child
		 Return Nothing
	  End Function
	  Private Sub CheckAndDeleteUnexistingItems()
		 Dim wasRemoved As Boolean = FindFormByViewShortcut(currentShortcut) Is Nothing
		 If wasRemoved Then
			DeleteFromNavigationHistory(currentShortcut)
		 End If
	  End Sub
	  Private Sub DeleteFromNavigationHistory(ByVal shortcut As ViewShortcut)
		 Dim currentPositionIndex As Integer = navigationHistory.CurrentPositionIndex
		 Dim deletedPositionIndex As Integer
		 deletedPositionIndex = navigationHistory.IndexOf(shortcut)
		 Do While deletedPositionIndex <> -1
			navigationHistory.CurrentPositionIndex = deletedPositionIndex
			navigationHistory.DeleteCurrentItem()
			currentPositionIndex = If(deletedPositionIndex > currentPositionIndex, currentPositionIndex, currentPositionIndex - 1)
			If navigationHistory.CurrentPositionIndex > -1 AndAlso navigationHistory.Count > navigationHistory.CurrentPositionIndex + 1 Then
			   Dim nextItem As HistoryItem(Of ViewShortcut) = navigationHistory.CurrentPosition
			   navigationHistory.CurrentPositionIndex += 1
			   Dim previuosItem As HistoryItem(Of ViewShortcut) = navigationHistory.CurrentPosition
			   If nextItem.Item.Equals(previuosItem.Item) Then
				  navigationHistory.DeleteCurrentItem()
				  currentPositionIndex = If(navigationHistory.CurrentPositionIndex > currentPositionIndex, currentPositionIndex, currentPositionIndex - 1)
			   End If
			End If

			 deletedPositionIndex = navigationHistory.IndexOf(shortcut)
		 Loop
		 navigationHistory.CurrentPositionIndex = If(currentPositionIndex < 0, 0, currentPositionIndex)
	  End Sub
	  Private Sub UpdateHistoryItemsInfo()
		 Dim page As XtraFormTemplateBase = FindFormByViewShortcut(currentShortcut)
		 If page IsNot Nothing AndAlso page.View IsNot Nothing AndAlso TypeOf page.View Is DetailView Then
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
	  Private Sub UpdateActionsItems()
		 Dim list As New List(Of HistoryItem(Of ViewShortcut))()
		 For Each item As HistoryItem(Of ViewShortcut) In navigationHistory
			list.Add(item)
		 Next item

		 Dim currentIndex As Integer = navigationHistory.CurrentPositionIndex
		 mdiBackAction.Items.Clear()
		 Dim count As Integer = 1
		 Do While count <= HistoryDepth AndAlso navigationHistory.CanBack
			navigationHistory.Back()
			Dim item As New ChoiceActionItem(list(currentIndex - count).Caption, list(currentIndex - count).Item)
			item.ImageName = list(currentIndex - count).ImageName
			mdiBackAction.Items.Add(item)
			count += 1
			count = count
		 Loop
		 If mdiBackAction.Items.Count > 0 Then
			mdiBackAction.SelectedIndex = 0
		 End If
		 navigationHistory.CurrentPositionIndex = currentIndex

		 mdiForwardAction.Items.Clear()
		 count = 1
		 Do While count <= HistoryDepth AndAlso navigationHistory.CanForward
			navigationHistory.Forward()
			Dim item As New ChoiceActionItem(list(currentIndex + count).Caption, list(currentIndex + count).Item)
			item.ImageName = list(currentIndex + count).ImageName
			mdiForwardAction.Items.Add(item)
			count += 1
			count = count
		 Loop
		 If mdiForwardAction.Items.Count > 0 Then
			mdiForwardAction.SelectedIndex = 0
		 End If
		 navigationHistory.CurrentPositionIndex = currentIndex
	  End Sub
	  Private Sub RefreshActionsState()
		 mdiBackAction.Enabled.SetItemValue("Can back", navigationHistory.CanBack)
		 mdiForwardAction.Enabled.SetItemValue("Can forward", navigationHistory.CanForward)
		 UpdateActionsItems()
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
End Namespace
