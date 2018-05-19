Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win

Namespace MDIDemo.Win
    Friend Class MDIStrategy
        Inherits DevExpress.ExpressApp.Win.WinShowViewStrategyBase
        Private delayedToShow As New List(Of WinWindow)()
        Protected Overrides Sub ShowViewFromCommonView(ByVal parameters As ShowViewParameters, ByVal showViewSource As ShowViewSource)
            Dim existWindow As WinWindow = FindWindowByView(parameters.CreatedView)
            If existWindow IsNot Nothing Then
                existWindow.Show()
            Else
                ShowViewInNewWindow(parameters, showViewSource)
            End If
        End Sub
        Protected Overrides Sub ShowViewCore(ByVal parameters As ShowViewParameters, ByVal showViewSource As ShowViewSource)
            If parameters.TargetWindow = TargetWindow.Current AndAlso showViewSource.SourceFrame Is MainWindow Then
                parameters.TargetWindow = TargetWindow.Default
            End If
            MyBase.ShowViewCore(parameters, showViewSource)
        End Sub
        Protected Overrides Sub ShowViewFromLookupView(ByVal parameters As ShowViewParameters, ByVal showViewSource As ShowViewSource)
            ShowViewInModalWindow(parameters, showViewSource)
        End Sub
        Protected Overrides Sub BeforeShowWindow(ByVal window As WinWindow)
            If window IsNot MainWindow Then
                window.Form.MdiParent = MainWindow.Form
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
        Protected Overrides Sub ShowWindow(ByVal window As WinWindow)
            If (Not window.IsMain) AndAlso MainWindow Is Nothing Then
                delayedToShow.Add(window)
            Else
                MyBase.ShowWindow(window)
            End If
        End Sub
    End Class
End Namespace
