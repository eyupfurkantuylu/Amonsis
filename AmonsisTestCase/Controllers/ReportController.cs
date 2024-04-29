using AmonsisTestCase.Repositories.ReportRepositories;
using AmonsisTestCase.Repositories.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
