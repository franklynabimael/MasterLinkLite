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
            MisLinks = _linkService.GetAll(); // Muestra todos los enlaces

            if (editarId.HasValue)
            {
                var link = MisLinks.FirstOrDefault(l => l.Id == editarId);
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
            
            _linkService.Crear(Nuevo);

            return RedirectToPage();
        }

        public IActionResult OnPostEliminar(int id)
        {
            

            _linkService.Eliminar(id);
            return RedirectToPage();
        }

        public IActionResult OnPostGuardarEdicion()
        {
            

        
            _linkService.Actualizar(Editar);
            return RedirectToPage();
        }
    }
}
