using System.ComponentModel.DataAnnotations;

namespace coreMvcCrud.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "İsim boş geçilemez!")]
        public string Name { get; set; }
        [Range(15, 70, ErrorMessage = "Sadece 15-70 yaş arası değer!")]
        public int Age { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid, enter like # or #.##")]
        public decimal Salary { get; set; }
        public string Department { get; set; }

        [RegularExpression(@"^[MF]+$", ErrorMessage = "Sadece tek cinsiyet seçimi!")]
        public char Sex { get; set; }
    }
}
