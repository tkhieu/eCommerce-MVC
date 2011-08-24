using System.Web;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using eCommerce.Model;
using eCommerce.Model.Controller;
using eCommerce.Model.SimpleJSON;

namespace eCommerce.Admin.Service
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
                var accountJson = new AccountJSON
                                      {
                                          id = account.ID.ToString(),
                                          label = account.Username,
                                          value = account.Username,
                                          Name = account.Name,
                                          Tel = account.Tel,
                                          Address = account.Address,
                                          District = account.DISTRICT.Name,
                                          DistrictId = account.DISTRICT.ID,
                                          City = account.CITY.Name,
                                          CityId = account.CITY.ID
                                      };


                collection.Add(accountJson);
            }

            var javaScriptSerializer = new JavaScriptSerializer();
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