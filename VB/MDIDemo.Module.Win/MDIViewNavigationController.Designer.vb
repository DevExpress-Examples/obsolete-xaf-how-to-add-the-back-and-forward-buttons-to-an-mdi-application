Imports Microsoft.VisualBasic
Imports System
Namespace MDIDemo.Win
    Partial Public Class MDIViewNavigationController
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
            Me.components = New System.ComponentModel.Container()
            Me.mdiBackAction = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
            Me.mdiForwardAction = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
            ' 
            ' mdiBackAction
            ' 
            Me.mdiBackAction.Caption = "Back"
            Me.mdiBackAction.Category = "MDINavigation"
            Me.mdiBackAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable
            Me.mdiBackAction.Id = "MDINavigateBack"
            Me.mdiBackAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
            Me.mdiBackAction.Tag = Nothing
            Me.mdiBackAction.TypeOfView = Nothing
'            Me.mdiBackAction.Execute += New DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(Me.mdiBackAction_Execute);
            ' 
            ' mdiForwardAction
            ' 
            Me.mdiForwardAction.Caption = "Forward"
            Me.mdiForwardAction.Category = "MDINavigation"
            Me.mdiForwardAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable
            Me.mdiForwardAction.Id = "MDINavigateForward"
            Me.mdiForwardAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
            Me.mdiForwardAction.Tag = Nothing
            Me.mdiForwardAction.TypeOfView = Nothing
'            Me.mdiForwardAction.Execute += New DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(Me.mdiForwardAction_Execute);
            ' 
            ' MDIViewNavigationController
            ' 
            Me.TargetWindowType = DevExpress.ExpressApp.WindowType.Main

        End Sub

        #End Region

        Private WithEvents mdiBackAction As DevExpress.ExpressApp.Actions.SingleChoiceAction
        Private WithEvents mdiForwardAction As DevExpress.ExpressApp.Actions.SingleChoiceAction
    End Class
End Namespace
