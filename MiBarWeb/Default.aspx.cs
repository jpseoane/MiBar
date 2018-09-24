using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiBarWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string nombreUsuario = " ";

            nombreUsuario = Session["userName"].ToString();

            TextoHttp.InnerText= Session["userName"].ToString();
            

        }
    }
}