using Microsoft.AspNetCore.Mvc;

namespace Queue_Management_System_Assignment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
