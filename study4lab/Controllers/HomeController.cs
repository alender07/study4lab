using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;
using study4lab.Models;

namespace study4lab.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ViewResult ShowData()
        {
            CommonTable ct = new CommonTable
            {
                fname = "Александр",
                lname = "Шиманский",
                title = "qq"
            };
            List<CommonTable> ct1 = new List<CommonTable> { ct, ct };
            return View(ct1);
        }

        public ActionResult TableFromSQL()
        {
            List<CommonTable> ct1 = new List<CommonTable>();
            using (SqlConnection conn = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.au_fname, a.au_lname, t.title FROM Authors a INNER JOIN titleauthor ta ON a.au_id = ta.au_id INNER JOIN titles t ON ta.title_id = t.title_id ORDER BY a.au_lname DESC", conn);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    ct1.Add(
                        new CommonTable
                        {
                            fname = res.GetString(0),
                            lname = res.GetString(1),
                            title = res.GetString(2)
                        });
                }
                res.Close();
            }
            ViewBag.Title = "Локальное выполнение SQL-запроса в методе действия";
            return View("ShowData", ct1);
        }
    }
}