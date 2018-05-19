Imports Microsoft.VisualBasic
Imports System
Namespace MDIDemo.Win
    Partial Public Class MDIDemoWindowsFormsApplication
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

        #Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            Me.schedulerWindowsFormsModule1 = New DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule()
            Me.module3 = New MDIDemo.Module.MDIDemoModule()
            Me.module4 = New MDIDemo.Module.Win.MDIDemoWindowsFormsModule()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=MDIDemo1;Integrated Security=SSPI;Pooling=fal" & "se"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' MDIDemoWindowsFormsApplication
            ' 
            Me.ApplicationName = "MDIDemo"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.schedulerWindowsFormsModule1)
'            Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.MDIDemoWindowsFormsApplication_DatabaseVersionMismatch);
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        #End Region

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
        Private module3 As MDIDemo.Module.MDIDemoModule
        Private module4 As MDIDemo.Module.Win.MDIDemoWindowsFormsModule
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection
        Private schedulerWindowsFormsModule1 As DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule
    End Class
End Namespace
