using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Controllers;
using TestVp.Manager;

namespace TestVp.Attributes
{
    public class CustomApiAuthorize : System.Web.Http.AuthorizeAttribute
    {
        private const string _securityToken = "token";


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);

        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                HttpRequestBase request = actionContext.Request.Properties["MS_HttpContext"] as HttpRequestBase;
                var header = actionContext.Request.Headers.Authorization;
                string token = header.Scheme;
                var userAgent = actionContext.Request.Headers.UserAgent;
                var ip = GetClientIpAddress(actionContext.Request);

                return SecurityManager.IsTokenValid(token, ip,"");
            }
            catch (Exception)
            {
                return false;
            }
        }
        private string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
            }
        
            return String.Empty;
        }
    }

}