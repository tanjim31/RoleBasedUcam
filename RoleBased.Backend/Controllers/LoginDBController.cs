using Microsoft.AspNetCore.Mvc;

namespace RoleBased.Backend.Controllers
{
    public class LoginDBController : APIControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
