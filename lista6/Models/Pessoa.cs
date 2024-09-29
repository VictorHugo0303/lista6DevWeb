using System.ComponentModel.DataAnnotations;
using lista6.Validation;

namespace lista6.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Obrigatório")]
        [MinLength(3, ErrorMessage = "Minimo 3 letras")]
        [MaxLength(50, ErrorMessage = "Maximo 50 letras")]
        public string Nome { get; set; } = string.Empty;

        [cpfValidation]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obrigatório")]
        [Range(1.0, 500.0, ErrorMessage = "O peso deve estar entre 1 kg e 500 kg.")]
        [PesoValidation]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Range(50, 250, ErrorMessage = "A altura deve estar entre 50cm e 250cm.")]
        public int Altura { get; set; }


        public double Imc()
        {
            return Peso / Math.Pow((Altura / 100), 2);
        }
    }
}
