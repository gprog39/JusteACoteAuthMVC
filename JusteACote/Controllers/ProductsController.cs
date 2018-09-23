using JusteACote.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JusteACote.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fruits()
        {
            using (var _db = new OracleConnection("User Id=APP_DEV;Password=appDev2018!;Data Source=54.38.230.175/orcldev"))
            {
                _db.Open();
                String sql = "SELECT * "
                           + "" + " FROM JC_PRODUCT P INNER JOIN JC_PRODUCT_CATEGORY PC "
                           + "" + " ON P.PRODUCT_ID = PC.PRODUCT_ID "
                           + "" + "INNER JOIN JC_CATEGORY C "
                           + "" + "ON PC.CATEGORY_ID = C.CATEGORY_ID WHERE PC.CATEGORY_ID = 11";


                OracleCommand cmd = new OracleCommand(sql, _db);

                var model = new List<Fruit>();
                try
                {

                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var fruit = new Fruit();
                        fruit.Nom = Convert.ToString(rdr["PRODUCT_NAME"]);
                        fruit.Description = Convert.ToString(rdr["PRODUCT_DESCRIPTION"]);
                        fruit.Masse = Convert.ToInt32(rdr["PRODUCT_WEIGHT"]);
                        fruit.Prix = Convert.ToDouble(rdr["PRODUCT_PRICE"]);


                        model.Add(fruit);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                _db.Close();
                return View(model);
            }

        }

        public ActionResult Boulangerie()
        {
            using (var _db = new OracleConnection("User Id=APP_DEV;Password=appDev2018!;Data Source=54.38.230.175/orcldev"))
            {
                _db.Open();
                String sql = "SELECT * "
                           + "" + " FROM JC_PRODUCT P INNER JOIN JC_PRODUCT_CATEGORY PC "
                           + "" + " ON P.PRODUCT_ID = PC.PRODUCT_ID "
                           + "" + "INNER JOIN JC_CATEGORY C "
                           + "" + "ON PC.CATEGORY_ID = C.CATEGORY_ID WHERE PC.CATEGORY_ID = 41";


                OracleCommand cmd = new OracleCommand(sql, _db);

                var model = new List<Boulangerie>();
                try
                {

                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Boulangerie boulangerie = new Boulangerie();
                        boulangerie.Nom = Convert.ToString(rdr["PRODUCT_NAME"]);
                        boulangerie.Description = Convert.ToString(rdr["PRODUCT_DESCRIPTION"]);
                        boulangerie.Masse = Convert.ToInt32(rdr["PRODUCT_WEIGHT"]);
                        boulangerie.Prix = Convert.ToDouble(rdr["PRODUCT_PRICE"]);


                        model.Add(boulangerie);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                _db.Close();
                return View(model);
            }
        }
    }
}
