using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMottu.Models
{
    [Table("T_MOTTU_MOTOS")]
    public class Moto
    {
        [Key]
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

    }
}
