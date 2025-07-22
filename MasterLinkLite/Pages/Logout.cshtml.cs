using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterLinkLite.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear(); // Cierra la sesi�n
            return RedirectToPage("/Index"); // Redirige al inicio
        }
    }
}
