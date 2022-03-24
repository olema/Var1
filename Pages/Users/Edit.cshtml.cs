using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public EditModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public WUser WUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WUser = await _context.WUsers
                .Include(e => e.WDoljn)
                .FirstOrDefaultAsync(m => m.WUserID == id);

            if (WUser == null)
            {
                return NotFound();
            }
            
            ViewData["WDoljnID"] = new SelectList(_context.WDoljns, "WDoljnID", "DoljnName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WUserExists(WUser.WUserID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WUserExists(int id)
        {
            return _context.WUsers.Any(e => e.WUserID == id);
        }
    }
}
