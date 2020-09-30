using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Filters;
using MD5Hash;

namespace Web.API.Filters
{
   
    public class BasicAuthFilter : Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8
                                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 2);
                        if (credentials.Length == 2)
                        {
                            if (IsAuthorized(credentials[0], credentials[1]))
                            {
                                return;
                            }
                        }
                    }
                }

                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(string username, string password)
        {  
          if(HashValues(username).Equals("4211de0745eeeb8266ac12a981538a69") &&
             HashValues(password).Equals("4211de0745eeeb8266ac12a981538a69"))
          {
                return true;
          }
            return false;
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            
            context.HttpContext.Response.Headers["WWW-Authenticate"] = "";
            context.Result = new UnauthorizedResult();
        }

        public string HashValues(string val)
        {
            return MD5Hash.Hash.Content(val).ToString();
        }
    }
}

