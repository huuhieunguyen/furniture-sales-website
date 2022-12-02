using Microsoft.AspNetCore.Mvc;
using Funiture_Project.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Funiture_Project.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _reader;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //login method
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            // connect to database
            _connection.ConnectionString = "data source=MSI ; database=Funiture ; integrated security=SSPI";
            _connection.Open();
            _command.Connection = _connection;

            //query to find username and password
            _command.CommandText = "select * from Users where Username='" + loginViewModel.Username + "' and Password='" + loginViewModel.Password + "'";
            _reader = _command.ExecuteReader();

            //check
            if (_reader.Read())
            {
                // true, login
                _connection.Close();
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                // fail, try again
                _connection.Close();
                return View();
            }
        }
    }
}

