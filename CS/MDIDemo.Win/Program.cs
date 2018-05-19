using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace MDIDemo.Win
{
    static class Program
    {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
			MDIDemoWindowsFormsApplication application = new MDIDemoWindowsFormsApplication();
			application.CreateCustomTemplate += new EventHandler<CreateCustomTemplateEventArgs>(Manager_CreateCustomTemplate);
			if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			try {
				application.ShowViewStrategy = new MDIStrategy(application);
				application.Setup();
				application.Start();
			}
			catch (Exception e) {
				application.HandleException(e);
			}
		}

        static void Manager_CreateCustomTemplate(object sender, CreateCustomTemplateEventArgs e)
        {
            if (e.Context == TemplateContext.ApplicationWindow)
            {
                e.Template = new MDIMainForm();
            }
            else
            {
                if (e.Context == TemplateContext.View)
                {
                    e.Template = new MDIChildForm();
                }
                else
                {
                    e.Template = null;
                }
            }
        }
    }
}
