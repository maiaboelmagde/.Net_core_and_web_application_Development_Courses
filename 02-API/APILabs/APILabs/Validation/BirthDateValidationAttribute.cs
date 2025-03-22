using System.ComponentModel.DataAnnotations;

namespace APILabs.Validation
{
    public class BirthDateValidationAttribute : ValidationAttribute
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public BirthDateValidationAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }


        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Birth date is required.");
            }

            if (value is DateTime birthDate)
            {
                var today = DateTime.Today;
                int age = today.Year - birthDate.Year;

                if (birthDate > today.AddYears(-age))
                    age--;

                if (age < _minAge || age > _maxAge)
                {
                    return new ValidationResult($"Allowed age is between {_minAge} and {_maxAge} based on birth date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
