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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        void BindGridView()
        {
            GridView1.DataSource = Columns.GridViewSource();
            GridView1.DataBind();
        }
        /// <summary>
        /// 上移
        /// </summary>
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Columns move = new Columns();
            move.Manage_Id = Convert.ToInt16(e.CommandArgument);
            move.MoveUp();
            BindGridView();
        }
        /// <summary>
        /// 下移
        /// </summary>
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            Columns move = new Columns();
            move.Manage_Id = Convert.ToInt16(e.CommandArgument);
            move.MoveDown();
            BindGridView();
        }
        /// <summary>
        /// 删除
        /// </summary>
        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            Columns.RemoveData(Convert.ToInt16(e.CommandArgument));
            BindGridView();
        }
    }
}
