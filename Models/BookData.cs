using Cucu_Denisa_Flavia_lab2_REFACUT.Models;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Models
{
    public class BookData
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }
    }
}
