using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Gtk;
using Publisher.Windows;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		txtIV.Text = "qwe123123qwe1231";
		txtKey.Text = "qwe123123qwe1231";
		txtSource.Buffer.Text = @"{
    ""version"": 1.2,
    ""memo"": ""1,修改已知bug\r\n,2,优化加载速度"",
    ""published"":false,
    ""download"": ""http://www.mc6h.com/lhhelper_v1.2.apk""
}";
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public void BtnDo_Clicked (object sender, EventArgs e)
	{
		WinPublisher publisher = new WinPublisher ();
		publisher.Show ();
		txtCode.Buffer.Text = AesEncrypt (txtSource.Buffer.Text, txtKey.Text);

		//MessageDialog dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "点击了");

		//dialog.Show ();
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

	/// <summary>
	///  AES 解密
	/// </summary>
	/// <param name="str"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	public static string AesDecrypt (string str, string key)
	{
		if (string.IsNullOrEmpty (str)) return null;
		Byte [] toEncryptArray = Convert.FromBase64String (str);

		System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged {
			Key = Encoding.UTF8.GetBytes (key),
			Mode = System.Security.Cryptography.CipherMode.ECB,
			Padding = System.Security.Cryptography.PaddingMode.PKCS7
		};

		System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor ();
		Byte [] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);

		return Encoding.UTF8.GetString (resultArray);
	}

}
