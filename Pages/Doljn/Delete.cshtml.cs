using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Doljn
{
    public class DeleteModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public DeleteModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public WDoljn WDoljn { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WDoljn = await _context.WDoljns.FirstOrDefaultAsync(m => m.WDoljnID == id);

            if (WDoljn == null)
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

            WDoljn = await _context.WDoljns.FindAsync(id);

            if (WDoljn != null)
            {
                _context.WDoljns.Remove(WDoljn);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
