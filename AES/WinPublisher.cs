using System;
namespace AES
{
	public partial class WinPublisher : Gtk.Window
	{
		public WinPublisher () :
				base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

