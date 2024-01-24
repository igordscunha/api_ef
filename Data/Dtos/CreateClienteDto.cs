using System.ComponentModel.DataAnnotations;

namespace API_EF.Data.Dtos;

public class CreateClienteDto
{
    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string Cpf { get; set; }
}
