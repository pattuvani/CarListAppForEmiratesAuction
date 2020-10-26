using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CarListAppForEmiratesAuction.Models;

namespace CarListAppForEmiratesAuction.Controllers
{
    public class HomeController : Controller
    {
        
            /// <summary>
            /// To Get Car List
            /// </summary>
            /// <returns></returns>
            public async Task<ActionResult> Index()
            {

                try
                {
                    string apiUrl = "https://api.eas.ae/v2/carsonline?source=mweb";
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            CarViewModel.Root CarObject = js.Deserialize<CarViewModel.Root>(data);
                            //To Get load more data
                            if (Request.HttpMethod == "POST")
                            {
                                ViewBag.jsondata = CarObject.Cars.Skip(10).Take(20);
                            }
                            else
                                ViewBag.jsondata = CarObject.Cars.Take(10);
                        }
                        else
                        {
                            ViewBag.jsondata = "Internal server Error,please contact administrator";
                        }
                    }
                    return View(ViewBag.jsondata);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// To Get Refresh Car List
            /// </summary>
            /// <returns></returns>
            public async Task<ActionResult> RefreshCarList()
            {
                try
                {
                    string apiUrl = "https://api.eas.ae/v2/carsonline?source=mweb";
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            CarViewModel.Root CarObject = js.Deserialize<CarViewModel.Root>(data);
                            ViewBag.jsondata = CarObject.Cars.Take(10);
                        }
                        else
                        {
                            ViewBag.jsondata = "Internal server Error,please contact administrator";
                        }
                    }
                    return RedirectToAction("Index", "Home", ViewBag.jsondata);

                }
                catch (Exception ex)
                {
                    //return View("somthing went wrong");
                    throw ex;

                }
            }

            /// <summary>
            /// To Get Filter car list by make
            /// </summary>
            /// <param name="FilteredList"></param>
            /// <returns></returns>
            public ActionResult FilterList(List<CarViewModel> FilteredList)
            {
                ViewBag.Filtereddata = TempData["FilterData"];
                return View(ViewBag.Filtereddata);
            }

            /// <summary>
            /// To Get Filter car list by make
            /// </summary>
            /// <param name="searchtxt"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<ActionResult> FilterList(string searchtxt)
            {
                try
                {
                    searchtxt = searchtxt.ToUpper();
                    string apiUrl = "https://api.eas.ae/v2/carsonline?source=mweb?";
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            CarViewModel.Root CarObject = js.Deserialize<CarViewModel.Root>(data);
                            TempData["FilterData"] = CarObject.Cars.Where(c => c.makeEn.ToUpper().Contains(searchtxt));
                        }
                        else
                        {
                            ViewBag.jsondata = "Internal server Error,please contact administrator";
                        }
                    }

                    return RedirectToAction("FilterList", "Home", TempData["FilterData"]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            

            }

        /// <summary>
        /// To Get car list by Ajax
        /// </summary>
        /// <returns></returns>
        public ViewResult Ajaxview()
        {
            return View();
        }

    }
}
