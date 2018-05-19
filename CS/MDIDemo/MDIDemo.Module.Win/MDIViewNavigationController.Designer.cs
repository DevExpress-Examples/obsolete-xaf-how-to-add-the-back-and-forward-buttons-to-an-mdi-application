namespace MDIDemo.Win
{
    partial class MDIViewNavigationController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mdiBackAction = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.mdiForwardAction = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // mdiBackAction
            // 
            this.mdiBackAction.Caption = "Back";
            this.mdiBackAction.Category = "MDINavigation";
            this.mdiBackAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable;
            this.mdiBackAction.Id = "MDINavigateBack";
            this.mdiBackAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.mdiBackAction.Tag = null;
            this.mdiBackAction.TypeOfView = null;
            this.mdiBackAction.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.mdiBackAction_Execute);
            // 
            // mdiForwardAction
            // 
            this.mdiForwardAction.Caption = "Forward";
            this.mdiForwardAction.Category = "MDINavigation";
            this.mdiForwardAction.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.Disable;
            this.mdiForwardAction.Id = "MDINavigateForward";
            this.mdiForwardAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.mdiForwardAction.Tag = null;
            this.mdiForwardAction.TypeOfView = null;
            this.mdiForwardAction.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.mdiForwardAction_Execute);
            // 
            // MDIViewNavigationController
            // 
            this.TargetWindowType = DevExpress.ExpressApp.WindowType.Main;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction mdiBackAction;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction mdiForwardAction;
    }
}
