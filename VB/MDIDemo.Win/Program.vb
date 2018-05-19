Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace MDIDemo.Win
    Friend NotInheritable Class Program
        Private Sub New()
        End Sub
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim winApplication As New MDIDemoWindowsFormsApplication()
            AddHandler winApplication.CreateCustomTemplate, AddressOf Manager_CreateCustomTemplate
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If
            Try
                winApplication.ShowViewStrategy = New MDIStrategy(winApplication)
                winApplication.Setup()
                winApplication.Start()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
        End Sub

        Private Shared Sub Manager_CreateCustomTemplate(ByVal sender As Object, ByVal e As CreateCustomTemplateEventArgs)
            If e.Context = TemplateContext.ApplicationWindow Then
                e.Template = New MDIMainForm()
            Else
                If e.Context = TemplateContext.View Then
                    e.Template = New MDIChildForm()
                Else
                    e.Template = Nothing
                End If
            End If
        End Sub
    End Class
End Namespace
