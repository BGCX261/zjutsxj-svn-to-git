using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = Context.Request.Url.ToString();
            Regex re = new Regex(@"(&|)page=\d+", RegexOptions.Compiled);
            url = re.Replace(url,string.Empty);
            url = url.Replace("?&", "?");
            Response.Write(url);
        }
    }
}
