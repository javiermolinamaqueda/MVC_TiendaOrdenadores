namespace MVC_ComponenteCodeFirst.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public ICollection<Ordenador> Ordenadores { get; set;} = new List<Ordenador>();

        public double Precio { get; set; } = 0;
    }
}
