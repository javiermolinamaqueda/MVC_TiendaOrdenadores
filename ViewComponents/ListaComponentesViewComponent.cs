using Microsoft.AspNetCore.Mvc;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Services;

namespace MVC_ComponenteCodeFirst.ViewModel
{
    public class ListaComponentesViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Componente> lista)
        {
            return await Task.FromResult(View("Default", lista));
        }
    }
}
