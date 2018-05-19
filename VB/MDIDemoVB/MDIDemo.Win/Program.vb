Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports MDIDemo.Win
'Imports DevExpress.ExpressApp.Win.CustomTemplates

Public Class Program

    Private Shared Sub WinApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal args As DatabaseVersionMismatchEventArgs)
        If System.Diagnostics.Debugger.IsAttached Then
            args.Updater.Update()
            args.Handled = True
        End If
    End Sub
    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
        Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
      Dim _application As MDIDemoWindowsFormsApplication = New MDIDemoWindowsFormsApplication()
      _application.ShowViewStrategy = New MDIStrategy(_application)
      AddHandler _application.CreateCustomTemplate, AddressOf application_CreateCustomTemplate
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            _application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
        End If
        If System.Diagnostics.Debugger.IsAttached Then
            _application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End If
        Try
            _application.Setup()
            _application.Start()
        Catch e As Exception
            _application.HandleException(e)
        End Try

   End Sub
   Shared Sub application_CreateCustomTemplate(ByVal sender As Object, _
      ByVal e As CreateCustomTemplateEventArgs)
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
