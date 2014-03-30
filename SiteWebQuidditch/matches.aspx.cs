using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebQuidditch
{
    public partial class matches : System.Web.UI.Page
    {
        public string matchesObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference.ServiceQuiddichClient service = new ServiceReference.ServiceQuiddichClient();
            try
            {
                if (Request.QueryString["cid"].Trim() != "")
                {
                    matchesObject = new JavaScriptSerializer().Serialize(service.GetMatchesOfCoupe(Convert.ToInt32(Request.QueryString["cid"])));
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}