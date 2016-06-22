
using System;
using System.Diagnostics;
using System.Text;
using Gtk;
using Newtonsoft.Json;
using Publisher.Core;

namespace Publisher.Windows.Widgets
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class ResultWidget : BaseWidget
	{
		const string password = "qwe123123qwe1231";
		public event EventHandler OnPreClick;
		UpdateInfo updateInfo;

		public ResultWidget (UpdateInfo updateInfo)
		{
			this.updateInfo = updateInfo;
			this.Build ();
			labelTitle.Markup = "<span size='38000' color='red' >卍发布代码成功生成!卍</span>";
			//labelUrl1.Markup = "<span color='blue' underline='single'>http://blog.sina.com.cn/s/blog_162f498920102wjlt.html</span>";
			//labelUrl2.Markup = "<span color='blue' underline='single'>http://blog.163.com/m13025967952_1/blog/static/26233017920165141416578/</span>";
			//labelUrl3.Markup = "<span color='blue' underline='single'>http://23assaas.blog.sohu.com/322098044.html</span>";

			//labelUrl1.ButtonPressEvent += Link_Press;
			LinkButton link1 = new LinkButton ("http://blog.sina.com.cn/s/blog_162f498920102wjlt.html");
			vbox2.Add (link1);
			link1.Show ();
			link1.Clicked += Link_Press;
			LinkButton link2 = new LinkButton ("http://blog.163.com/m13025967952_1/blog/static/26233017920165141416578/");
			vbox2.Add (link2);
			link2.Show ();
			link2.Clicked += Link_Press;
			LinkButton link3 = new LinkButton ("http://23assaas.blog.sohu.com/322098044.html");
			vbox2.Add (link3);
			link3.Show ();
			link3.Clicked += Link_Press;
			btnPre.Clicked += BtnPre_Clicked;
			btnCopy.Clicked += BtnCopy_Clicked;

			txtResult.WrapMode = WrapMode.WordChar;
			string json = JsonConvert.SerializeObject (updateInfo);
			txtResult.Buffer.Text = AesEncrypt (json, password);
		}


		public void BtnCopy_Clicked (object sender, EventArgs e)
		{
			Gtk.Clipboard clipboard = Gtk.Clipboard.Get (Gdk.Atom.Intern ("CLIPBOARD", false));
			clipboard.Text = txtResult.Buffer.Text;
			Alert ("复制成功");
		}

		public void BtnPre_Clicked (object sender, EventArgs e)
		{
			if (OnPreClick != null) {
				OnPreClick (sender, e);
			}
		}

		void Link_Press (object o, EventArgs args)
		{
			var linkBtn = o as LinkButton;
			var os = SystemManager.GetOperatingSystem ();
			Process.Start (linkBtn.Uri.ToString ());

		}

		/// <summary>
		///  AES 加密
		/// </summary>
		/// <param name="str"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string AesEncrypt (string str, string key)
		{
			if (string.IsNullOrEmpty (str)) return null;
			Byte [] toEncryptArray = Encoding.UTF8.GetBytes (str);

			System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged {
				Key = Encoding.UTF8.GetBytes (key),
				Mode = System.Security.Cryptography.CipherMode.ECB,
				Padding = System.Security.Cryptography.PaddingMode.PKCS7
			};

			System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateEncryptor ();
			Byte [] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);

			return Convert.ToBase64String (resultArray, 0, resultArray.Length);
		}
	}
}

