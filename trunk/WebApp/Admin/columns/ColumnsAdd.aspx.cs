using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WxSpace;

namespace WebApp.Admin.system
{
    public partial class ManageAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        void BindDropDownList()
        {
            Manage_ParentId.DataTextField = "Manage_Name";
            Manage_ParentId.DataValueField = "Manage_Id";
            Manage_ParentId.DataSource = Columns.DropDownListSource();
            Manage_ParentId.DataBind();
            Manage_ParentId.Items.Insert(0, new ListItem("选择栏目", "0"));
            Manage_ParentId.SelectedValue = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int Error;
            Columns insert = new Columns();
            insert.Manage_CollapseImage = Manage_CollapseImage.Text.ToString();
            insert.Manage_Name = Manage_Name.Text.ToString();
            insert.Manage_OpenImage = Manage_OpenImage.Text.ToString();
            insert.Manage_ParentId = Convert.ToInt16(Manage_ParentId.SelectedValue);
            insert.Manage_Show = Convert.ToBoolean(Manage_Show.SelectedValue);
            insert.Manage_Target = Manage_Target.Text.ToString();
            insert.Manage_Url = Manage_Url.Text.ToString();
            Error = insert.AddData();
            if (Error != 1)
            {
                Response.Write(Error.ToString());
                return;
            }
            Response.Redirect("Default.aspx", true);
        }
    }
}
