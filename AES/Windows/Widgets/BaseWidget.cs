using System;
using Gtk;

namespace Publisher.Windows.Widgets
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class BaseWidget : Gtk.Bin
	{
		public Window Window {
			get; set;
		}

		public BaseWidget ()
		{
			 
		}


		public void Alert (string msg) {
			MessageDialog dialog = new MessageDialog (Window, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, msg);
			dialog.WindowPosition = WindowPosition.Center;
			if (dialog.Run () == (int)ResponseType.Ok) {

			}
			dialog.Destroy ();
		}
	}
}

