using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext _context;

        public DetailsModel(Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext context)
        {
            _context = context;
        }

      public BookCategory BookCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookcategory = await _context.BookCategory.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcategory == null)
            {
                return NotFound();
            }
            else 
            {
                BookCategory = bookcategory;
            }
            return Page();
        }
    }
}
