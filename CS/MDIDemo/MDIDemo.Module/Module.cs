using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;


namespace MDIDemo.Module
{
    public sealed partial class MDIDemoModule : ModuleBase
    {
        public MDIDemoModule()
        {
            InitializeComponent();
        }
        protected override IList<System.Reflection.Assembly> GetAdditionalBusinessClassAssemblies()
        {
            return new System.Reflection.Assembly[] { 
				typeof(DevExpress.Persistent.BaseImpl.Person).Assembly };
        }
    }
}
