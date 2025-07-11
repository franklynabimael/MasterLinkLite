using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MasterLinkLite.Models;
using MasterLinkLite.Services;

namespace MasterLinkLite.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UsuarioService _usuarioService;

        public RegisterModel()
        {
            _usuarioService = new UsuarioService();
        }

        [BindProperty]
        public string NombreUsuario { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Mensaje { get; set; }

        public IActionResult OnPost()
        {
            if (_usuarioService.Existe(NombreUsuario))
            {
                Mensaje = "El usuario ya existe.";
                return Page();
            }

            var nuevo = new Usuario { NombreUsuario = NombreUsuario, Password = Password };
            _usuarioService.AgregarUsuario(nuevo);

            // Auto login después de registrar
            HttpContext.Session.SetString("usuario", NombreUsuario);
            HttpContext.Session.SetInt32("usuarioId", nuevo.Id);

            return RedirectToPage("/Admin/Links");
        }
    }
}
