using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MasterLinkLite.Models;
using MasterLinkLite.Services;
using System.Collections.Generic;
using System.Linq;

namespace MasterLinkLite.Pages.Admin
{
    public class LinkProgramModel : PageModel
    {
        public List<Programs> MisProgramas { get; set; } = new();

        [BindProperty]
        public Programs Nuevo { get; set; }

        [BindProperty]
        public Programs Editar { get; set; }

        public bool ModoEdicion { get; set; }

        private readonly ProgramService _programService;

        public LinkProgramModel()
        {
            _programService = new ProgramService();
        }

        public IActionResult OnGet(int? editarId)
        {
            MisProgramas = _programService.GetAll();

            if (editarId.HasValue)
            {
                var prog = MisProgramas.FirstOrDefault(p => p.Id == editarId);
                if (prog != null)
                {
                    Editar = new Programs
                    {
                        Id = prog.Id,
                        Nombre = prog.Nombre,
                        Url = prog.Url
                    };
                    ModoEdicion = true;
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _programService.Crear(Nuevo);
            return RedirectToPage();
        }

        public IActionResult OnPostEliminar(int id)
        {
            _programService.Eliminar(id);
            return RedirectToPage();
        }

        public IActionResult OnPostGuardarEdicion()
        {
            _programService.Actualizar(Editar);
            return RedirectToPage();
        }
    }
}
