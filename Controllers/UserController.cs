using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Razor.Controllers
{

    public class UserController : Controller
    {
        // public IConfigurationRoot Configuration { get; set; }


        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {

            //string cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();

            string cnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["cnStr"];

            //string cnStr = "Server=(local);Database=Facturacion;User Id=sa;Password=poison;TrustServerCertificate=True";

            SqlConnection Cn = new SqlConnection(cnStr);
            SqlCommand Cmd = new SqlCommand("sp_apirest_listar", Cn);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("filtro", "EL");
            Cn.Open();
          //Cmd.ExecuteNonQuery();

            SqlDataReader Dr;
            Dr = Cmd.ExecuteReader();


            List<User> lUsers = new List<User>();
            lUsers.Clear();
            while (Dr.Read())
            {
                User ouser = new User();
                ouser.id = Convert.ToInt32(Dr["Id"]);
                ouser.Nombre = Dr["Nombre"].ToString();
                ouser.DNI = Dr["DNI"].ToString();
                ouser.Edad = Convert.ToInt16(Dr["Edad"]);
                ouser.Telefono = Dr["Telefono"].ToString();
                ouser.Correo = Dr["Correo"].ToString();
                ouser.Basico = Convert.ToDecimal(Dr["Basico"]);
                ouser.Ingreso = Convert.ToDateTime(Dr["Ingreso"]);
                ouser.Activo = Convert.ToBoolean(Dr["Activo"]);
                lUsers.Add(ouser);
            }

            Cn.Close();

            return View(lUsers);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
