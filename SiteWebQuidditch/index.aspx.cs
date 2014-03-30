using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebQuidditch
{
    public partial class index : System.Web.UI.Page
    {
        public string coupes;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference.ServiceQuiddichClient service = new ServiceReference.ServiceQuiddichClient();
            coupes = "";
            foreach (var coupe in service.GetAllCoupes()) 
            {
                coupes += "<li><a href=\"matches.aspx?cid=" + coupe.Id + "\" > " + coupe.Label + " </a></li>";
            }
        }
    }
}