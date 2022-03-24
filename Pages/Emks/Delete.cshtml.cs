using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Emks
{
    public class DeleteModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public DeleteModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Emk Emk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Emk = await _context.Emks
                .Include(e => e.Pacient)
                .Include(e => e.WUser).FirstOrDefaultAsync(m => m.EmkID == id);

            if (Emk == null)
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

            Emk = await _context.Emks.FindAsync(id);

            if (Emk != null)
            {
                _context.Emks.Remove(Emk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
