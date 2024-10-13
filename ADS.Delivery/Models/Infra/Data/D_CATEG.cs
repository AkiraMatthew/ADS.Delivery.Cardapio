﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Delivery.API.V1;

[Table("D_CATEG")]
public class D_CATEG
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CATEG_ID")]
    public required int CategId { get; set; }

    [Column("CATEG_NOME")]
    public required string CategNome { get; set; }

    public required List<D_PRATO> Pratos { get; set; }
}
