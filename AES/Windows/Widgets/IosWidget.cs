using System;
using Publisher.Core;

namespace Publisher.Windows.Widgets
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class IosWidget : BaseWidget
	{
		public event EventHandler OnPreClick;
		public event EventHandler OnNextClick;

		AppVersionInfo versionInfo;
		public IosWidget (AppVersionInfo versionInfo)
		{
			this.versionInfo = versionInfo;
			this.Build ();
			btnNext.Clicked += BtnNext_Clicked;
			btnPre.Clicked += BtnPre_Clicked;
			cbPublished.Active = versionInfo.published;
			txtMemo.Buffer.Text = versionInfo.memo;
			txtVersion.Text = (versionInfo.version > 0 ? versionInfo.version.ToString () : "");
			txtDownloadAddress.Text = versionInfo.download;

		}

		public void BtnNext_Clicked (object sender, EventArgs e)
		{
			string version = txtVersion.Text;
			string downloadAddress = txtDownloadAddress.Text;
			string memo = txtMemo.Buffer.Text;
			if (string.IsNullOrEmpty (version)) {
				Alert ("请填写版本号");
				return;
			}
			double versionValue = 0;
			if (!double.TryParse (version, out versionValue)) {
				Alert ("版本号解析错误,请使用数字版本号");
				return;
			}
			if (string.IsNullOrEmpty (memo)) {
				Alert ("请填写更新内容");
				return;
			}
			versionInfo.download = downloadAddress;
			versionInfo.md5 = "";
			versionInfo.memo = memo;
			versionInfo.version = versionValue;
			versionInfo.published = cbPublished.Active;
			if (OnNextClick != null) {
				OnNextClick (sender, e);
			}
		}

		public void BtnPre_Clicked (object sender, EventArgs e)
		{
			if (OnPreClick != null) {
				OnPreClick (sender, e);
			}
		}
	}
}

