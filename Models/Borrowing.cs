using Cucu_Denisa_Flavia_lab2_REFACUT.Models;
using System.ComponentModel.DataAnnotations;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? BookID { get; set; }
        public Book? Book { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
