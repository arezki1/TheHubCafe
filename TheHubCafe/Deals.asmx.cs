using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TheHubCafe.Models;

namespace TheHubCafe
{
    /// <summary>
    /// Summary description for Deals
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Deals : System.Web.Services.WebService
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        [WebMethod]


        public string[] GetPizzasByName(string namePart)
        {
            List<string> Pizzas = new List<string>();

            if (namePart != "")
            {
                foreach (var pizza in db.Pizzas
                    .Where(async => async.Name.Contains(namePart))
                    .ToList())
                {


                    Pizzas.Add(pizza.Name);
                }
            }

            return Pizzas.ToArray();
        }
    }
}