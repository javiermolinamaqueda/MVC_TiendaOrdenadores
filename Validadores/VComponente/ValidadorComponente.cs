using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Validadores.VComponente
{
    public class ValidadorComponente : IValidadorComponente
    {
        public bool IsValid(Componente miComponente)
        {
            bool valido = true;
            if (miComponente.TipoComponente == (int)TipoComponente.Procesador)
            {
                if (miComponente.Almacenamiento != 0) valido = false;
            }
            else if (miComponente.Cores != 0)
            {
                valido = false;
            }

            return (valido && miComponente != null && miComponente.Calor >= 0 &&
                miComponente.Serie != null && miComponente.Serie != ""
                && miComponente.Cores >= 0 && miComponente.Precio >= 0 &&
                miComponente.Almacenamiento >= 0);
        }
    }
}
