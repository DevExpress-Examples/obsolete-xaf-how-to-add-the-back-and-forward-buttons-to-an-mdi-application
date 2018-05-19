Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win

Namespace MDIDemo.Win
    Partial Public Class MDIDemoWindowsFormsApplication
        Inherits WinApplication
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MDIDemoWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            End If
        End Sub
    End Class
End Namespace
