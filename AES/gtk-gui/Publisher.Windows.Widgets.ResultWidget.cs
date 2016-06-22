
// This file has been generated by the GUI designer. Do not modify.
namespace Publisher.Windows.Widgets
{
	public partial class ResultWidget
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label labelTitle;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Label label4;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView txtResult;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.Button btnCopy;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button btnPre;

		private global::Gtk.Button btnNext;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Publisher.Windows.Widgets.ResultWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Publisher.Windows.Widgets.ResultWidget";
			// Container child Publisher.Windows.Widgets.ResultWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.labelTitle = new global::Gtk.Label();
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.LabelProp = global::Mono.Unix.Catalog.GetString("TITLE");
			this.hbox2.Add(this.labelTitle);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.labelTitle]));
			w1.Position = 0;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("生成结果: ");
			this.vbox4.Add(this.label4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.label4]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txtResult = new global::Gtk.TextView();
			this.txtResult.CanFocus = true;
			this.txtResult.Name = "txtResult";
			this.GtkScrolledWindow.Add(this.txtResult);
			this.vbox4.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.GtkScrolledWindow]));
			w5.Position = 1;
			this.hbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox4]));
			w6.Position = 0;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w7.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(200));
			this.alignment1.RightPadding = ((uint)(200));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.btnCopy = new global::Gtk.Button();
			this.btnCopy.CanFocus = true;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.UseUnderline = true;
			this.btnCopy.Label = global::Mono.Unix.Catalog.GetString("复制结果");
			this.alignment1.Add(this.btnCopy);
			this.vbox1.Add(this.alignment1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w10.Position = 3;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnPre = new global::Gtk.Button();
			this.btnPre.CanFocus = true;
			this.btnPre.Name = "btnPre";
			this.btnPre.UseUnderline = true;
			this.btnPre.Label = global::Mono.Unix.Catalog.GetString("上一步");
			this.hbox4.Add(this.btnPre);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.btnPre]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnNext = new global::Gtk.Button();
			this.btnNext.Sensitive = false;
			this.btnNext.CanFocus = true;
			this.btnNext.Name = "btnNext";
			this.btnNext.UseUnderline = true;
			this.btnNext.Label = global::Mono.Unix.Catalog.GetString("下一步");
			this.hbox4.Add(this.btnNext);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.btnNext]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}