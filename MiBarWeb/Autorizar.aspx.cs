using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiBarWeb
{
    public partial class Autorizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Get the user id from query string  
            //string UserId = Request.QueryString["UserId"];
            //if (UserId != null) //check whether user is null or not  
            //{
            //    if (IsAuthorized(UserId)) //check whether user is already authorized  
            //    {
            //        string EmailId = GetGmailId(UserId); //Get the email id from database  
            //                                             //show the email id in alert  
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + EmailId + "')", true);
            //    }
            //    else
                //{
                    AuthorizeUser("1"); //authorize the user  
                //}
            //}
        }
        /// <summary>    
        /// Return gmail id from database. it will saved in the database after successful authentication.    
        /// </summary>    
        /// <param name="userId"></param>    
        /// <returns></returns>    
        private string GetGmailId(string userId)
        {
            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            string Query = "select GmailId from Member where UserId=" + userId;
            SqlCommand Cmd = new SqlCommand(Query, Con);
            Con.Open();
            string Result = Cmd.ExecuteScalar().ToString();
            Con.Close();
            return Result;
        }
        private bool IsAuthorized(string userId)
        {
            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            string Query = "select count(*) from Member where UserId=" + userId;
            SqlCommand Cmd = new SqlCommand(Query, Con);
            Con.Open();
            int Result = (int)Cmd.ExecuteScalar();
            Con.Close();
            return Result > 0 ? true : false;
        }
        private void AuthorizeUser(string data)
        {
            string Url = GetAuthorizationUrl(data);
            HttpContext.Current.Response.Redirect(Url, false);
        }
        /// <summary>    
        ///     
        /// </summary>    
        /// <param name="data"></param>    
        /// <returns></returns>    
        private string GetAuthorizationUrl(string data)
        {
            string ClientId = ConfigurationManager.AppSettings["ClientId"];
            string Scopes = "https://www.googleapis.com/auth/userinfo.email";
            //get this value by opening your web app in browser.    
            string RedirectUrl = "http://localhost:4143/GoogleCallBack.aspx";
            string Url = "https://accounts.google.com/o/oauth2/auth?";
            StringBuilder UrlBuilder = new StringBuilder(Url);
            UrlBuilder.Append("client_id=" + ClientId);
            UrlBuilder.Append("&redirect_uri=" + RedirectUrl);
            UrlBuilder.Append("&response_type=" + "code");
            UrlBuilder.Append("&scope=" + Scopes);
            UrlBuilder.Append("&access_type=" + "offline");
            UrlBuilder.Append("&state=" + data); //setting the user id in state  
            return UrlBuilder.ToString();
        }
    }
}