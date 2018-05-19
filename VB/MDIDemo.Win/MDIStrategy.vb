Imports DevExpress.ExpressApp.Win
Imports System.Collections.Generic
Imports DevExpress.ExpressApp

Friend Class MDIStrategy
   Inherits DevExpress.ExpressApp.Win.WinShowViewStrategyBase
   Private delayedToShow As List(Of WinWindow) = New List(Of WinWindow)()
   Private childWindows As List(Of WinWindow) = New List(Of WinWindow)()
   Private Sub window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
      e.Cancel = True
   End Sub
   Private Sub window_Closed(ByVal sender As Object, ByVal e As EventArgs)
      Dim window As WinWindow = TryCast(sender, WinWindow)
      RemoveHandler window.Closing, AddressOf window_Closing
      RemoveHandler window.Closed, AddressOf window_Closed
      childWindows.Remove(window)
   End Sub
   Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
      Dim form As Form = TryCast(sender, Form)
      Dim window As WinWindow = FindChildWindowByForm(form)
      e.Cancel = False
      If e.CloseReason = System.Windows.Forms.CloseReason.MdiFormClosing Then
         If window.Form.MdiParent.MdiChildren(0) Is window.Form Then
            e.Cancel = Not CanCloseMDIParentWindow()
         End If
         If (Not e.Cancel) Then
            RemoveHandler window.Form.FormClosing, AddressOf Form_FormClosing
            window.View.SynchronizeInfo()
            window.View.Close(False)
         End If
      Else
         e.Cancel = Not window.CanClose()
      End If
   End Sub
   Private Function FindChildWindowByForm(ByVal form As Form) As WinWindow
      For Each window As WinWindow In childWindows
         If window.Form Is form Then
            Return window
         End If
      Next window
      Return Nothing
   End Function
   Private Function CanCloseMDIParentWindow() As Boolean
      For Each window As WinWindow In childWindows
         If Not window.View Is Nothing AndAlso (Not window.View.CanClose()) Then
            Return False
         End If
      Next window
      Return True
   End Function
   Protected Overrides Sub ShowViewFromCommonView(ByVal parameters As ShowViewParameters, _
         ByVal showViewSource As ShowViewSource)
      Dim existWindow As WinWindow = FindWindowByView(parameters.CreatedView)
      If Not existWindow Is Nothing Then
         parameters.CreatedView.Dispose()
         parameters.CreatedView = existWindow.View
         existWindow.Show()
      Else
         ShowViewInNewWindow(showViewSource.SourceFrame, parameters.CreatedView, _
            TemplateContext.View, parameters.Controllers)
      End If
   End Sub
   Protected Overrides Sub ShowViewCore(ByVal parameters As ShowViewParameters, _
         ByVal showViewSource As ShowViewSource)
      If parameters.TargetWindow = TargetWindow.Current AndAlso _
            showViewSource.SourceFrame Is MainWindow Then
         parameters.TargetWindow = TargetWindow.Default
      End If
      MyBase.ShowViewCore(parameters, showViewSource)
   End Sub
   Protected Overrides Sub ShowViewFromLookupView(ByVal parameters As ShowViewParameters, _
         ByVal showViewSource As ShowViewSource)
      ShowInModalWindow(parameters, showViewSource.SourceFrame)
   End Sub
   Protected Overrides Sub BeforeShowWindow(ByVal window As WinWindow)
      If window IsNot MainWindow Then
         If Not window.Form.MdiParent Is MainWindow.Form Then
            window.Form.MdiParent = MainWindow.Form
            AddHandler window.Closing, AddressOf window_Closing
            AddHandler window.Form.FormClosing, AddressOf Form_FormClosing
            AddHandler window.Closed, AddressOf window_Closed
            childWindows.Add(window)
         End If
      End If
   End Sub
   Public Sub New(ByVal application As XafApplication)
      MyBase.New(application)
   End Sub
   Public Overrides Sub ShowStartupWindow()
      delayedToShow.Clear()
      Try
         MyBase.ShowStartupWindow()
      Finally
         System.Windows.Forms.Application.DoEvents()
         For Each child As WinWindow In delayedToShow
            ShowWindow(child)
         Next child
      End Try
   End Sub
   Public Overrides Sub ShowWindow(ByVal window As WinWindow)
      If (Not window.IsMain) AndAlso MainWindow Is Nothing Then
         delayedToShow.Add(window)
      Else
         MyBase.ShowWindow(window)
      End If
   End Sub
End Class

