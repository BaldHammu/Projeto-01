using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimicAPI.Database;
using MimicAPI.Models;

namespace MimicAPI.Pages
{
    public class PalavrasControllerModel : PageModel
    {
        private readonly MimicContext _banco;
        public PalavrasControllerModel(MimicContext banco)
        {
            _banco = banco;
        }
        public ActionResult OnGet()
        {
            return new JsonResult(_banco.Palavras);
        }

    }
}
