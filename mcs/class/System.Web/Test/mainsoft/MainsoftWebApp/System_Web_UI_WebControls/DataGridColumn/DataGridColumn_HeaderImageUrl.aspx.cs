//
// Authors:
//   Rafael Mizrahi   <rafim@mainsoft.com>
//   Erez Lotan       <erezl@mainsoft.com>
//   Vladimir Krasnov <vladimirk@mainsoft.com>
//
//
// Copyright (c) 2002-2005 Mainsoft Corporation.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GHTTests.System_Web_dll.System_Web_UI_WebControls
{
	public class DataGridColumn_HeaderImageUrl
		: GHTBaseWeb 
	{
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) 
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		#region "Template Classes"
		public class t_DBLitTemplate : ITemplate
		{
			public void InstantiateIn(Control container)
			{
				Literal literal1 = new Literal();
				literal1.Text = "<div>";
				literal1.DataBinding += new EventHandler(this.BindData);
				container.Controls.Add(literal1);
			}
			public void BindData(object sender, EventArgs e)
			{
				Literal literal1 = (Literal) sender;
				DataGridItem item1 = (DataGridItem) literal1.NamingContainer;
				literal1.Text = DataBinder.Eval(item1.DataItem, "Name") + "</div>";
			}
		}
		public class t_EmptyLitTemplate : ITemplate
		{
			public void InstantiateIn(Control container)
			{
				Literal literal1 = new Literal();
				literal1.Text = "";
				container.Controls.Add(literal1);
			}
		}
		public class t_PlainTextLitTemplate : ITemplate
		{
			public void InstantiateIn(Control container)
			{
				Literal literal1 = new Literal();
				literal1.Text = "Plain text template create at run time";
				container.Controls.Add(literal1);
			}
		}
		public class t_HtmlLitTemplate : ITemplate
		{
			public void InstantiateIn(Control container)
			{
				Literal literal1 = new Literal();
				literal1.Text = "<div><b><i>Html template created at run time</i></b></div>";
				container.Controls.Add(literal1);
			}
		}
		public class t_ControlLitTemplate : ITemplate
		{
			public void InstantiateIn(Control container)
			{
				HtmlInputButton button1 = new HtmlInputButton();
				button1.Value = "Control template";
				container.Controls.Add(button1);
			}
		}
		#endregion

		#region "DataGrid creation functions"
		private void setText(DataGridColumn c, ListItemType tp, string text)
		{
			switch (tp)
			{
				case ListItemType.Header:
				{
					c.HeaderText = text;
					return;
				}
				case ListItemType.Footer:
				{
					c.FooterText = text;
					return;
				}
			}
		}
 
		private void setStyle(DataGridColumn c, ListItemType tp)
		{
			switch (tp)
			{
				case ListItemType.Header:
				{
					c.HeaderStyle.VerticalAlign = VerticalAlign.Top;
					c.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
					c.HeaderStyle.Wrap = false;
					return;
				}
				case ListItemType.Footer:
				{
					c.FooterStyle.VerticalAlign = VerticalAlign.Top;
					c.FooterStyle.HorizontalAlign = HorizontalAlign.Right;
					c.FooterStyle.Wrap = false;
					return;
				}
				case ListItemType.Item:
				{
					c.ItemStyle.VerticalAlign = VerticalAlign.Top;
					c.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
					c.ItemStyle.Wrap = false;
					return;
				}
			}
		}
 
		private DataGridColumn c_bounded(string se)
		{
			BoundColumn column1 = new BoundColumn();
			column1.DataField = "ID";
			column1.HeaderImageUrl = se;
			return column1;
		}
 
		private DataGridColumn c_button(string se)
		{
			ButtonColumn column1 = new ButtonColumn();
			column1.DataTextField = "ID";
			column1.HeaderImageUrl = se;
			return column1;
		}
 
		private DataGridColumn c_hyper_link(string se)
		{
			HyperLinkColumn column1 = new HyperLinkColumn();
			column1.DataTextField = "ID";
			column1.NavigateUrl = "http://www.example.com";
			column1.HeaderImageUrl = se;
			return column1;
		}
 
		private DataGridColumn c_edit(string se)
		{
			EditCommandColumn column1 = new EditCommandColumn();
			column1.EditText = "Edit";
			column1.HeaderImageUrl = se;
			return column1;
		}
 
		private DataGridColumn c_template(string se)
		{
			TemplateColumn column1 = new TemplateColumn();
			column1.ItemTemplate = new DataGridColumn_HeaderImageUrl.t_DBLitTemplate();
			column1.HeaderImageUrl = se;
			return column1;
		}
		private void DataGridTest(string TestName, DataGridColumn c)
		{
			DataGrid grid1 = new DataGrid();
			this.GHTSubTestBegin(TestName);
			try
			{
				grid1.Columns.Add(c);
				grid1.DataSource = GHTTests.GHDataSources.DSDataTable();
				grid1.ShowFooter = true;
				grid1.DataBind();
				base.GHTActiveSubTest.Controls.Add(grid1);
				this.GHTSubTestAddResult(grid1.Columns[0].HeaderImageUrl);
			}
			catch (Exception exception2)
			{
				// ProjectData.SetProjectError(exception2);
				Exception exception1 = exception2;
				this.GHTSubTestUnexpectedExceptionCaught(exception1);
				grid1 = null;
				//ProjectData.ClearProjectError();
			}
			this.GHTSubTestEnd();
		}
 
		#endregion

		private void Page_Load(object sender, System.EventArgs e) 
		{
			//Put user code to initialize the page here

			System.Web.UI.HtmlControls.HtmlForm frm = (HtmlForm)this.FindControl("Form1");
			GHTTestBegin(frm);

			DataGridTest("GhtSubTest1", c_bounded(""));
			DataGridTest("GhtSubTest2", c_button(""));
			DataGridTest("GhtSubTest3", c_edit(""));
			DataGridTest("GhtSubTest4", c_hyper_link(""));
			DataGridTest("GhtSubTest5", c_template(""));
			DataGridTest("GhtSubTest6", c_bounded("/images/pic.gif"));
			DataGridTest("GhtSubTest7", c_button("/images/pic.gif"));
			DataGridTest("GhtSubTest8", c_edit("/images/pic.gif"));
			DataGridTest("GhtSubTest9", c_hyper_link("/images/pic.gif"));
			DataGridTest("GhtSubTest10", c_template("/images/pic.gif"));
			DataGridTest("GhtSubTest11", c_bounded("http://127.0.0.1/asd/asd/../../asd.asd"));
			DataGridTest("GhtSubTest12", c_button("http://127.0.0.1/asd/asd/../../asd.asd"));
			DataGridTest("GhtSubTest13", c_edit("http://127.0.0.1/asd/asd/../../asd.asd"));
			DataGridTest("GhtSubTest14", c_hyper_link("http://127.0.0.1/asd/asd/../../asd.asd"));
			DataGridTest("GhtSubTest15", c_template("http://127.0.0.1/asd/asd/../../asd.asd"));
			DataGridTest("GhtSubTest16", c_bounded(@"asdd://asd?//.\.\.\././..\/\/\/\/././zxc.zxc"));
			DataGridTest("GhtSubTest17", c_button(@"asdd://asd?//.\.\.\././..\/\/\/\/././zxc.zxc"));
			DataGridTest("GhtSubTest18", c_edit(@"asdd://asd?//.\.\.\././..\/\/\/\/././zxc.zxc"));
			DataGridTest("GhtSubTest19", c_hyper_link(@"asdd://asd?//.\.\.\././..\/\/\/\/././zxc.zxc"));
			DataGridTest("GhtSubTest20", c_template(@"asdd://asd?//.\.\.\././..\/\/\/\/././zxc.zxc"));


			GHTTestEnd();
		}
	}
}
