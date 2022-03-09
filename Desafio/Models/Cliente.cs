using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    public class Cliente
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = " O campo Nome é obrigatorio!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = " O campo Sobrenome é obrigatorio!")]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatorio!")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatorio!")]
        public string? Cpf { get; set; }
    }
}
