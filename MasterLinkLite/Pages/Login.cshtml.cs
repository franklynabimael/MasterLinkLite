    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MasterLinkLite.Services;

    namespace MasterLinkLite.Pages
    {
        public class LoginModel : PageModel
        {
            private readonly UsuarioService _usuarioService;

            public LoginModel()
            {
                _usuarioService = new UsuarioService();
            }
        
            [BindProperty]
            public string Username { get; set; }

            [BindProperty]
            public string Password { get; set; }

            public string Mensaje { get; set; }

            public IActionResult OnPost()
            {
                var usuario = _usuarioService.ValidarLogin(Username, Password);
                if (usuario != null)
                {
                    HttpContext.Session.SetString("usuario", usuario.NombreUsuario);
                    HttpContext.Session.SetInt32("usuarioId", usuario.Id);

                    return RedirectToPage("/Admin/Links");
                }

                Mensaje = "Credenciales incorrectas.";
                return Page();
            }
        }
    }
