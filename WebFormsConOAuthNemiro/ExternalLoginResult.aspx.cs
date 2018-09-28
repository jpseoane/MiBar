using Nemiro.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsConOAuthNemiro
{
    public partial class ExternalLoginResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                    var result = OAuthWeb.VerifyAuthorization();
                    Response.Write(String.Format("Provider: {0}<br />", result.ProviderName));
                if (result.IsSuccessfully)
                {
                    // successfully
                    var user = result.UserInfo;
                    Response.Write(String.Format("User ID:  {0}<br />", user.UserId));
                    Response.Write(String.Format("Name:     {0}<br />", user.DisplayName));
                    Response.Write(String.Format("Email:    {0}", user.Email));
                }
                else
                {
                    // error
                    Response.Write(result.ErrorInfo.Message);
                }
            }
        }
    }
}