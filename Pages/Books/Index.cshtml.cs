using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext _context;

        public IndexModel(Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();
        }
    }
}
