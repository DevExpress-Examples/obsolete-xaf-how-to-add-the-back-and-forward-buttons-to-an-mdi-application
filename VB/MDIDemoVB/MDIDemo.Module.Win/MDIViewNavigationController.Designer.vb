Partial Class MDIViewNavigationController
	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New(ByVal Container As System.ComponentModel.IContainer)
		MyClass.New()

		'Required for Windows.Forms Class Composition Designer support
		Container.Add(Me)

	End Sub

	'Component overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Component Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Component Designer
	'It can be modified using the Component Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.mdiBackAction = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
      Me.mdiForwardAction = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
      '
      'mdiBackAction
      '
      Me.mdiBackAction.Caption = "Back"
      Me.mdiBackAction.Category = "MDINavigation"
      Me.mdiBackAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable
      Me.mdiBackAction.Id = "MDINavigateBack"
      Me.mdiBackAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
      '
      'mdiForwardAction
      '
      Me.mdiForwardAction.Caption = "Forward"
      Me.mdiForwardAction.Category = "MDINavigation"
      Me.mdiForwardAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable
      Me.mdiForwardAction.Id = "MDINavigateForward"
      Me.mdiForwardAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
      '
      'MDIViewNavigationController
      '
      Me.TargetWindowType = DevExpress.ExpressApp.WindowType.Main

   End Sub
   Friend WithEvents mdiBackAction As DevExpress.ExpressApp.Actions.SingleChoiceAction
   Friend WithEvents mdiForwardAction As DevExpress.ExpressApp.Actions.SingleChoiceAction

End Class
