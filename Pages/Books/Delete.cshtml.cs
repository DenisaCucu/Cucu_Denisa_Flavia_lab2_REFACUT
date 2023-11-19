using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;
using Cucu_Denisa_Flavia_Lab2_1_.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Pages.Books
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : BookCategoriesPageModel
    {
        private readonly Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext _context;

        public DeleteModel(Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext context)
        {
            _context = context;
        }


        [BindProperty]
      public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
               .Include(b => b.Author)
               .Include(b => b.Publisher)
               .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }
            var book = await _context.Book.FindAsync(id);

            if (book != null)
            {
                Book = book;
                _context.Book.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
