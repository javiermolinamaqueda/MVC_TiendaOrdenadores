using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_ComponenteCodeFirst.Models;

public class Componente
{
    public int Id { get; set; }
    [Required]
    [Range(0, 2)]
    public int TipoComponente { get; set; }
    [StringLength(150, ErrorMessage = "No en rango", MinimumLength = 10)]
    public string Descripcion { get; set; } = "";
    [Required]
    [StringLength(20,ErrorMessage ="No en rango", MinimumLength =1)]
    public string Serie { get; set; } = "";
    [Required]
    [Range(minimum: 0, maximum: 99999, ErrorMessage = "Ha introducido un precio demasiado grande")]
    public double Precio { get; set; }
    [Range(minimum: 0, maximum: 99999, ErrorMessage = "Ha introducido una cantidad demasiado grande")]
    public int Calor { get; set; }
    [Range(minimum: 0, maximum: 999999999999999, ErrorMessage = "Ha introducido un almacenamiento demasiado grande")]
    public long Almacenamiento { get; set; }
    [Range(minimum: 0, maximum: 99999, ErrorMessage = "Ha introducido una cantidad demasiado grande")]
    public int Cores { get; set; }

    public int? OrdenadorId { get; set; }
    public virtual Ordenador? Ordenador { get; set; } = null;
}
