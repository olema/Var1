using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Pacients
{
    public class DeleteModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public DeleteModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacient = await _context.Pacients.FirstOrDefaultAsync(m => m.PacientID == id);

            if (Pacient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacient = await _context.Pacients.FindAsync(id);

            if (Pacient != null)
            {
                _context.Pacients.Remove(Pacient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
