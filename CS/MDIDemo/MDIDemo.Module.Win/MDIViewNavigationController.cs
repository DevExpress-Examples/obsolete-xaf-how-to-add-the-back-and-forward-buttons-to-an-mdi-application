using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.NodeWrappers;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Utils;
using System.Windows.Forms;

namespace MDIDemo.Win {
	public partial class MDIViewNavigationController : WindowController {
		private const int HistoryDepth = 10;
		private NavigationHistory<ViewShortcut> navigationHistory;
		private bool isNavigating = false;
		private Form MDIParent;
		private ViewShortcut currentShortcut;

		protected override void OnActivated() {
			base.OnActivated();
			Window.TemplateChanged += new EventHandler(Window_TemplateChanged);
		}
		protected override void OnDeactivating() {
			base.OnDeactivating();
			Window.TemplateChanged -= new EventHandler(Window_TemplateChanged);
			ResetMDIParent(null);
		}		
		private void Window_TemplateChanged(object sender, EventArgs e) {
			if(Window.Template != null) {
				ResetMDIParent((Form)Window.Template);
			}
		}
		private void MDIViewNavigationController_MdiChildActivate(object sender, EventArgs e) {
			CheckAndDeleteUnexistingItems();
			UpdateHistoryItemsInfo();
			XtraFormTemplateBase newMDIChild = (XtraFormTemplateBase)MDIParent.ActiveMdiChild;
			if(newMDIChild != null && newMDIChild.View != null) {
				DevExpress.ExpressApp.View currentView = newMDIChild.View;
				currentShortcut = currentView.CreateShortcut();
				if(!isNavigating) {
					navigationHistory.Add(GetViewCaption(currentView), GetImageName(currentView), currentView.CreateShortcut());
				}
			}
			RefreshActionsState();
		}
		private void mdiForwardAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			SingleChoiceAction action = sender as SingleChoiceAction;
			int indexOfAction = action.Items.IndexOf(e.SelectedChoiceActionItem);
			NavigateTo(navigationHistory.CurrentPositionIndex + indexOfAction + 1);
		}
		private void mdiBackAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			SingleChoiceAction action = sender as SingleChoiceAction;
			int indexOfAction = action.Items.IndexOf(e.SelectedChoiceActionItem);
			NavigateTo(navigationHistory.CurrentPositionIndex - indexOfAction - 1);
		}
		private void ResetMDIParent(Form form) {
			if(MDIParent != null) {
				MDIParent.MdiChildActivate -= new EventHandler(MDIViewNavigationController_MdiChildActivate);
			}
			MDIParent = form;
			if(MDIParent != null) {
				MDIParent.MdiChildActivate += new EventHandler(MDIViewNavigationController_MdiChildActivate);
			}
		}
		private string GetViewCaption(DevExpress.ExpressApp.View view) {
			string caption = view.Caption;
			if(view is DetailView && !string.IsNullOrEmpty(view.GetCurrentObjectCaption())) {
				caption = view.GetCurrentObjectCaption();
			}
			return caption;
		}
		private string GetImageName(DevExpress.ExpressApp.View view) {
			return (view.Info != null) ? view.Info.GetAttributeValue(VisualItemInfoNodeWrapper.ImageNameAttribute) : null;
		}
		private XtraFormTemplateBase FindFormByViewShortcut(ViewShortcut shortcut) {
			foreach(XtraFormTemplateBase child in MDIParent.MdiChildren) {
				if(child.View != null) {
					if(child.View.CreateShortcut().Equals(currentShortcut)) {
						return child;
					}
				}
			}
			return null;
		}
		private void CheckAndDeleteUnexistingItems() {
			bool wasRemoved = FindFormByViewShortcut(currentShortcut) == null;
			if(wasRemoved) {
				DeleteFromNavigationHistory(currentShortcut);
			}
		}
		private void DeleteFromNavigationHistory(ViewShortcut shortcut) {
			int currentPositionIndex = navigationHistory.CurrentPositionIndex;
			int deletedPositionIndex;
			while((deletedPositionIndex = navigationHistory.IndexOf(shortcut)) != -1) {
				navigationHistory.CurrentPositionIndex = deletedPositionIndex;
				navigationHistory.DeleteCurrentItem();
				currentPositionIndex = (deletedPositionIndex > currentPositionIndex) ? currentPositionIndex : currentPositionIndex - 1;
				if(navigationHistory.CurrentPositionIndex > -1 && navigationHistory.Count > navigationHistory.CurrentPositionIndex + 1) {
					HistoryItem<ViewShortcut> nextItem = navigationHistory.CurrentPosition;
					navigationHistory.CurrentPositionIndex++;
					HistoryItem<ViewShortcut> previuosItem = navigationHistory.CurrentPosition;
					if(nextItem.Item.Equals(previuosItem.Item)) {
						navigationHistory.DeleteCurrentItem();
						currentPositionIndex = (navigationHistory.CurrentPositionIndex > currentPositionIndex) ? currentPositionIndex : currentPositionIndex - 1;
					}
				}

			}
			navigationHistory.CurrentPositionIndex = (currentPositionIndex < 0) ? 0 : currentPositionIndex;
		}
		private void UpdateHistoryItemsInfo() {
			XtraFormTemplateBase page = FindFormByViewShortcut(currentShortcut);
			if(page != null && page.View != null && page.View is DetailView) {
				int currentPositionIndex = navigationHistory.CurrentPositionIndex;
				navigationHistory.CurrentPositionIndex = -1;
				while(navigationHistory.CanForward) {
					navigationHistory.Forward();
					if(navigationHistory.CurrentPosition.Item.Equals(currentShortcut)) {
						navigationHistory.UpdateCurrentItem(GetViewCaption(page.View), GetImageName(page.View), page.View.CreateShortcut());
					}
				}
				navigationHistory.CurrentPositionIndex = currentPositionIndex;
			}
		}
		private void UpdateActionsItems() {
			List<HistoryItem<ViewShortcut>> list = new List<HistoryItem<ViewShortcut>>();
			foreach(HistoryItem<ViewShortcut> item in navigationHistory) {
				list.Add(item);
			}

			int currentIndex = navigationHistory.CurrentPositionIndex;
			mdiBackAction.Items.Clear();
			int count = 0;
			while(++count <= HistoryDepth && navigationHistory.CanBack) {
				navigationHistory.Back();
				VisualItemInfoNodeWrapper info = new VisualItemInfoNodeWrapper(new DictionaryNode(""));
				info.Caption = list[currentIndex - count].Caption;
				info.ImageName = list[currentIndex - count].ImageName;
				mdiBackAction.Items.Add(new ChoiceActionItem(info.Node, list[currentIndex - count].Item));
			}
			if(mdiBackAction.Items.Count > 0) {
				mdiBackAction.SelectedIndex = 0;
			}
			navigationHistory.CurrentPositionIndex = currentIndex;

			mdiForwardAction.Items.Clear();
			count = 0;
			while(++count <= HistoryDepth && navigationHistory.CanForward) {
				navigationHistory.Forward();
				VisualItemInfoNodeWrapper info = new VisualItemInfoNodeWrapper(new DictionaryNode(""));
				info.Caption = list[currentIndex + count].Caption;
				info.ImageName = list[currentIndex + count].ImageName;
				mdiForwardAction.Items.Add(new ChoiceActionItem(info.Node, list[currentIndex + count].Item));
			}
			if(mdiForwardAction.Items.Count > 0) {
				mdiForwardAction.SelectedIndex = 0;
			}
			navigationHistory.CurrentPositionIndex = currentIndex;
		}
		private void RefreshActionsState() {
			mdiBackAction.Enabled.SetItemValue("Can back", navigationHistory.CanBack);
			mdiForwardAction.Enabled.SetItemValue("Can forward", navigationHistory.CanForward);
			UpdateActionsItems();
		}
		private void NavigateTo(int historyItemIndex) {
			navigationHistory.CurrentPositionIndex = historyItemIndex;
			ViewShortcut viewShortcut = navigationHistory.CurrentPosition.Item;
			isNavigating = true;
			try {
				foreach(XtraFormTemplateBase child in MDIParent.MdiChildren) {
					if(child.View.CreateShortcut().Equals(viewShortcut)) {
						child.Activate();
						break;
					}
				}
			}
			finally {
				isNavigating = false;
			}
			RefreshActionsState();
		}		
		public MDIViewNavigationController() {
			InitializeComponent();
			RegisterActions(components);
			navigationHistory = new NavigationHistory<ViewShortcut>();
		}		
	}
}
