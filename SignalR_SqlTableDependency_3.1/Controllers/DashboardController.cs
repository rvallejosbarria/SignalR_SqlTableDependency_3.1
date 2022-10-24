using Microsoft.AspNetCore.Mvc;

namespace SignalR_SqlTableDependency_3._1.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
