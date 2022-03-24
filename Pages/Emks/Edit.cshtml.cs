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

namespace Var1.Pages.Emks
{
    public class EditModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public EditModel(Var1.Data.MyDataBaseVar1Context context)
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
                .Include(e => e.WUser)
                .Include(e => e.Oper)
                .FirstOrDefaultAsync(m => m.EmkID == id);

            if (Emk == null)
            {
                return NotFound();
            }

            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "FullName");
            ViewData["WUserID"] = new SelectList(_context.WUsers, "WUserID", "FullName");
            ViewData["OperID"] = new SelectList(_context.Opers, "OperID", "OperName");

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

            _context.Attach(Emk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmkExists(Emk.EmkID))
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

        private bool EmkExists(int id)
        {
            return _context.Emks.Any(e => e.EmkID == id);
        }
    }
}
