using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteMottu.Enums;

namespace TesteMottu.Models;

[Table("T_MOTTU_LOCACOES")]
public class Locacao
{
    [Key]
    public int Id { get; set; }
    public int MotoId { get; set; }
    public int EntregadorId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTerminoPrevista { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public Plano Plano { get; set; }

}
