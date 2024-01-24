using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EF.Models;


[Table("db_atacadao")]
public class Clientes
{

    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50, ErrorMessage = "Nome excede o limite de caracteres!")]
    public string Nome { get; set; }

    [Required, MaxLength(100, ErrorMessage = "Sobrenome excede o limite de caracteres!")]
    public string Sobrenome { get; set; }

    [Required, Length(11, 11, ErrorMessage = "O CPF deve conter 11 caracteres, apenas números.")]
    public string Cpf { get; set; }
}
