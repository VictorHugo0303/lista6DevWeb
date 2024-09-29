using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lista6.Validation
{
    public class cpfValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = value as string;

            if (string.IsNullOrEmpty(cpf))
                return new ValidationResult("O CPF é obrigatório.");

            var (isValid, errorMessage) = ValidarCpf(cpf);

            if (isValid)
                return ValidationResult.Success;

            return new ValidationResult(errorMessage);
        }

        public (bool, string) ValidarCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return (false, "Deve conter 11 dígitos.");

            if (cpf.All(c => c == cpf[0]))
                return (false, "Não pode ter todos os dígitos iguais.");

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cpf.EndsWith(digito))
                return (false, "O CPF é inválido. Dígitos verificadores não conferem.");

            return (true, null);

        }
    }
}
