using APIPRUEBAS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


namespace APIPRUEBAS.Models;


[Table("CATEGORIA")]
public partial class Categoria
{

    //Clase Categoria Creada
    public Categoria()
    {
        Producto = new HashSet<Producto>();
    }

    [Key]
    public int IdCategoria { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("oCategoria")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}



