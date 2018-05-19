Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection


Namespace MDIDemo.Module
    Public NotInheritable Partial Class MDIDemoModule
        Inherits ModuleBase
        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Function GetAdditionalBusinessClassAssemblies() As IList(Of System.Reflection.Assembly)
            Return New System.Reflection.Assembly() { GetType(DevExpress.Persistent.BaseImpl.Person).Assembly }
        End Function
    End Class
End Namespace
