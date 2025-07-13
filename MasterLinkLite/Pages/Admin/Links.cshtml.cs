using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MasterLinkLite.Models;
using MasterLinkLite.Services;

namespace MasterLinkLite.Pages.Admin
{
    public class LinksModel : PageModel
    {
        public List<Link> MisLinks { get; set; } = new();

        [BindProperty]
        public Link Nuevo { get; set; }

        [BindProperty]
        public Link Editar { get; set; }

        public bool ModoEdicion { get; set; }

        private readonly LinkService _linkService;

        public LinksModel()
        {
            _linkService = new LinkService();
        }

        public IActionResult OnGet(int? editarId)
        {
            var userId = HttpContext.Session.GetInt32("usuarioId");
            if (userId == null) return RedirectToPage("/Login");

            MisLinks = _linkService.GetByUserId(userId.Value);

            if (editarId.HasValue)
            {
                var link = MisLinks.FirstOrDefault(l => l.Id == editarId && l.UsuarioId == userId.Value);
                if (link != null)
                {
                    Editar = new Link
                    {
                        Id = link.Id,
                        Nombre = link.Nombre,
                        Proposito = link.Proposito,
                        Url = link.Url
                    };
                    ModoEdicion = true;
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("usuarioId");
            if (userId == null) return RedirectToPage("/Login");

            Nuevo.UsuarioId = userId.Value;
            _linkService.Crear(Nuevo);

            return RedirectToPage();
        }

        public IActionResult OnPostEliminar(int id)
        {
            var userId = HttpContext.Session.GetInt32("usuarioId");
            if (userId == null) return RedirectToPage("/Login");

            _linkService.Eliminar(id, userId.Value);
            return RedirectToPage();
        }

        public IActionResult OnPostGuardarEdicion()
        {
            var userId = HttpContext.Session.GetInt32("usuarioId");
            if (userId == null) return RedirectToPage("/Login");

            Editar.UsuarioId = userId.Value;
            _linkService.Actualizar(Editar);
            return RedirectToPage();
        }
    }
}
