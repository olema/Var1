    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Emks
{
    public class CreateModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public CreateModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Emk Emk { get; set; }

        public IActionResult OnGet()
        {
            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "FullName");
            ViewData["WUserID"] = new SelectList(_context.WUsers, "WUserID", "FullName");
            ViewData["OperID"] = new SelectList(_context.Opers, "OperID", "OperName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Emks.Add(Emk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
