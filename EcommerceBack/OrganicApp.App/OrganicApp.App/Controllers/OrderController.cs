using Microsoft.AspNetCore.Mvc;

namespace OrganicApp.App.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
