using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;


namespace WebFormsConOAuthNemiro
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            OAuthManager.RegisterClient
             (
               "yahoo",
               "dj0yJmk9Qm1vZ3p2TmtQUm4zJmQ9WVdrOU4wbGlkWGxJT" +
               "kc4bWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD0xZQ--",
               "a55738627652db0acfe464de2d9be13963b0ba1f"
             );

            OAuthManager.RegisterClient
            (
              "twitter",
              "cXzSHLUy57C4gTBgMGRDuqQtr",
              "3SSldiSb5H4XeEMOIIF4osPWxOy19jrveDcPHaWtHDQqgDYP9P"
            );
          

            OAuthManager.RegisterClient
            (
               "google",               
               "188020733885-bdb8ombkpbceqp3d1ar23a7f95qa99o8.apps.googleusercontent.com",
               "NYFcv_bkcgPg_wY1Z104A_i1"
            );


        }
    }
}