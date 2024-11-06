using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMottu.Models
{

    [Table("T_MOTTU_ENTREGADORES")]
    public class Entregador
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCNH { get; set; }
        public string TipoCNH { get; set; }
        public string ImagemCNH { get; set; }

    }
}
