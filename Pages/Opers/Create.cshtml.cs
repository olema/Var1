using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Opers
{
    public class CreateModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public CreateModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Oper Oper { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Opers.Add(Oper);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
