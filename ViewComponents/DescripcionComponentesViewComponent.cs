using Microsoft.AspNetCore.Mvc;
using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.ViewModel
{
    public class DescripcionComponentesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Componente> lista)
        {
            return await Task.FromResult(View("Default", lista));
        }
    }
}
