using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Validadores.VOrdenador
{
    public class ValidadorOrdenador : IValidadorOrdenador
    {
        public bool IsValid(Ordenador ordenador)
        {
                var lista = ordenador.Componentes;
                return lista.Count(p => p.TipoComponente == ((int)TipoComponente.Procesador)) == 1
                       && lista.Count(p => p.TipoComponente == ((int)TipoComponente.Guardador)) == 1
                       && lista.Any(p => p.TipoComponente == ((int)TipoComponente.Memorizador));
        }
    }
}
