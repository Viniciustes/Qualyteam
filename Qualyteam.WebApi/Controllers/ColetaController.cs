using Microsoft.AspNetCore.Mvc;

namespace Qualyteam.WebApi.Controllers
{
    [Route("api/coleta")]
    public class ColetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
