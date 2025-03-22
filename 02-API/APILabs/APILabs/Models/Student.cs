using System.ComponentModel.DataAnnotations;
using APILabs.Filters;
using APILabs.Validation;

namespace APILabs.Models
{
    [studentResultFilter]
    public class Student
    {
        public int Id { get; set; }

        [MinLength(3 , ErrorMessage = "Name must be at least 3 letters")]
        [MaxLength(10, ErrorMessage = "Name can't exceed 10 letters")]
        public string Name { get; set; }

        [RegularExpression(@"^(.*\.jpg|.*\.png)$", ErrorMessage = "Image must end with .jpg or .png")]
        public string? Image { get; set; }
        public string address { get; set; }

        [Range(18, 22 , ErrorMessage ="Allowed age is between 18 and 22 !!")]
        public int age { get; set; }
        [BirthDateValidation(18, 22)]
        public DateTime birthDate { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain only digits.")]
        public string? PhoneNum { get; set; }
        public int grade { get; set; }
    }
}
