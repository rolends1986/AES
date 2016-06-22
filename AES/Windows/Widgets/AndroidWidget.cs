using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Gtk;
using Publisher.Core;

namespace Publisher.Windows.Widgets
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class AndroidWidget : BaseWidget
	{

		AppVersionInfo versionInfo;
		public event EventHandler OnNextClick;
		public AndroidWidget (AppVersionInfo versionInfo)
		{
			this.versionInfo = versionInfo;
			this.Build ();
			txtMemo.Buffer.Text = versionInfo.memo;
			txtVersion.Text = (versionInfo.version > 0 ? versionInfo.version.ToString () : "");
			txtApkAddress.Text = versionInfo.download;
			txtMd5.Text = versionInfo.md5;
			btnNext.Clicked += BtnNext_Clicked;
			btnSelectFile.Clicked += BtnSelectFile_Clicked;
		}


		public void BtnSelectFile_Clicked (object sender, EventArgs e)
		{
			Gtk.FileChooserDialog filechooser =
				new Gtk.FileChooserDialog ("选择APK文件",
					Window,
					FileChooserAction.Open,
					"取消", ResponseType.Cancel,
					"选择", ResponseType.Accept);
			var filter = new FileFilter ();
			filter.Name = "APK文件";
			filter.AddPattern ("*.apk");
			filechooser.AddFilter (filter);
			if (filechooser.Run () == (int)ResponseType.Accept) {
				string fileName = filechooser.Filename;
				if (string.IsNullOrEmpty (fileName)) {
					Alert ("请选择APK文件");
					return;
				}
				if (!File.Exists (fileName)) {
					Alert ("APK文件地址不存在");
					return;
				}
				string fileMd5 = "";
				using (var md5 = MD5.Create ()) {
					using (var stream = File.OpenRead (fileName)) {
						fileMd5 = BitConverter.ToString (md5.ComputeHash (stream)).Replace ("-", "").ToLower ();
					}
				}
				if (string.IsNullOrEmpty (fileMd5)) {
					Alert ("文件md5值计算错误");
					return;
				}
				txtMd5.Text = fileMd5;
			}
			filechooser.Destroy ();
		}

		public void BtnNext_Clicked (object sender, EventArgs e)
		{

			string version = txtVersion.Text;
			string apkAddress = txtApkAddress.Text;
			string memo = txtMemo.Buffer.Text;
			string fileMd5 = txtMd5.Text;
			if (string.IsNullOrEmpty (version)) {
				Alert ("请填写版本号");
				return;
			}
			double versionValue = 0;
			if (!double.TryParse (version, out versionValue)) {
				Alert ("版本号解析错误,请使用数字版本号");
				return;
			}
			if (string.IsNullOrEmpty (apkAddress)) {
				Alert ("请填写APK文件下载地址");
				return;
			}
			if (string.IsNullOrEmpty (memo)) {
				Alert ("请填写更新内容");
				return;
			}
			if (string.IsNullOrEmpty (fileMd5)) {
				Alert ("请选择APK文件");
				return;
			}
			versionInfo.download = apkAddress;
			versionInfo.md5 = fileMd5;
			versionInfo.memo = memo;
			versionInfo.version = versionValue;
			versionInfo.published = true;
			if (OnNextClick != null) {
				OnNextClick (sender, e);
			}
		}
	}
}

