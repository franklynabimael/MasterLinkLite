using Microsoft.AspNetCore.Mvc.RazorPages;
using MasterLinkLite.Models;
using MasterLinkLite.Services;

namespace MasterLinkLite.Pages
{
    public class IndexModel : PageModel
    {
        public List<Link> Links { get; set; } = new();
        public string Usuario { get; set; }

        public void OnGet()
        {
            var linkService = new LinkService();
            Links = linkService.GetAll();

            Usuario = HttpContext.Session.GetString("usuario");
        }
    }
}
