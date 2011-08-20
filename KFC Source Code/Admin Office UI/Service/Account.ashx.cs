using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SimpleJSON;
using System.Collections.ObjectModel;
using Model;
using System.Web.Script.Serialization;

namespace ContosoWebApp.Service
{
    /// <summary>
    /// Summary description for Account
    /// </summary>
    public class Account : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string searchText = context.Request.QueryString["term"];
            var collection = new Collection<AccountJSON>();

            var list = AccountController.GetList(searchText);
            foreach (ACCOUNT account in list)
            {
                var accountJson = new AccountJSON(account.ID.ToString(),account.Username,account.Username);
                collection.Add(accountJson);
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(collection);
            context.Response.Write(jsonString);
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