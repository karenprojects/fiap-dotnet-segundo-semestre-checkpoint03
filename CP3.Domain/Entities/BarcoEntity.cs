using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP3.Domain.Entities
{
    [Table("tb_barco")]
    public class BarcoEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("modelo")]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Column("ano")]
        public int Ano { get; set; }

        [Column("tamanho")]
        public double Tamanho { get; set; }
    }
}
