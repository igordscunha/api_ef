using System.ComponentModel.DataAnnotations;

namespace API_EF.Data.Dtos;

public class ReadClienteDto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string Cpf { get; set; }

    public DateTime HoraConsulta { get; set; } = DateTime.Now;
}
