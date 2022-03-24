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
    public class IndexModel : PageModel
    {
        private readonly Var1.Data.MyDataBaseVar1Context _context;

        public IndexModel(Var1.Data.MyDataBaseVar1Context context)
        {
            _context = context;
        }

        public IList<Emk> Emk { get;set; }

        public async Task OnGetAsync()
        {
            Emk = await _context.Emks
                .Include(e => e.Pacient)
                .Include(e => e.WUser)
                .Include(e => e.Oper)
                .ToListAsync();
        }
    }
}
