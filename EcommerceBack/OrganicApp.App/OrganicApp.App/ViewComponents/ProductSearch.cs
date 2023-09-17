using Microsoft.AspNetCore.Mvc;
using OrganicApp.Core.Entities;

namespace OrganicApp.UI.ViewComponents
{
    public class ProductSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var product = new Product();

            return View(product);
        }
    }
}
