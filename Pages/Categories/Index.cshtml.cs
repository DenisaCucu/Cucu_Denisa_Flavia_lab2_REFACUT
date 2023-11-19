using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models;
using Cucu_Denisa_Flavia_lab2_REFACUT.Models.ViewModels;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext _context;

        public IndexModel(Cucu_Denisa_Flavia_lab2_REFACUT.Data.Cucu_Denisa_Flavia_lab2_REFACUTContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }

        public CategoryIndexData CategoryData { get; set; }

        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(c => c.Book)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
