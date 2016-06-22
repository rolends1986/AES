using System;
namespace Publisher.Core
{
	public class UpdateInfo
	{
		public UpdateInfo ()
		{
			ios = new AppVersionInfo ();
			android = new AppVersionInfo ();
		}

		public AppVersionInfo ios {
			get;
			set;
		}
		public AppVersionInfo android {
			get;
			set;
		}
	}
}

