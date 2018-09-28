using Nemiro.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsConOAuthNemiro
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) {
                var result = OAuthWeb.VerifyAuthorization();

                if (result.IsSuccessfully)
                {
                
                }
                //else
                //{
                //    // error
                //    Response.Write(result.ErrorInfo.Message);
                //}
            }
        }


        protected void RedirectToLogin_Click(object sender, EventArgs e)
        {
            // gets a provider name from the data-provider
            string provider = ((LinkButton)sender).Attributes["data-provider"];
            // build the return address
            string returnUrl = new Uri(Request.Url, "ExternalLoginResult.aspx").AbsoluteUri;
            //
            // redirect user into external site for authorization
            OAuthWeb.RedirectToAuthorization(provider, returnUrl);
        }
    }
}