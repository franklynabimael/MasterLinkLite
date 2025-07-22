using Microsoft.AspNetCore.Mvc.RazorPages;
using MasterLinkLite.Models;
using MasterLinkLite.Services;
using System.Collections.Generic;

namespace MasterLinkLite.Pages
{
    public class HomeModel : PageModel
    {
        public List<Programs> Programas { get; set; } = new();

        public void OnGet()
        {
            var programService = new ProgramService();
            Programas = programService.GetAll();
        }
    }
}
