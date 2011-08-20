using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Model;

namespace ContosoWebApp.AutoComplete
{
    /// <summary>
    /// Summary description for AccountUserName
    /// </summary>
    public class AccountUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            var listUser = AccountController.GetList();
            var stringBuilder = new StringBuilder();
            foreach (var account in listUser)
            {
                stringBuilder.Append(account.Username).Append(Environment.NewLine);
            }
            context.Response.Write(stringBuilder.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}