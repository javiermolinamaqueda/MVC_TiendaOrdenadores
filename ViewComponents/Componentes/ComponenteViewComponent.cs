using Microsoft.AspNetCore.Mvc;
using MVC_ComponenteCodeFirst.Models;
using MVC_ComponenteCodeFirst.Services;

namespace MVC_ComponenteCodeFirst.ViewComponents.Componentes
{
    public class ComponenteViewComponent : ViewComponent
    {
        public ComponenteViewComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync(Componente componente)
        {
            return await Task.FromResult(View("Default", componente));
        }
    }
}
