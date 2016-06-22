using System;
using Gtk;
using Publisher.Windows;

namespace AES
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			Application.Init ();
			WinPublisher win = new WinPublisher ();
			win.Show ();
			Application.Run ();
		}
	}
}
