using MVC_ComponenteCodeFirst.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ComponenteCodeFirst.Models
{
    public class Ordenador
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public virtual ICollection<Componente> Componentes { get; } = new List<Componente>();

        public int? PedidoId { get; set; }
        public virtual Pedido? Pedido { get; set; }

        public double Precio { get; set; } = 0;
    }
}
