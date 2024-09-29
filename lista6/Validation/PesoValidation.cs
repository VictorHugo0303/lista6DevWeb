using System;
using System.ComponentModel.DataAnnotations;

namespace lista6.Validation
{
    public class PesoValidation : ValidationAttribute
    {
            private double minPeso;
            private double maxPeso;
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return new ValidationResult("O peso é obrigatório.");
                }

                if (!double.TryParse(value.ToString(), out double peso))
                {
                    return new ValidationResult("O peso deve ser um número válido.");
                }

                if (peso != Math.Round(peso, 2))
                {
                    return new ValidationResult("O peso deve ter no máximo 2 casas decimais.");
                }

                return ValidationResult.Success;
            }
    }
}
