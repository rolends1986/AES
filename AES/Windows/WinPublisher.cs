
using System;
using System.IO;
using Gtk;
using Newtonsoft.Json;
using Publisher.Core;
using Publisher.Windows.Widgets;

namespace Publisher.Windows
{
	public partial class WinPublisher : Gtk.Window
	{
		UpdateInfo updateInfo;
		AndroidWidget wgAndroid;
		IosWidget wgIos;
		ResultWidget wgResult;
		public WinPublisher () :
				base (Gtk.WindowType.Toplevel)
		{
			updateInfo = GetUpdateInfo ();
			this.Build ();
			this.Title = "版本发布器";
			wgAndroid = new AndroidWidget (updateInfo.android);
			wgAndroid.Window = this;
			wgIos = new IosWidget (updateInfo.ios);
			wgResult = new ResultWidget (updateInfo);

			wgAndroid.Show ();
			wgIos.Show ();
			wgResult.Show ();

			labelTitle.Markup = "<span size='18000'>第一步[Andorid]/共三步</span>";

			gaContainer.Add (wgAndroid);

			wgAndroid.OnNextClick += Android_NextClick;

			wgIos.OnNextClick += Ios_NextClick;
			wgIos.OnPreClick += Ios_PreClick;
			wgResult.OnPreClick += Result_PreClick;
			 
		}


		protected override void OnShown ()
		{
			base.OnShown ();
			Application.Quit ();
		}

		void Result_PreClick (object sender, EventArgs e)
		{
			labelTitle.Markup = "<span size='18000'>第二步[Ios]/共三步</span>";
			gaContainer.Remove (wgResult);
			gaContainer.Add (wgIos);
		}

		void Ios_PreClick (object sender, EventArgs e)
		{
			labelTitle.Markup = "<span size='18000'>第一步[Andorid]/共三步</span>";
			gaContainer.Remove (wgIos);
			gaContainer.Add (wgAndroid);
		}

		void Ios_NextClick (object sender, EventArgs e)
		{
			labelTitle.Markup = "<span size='18000'>第三步[Andorid]/共三步</span>";
			gaContainer.Remove (wgIos);
			gaContainer.Add (wgResult);
			SetUpdateInfo ();
		}

		void Android_NextClick (object sender, EventArgs e)
		{
			labelTitle.Markup = "<span size='18000'>第二步[Ios]/共三步</span>";
			gaContainer.Remove (wgAndroid);
			gaContainer.Add (wgIos);
			SetUpdateInfo ();
		}


		UpdateInfo GetUpdateInfo ()
		{
			string path = System.IO.Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "result.json");
			if (File.Exists (path)) {
				string json = File.ReadAllText (path);
				return JsonConvert.DeserializeObject<UpdateInfo> (json);
			}
			return new UpdateInfo ();
		}


		void SetUpdateInfo ()
		{
			string path = System.IO.Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "result.json");
			string json = JsonConvert.SerializeObject (updateInfo);
			File.WriteAllText (path, json);
		}

	}
}

