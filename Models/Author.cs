using System.ComponentModel.DataAnnotations;

namespace Cucu_Denisa_Flavia_lab2_REFACUT.Models
{
    public class Author
    { 
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
