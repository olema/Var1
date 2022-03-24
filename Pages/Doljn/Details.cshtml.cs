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
    public class DetailsModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public DetailsModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

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
    }
}
