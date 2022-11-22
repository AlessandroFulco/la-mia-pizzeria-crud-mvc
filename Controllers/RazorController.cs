using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace la_mia_pizzeria_static.Controllers
{
    public partial class RazorController : Controller
    {
        public IActionResult Snacks()
        {
            return View();
        }


        
    }
}
