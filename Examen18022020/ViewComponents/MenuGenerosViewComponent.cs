using Examen18022020.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.ViewComponents
{
    public class MenuGenerosViewComponent : ViewComponent
    {

        IRepository repo;
        public MenuGenerosViewComponent(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(this.repo.FindAllGeneros());
        }
    }
}
