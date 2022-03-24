using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Var1.Data;
using Var1.Models;

namespace Var1.Pages.Opers
{
    public class DetailsModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public DetailsModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        public Oper Oper { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oper = await _context.Opers.FirstOrDefaultAsync(m => m.OperID == id);

            if (Oper == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
