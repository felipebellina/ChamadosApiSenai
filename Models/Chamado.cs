using ChamdosAPI.Enums;

namespace ChamdosAPI.Models;

public class Chamado
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    
    public string? Descricao { get; set; }

    public StatusEnum Status { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public DateTime DataFechamento { get; set; }
}
