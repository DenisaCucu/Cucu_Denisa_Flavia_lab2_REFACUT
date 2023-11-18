using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext _context;

        public IndexModel(Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
    }
}
