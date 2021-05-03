namespace LAFISE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transacciones
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IdTransaccion { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string DescripcionTransa { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FechaTransaccion { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal MontoTransaccion { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal IdCliente { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
