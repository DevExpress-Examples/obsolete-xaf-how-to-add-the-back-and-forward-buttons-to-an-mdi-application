<!-- default file list -->
*Files to look at*:

* [MDIViewNavigationController.cs](./CS/MDISolution.Module.Win/Controllers/MDIViewNavigationController.cs) (VB: [MDIViewNavigationController.vb](./VB/MDISolution.Module.Win/Controllers/MDIViewNavigationController.vb))
<!-- default file list end -->
# OBSOLETE - How to Add the Back and Forward Buttons to an MDI Application


<p><strong>=================================</strong><br /><strong>This article is obsolete starting with v10.1. Use the built-in feature of the Document Manager component instead: <a href="https://documentation.devexpress.com/#windowsforms/CustomDocument11362">Document Selector</a> </strong><br /><strong>=================================</strong><br />The built-in Back and Forward Actions allow end-users to navigate between previously invoked Views. These Actions are contained in the DevExpress.ExpressApp.SystemModule.ViewNavigationController. This Controller is not intended for use in applications with MDI strategy, because it collects a history of Views invoked in the application's main Window. In an MDI application, the main Window doesn't have any View; all Views are displayed in child Windows. So, the Back and Forward Actions are always disabled.</p>
<p>This example demonstrates how to create a custom WindowController that contains navigation Actions collecting Views from invoked MDI child forms. For details on this example, refer to the <a href="https://www.devexpress.com/Support/Center/p/K18067">OBSOLETE - How to Add the Back and Forward Buttons to an MDI Application</a> article.</p>

<br/>


