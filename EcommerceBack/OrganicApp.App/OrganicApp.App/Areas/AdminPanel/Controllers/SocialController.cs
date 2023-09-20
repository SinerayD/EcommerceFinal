using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicApp.Core.Entities;
using OrganicApp.Service.Services.Interface;
using System.Threading.Tasks;

namespace OrganicApp.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = ("SuperAdmin,Admin"))]
    public class SocialController : Controller
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public async Task<IActionResult> List()
        {
            var socials = await _socialService.GetAllAsync();

            return View(socials);
        }

        public async Task<IActionResult> Create()
        {
            var list = await _socialService.GetAllAsync();

            return View((new Social(), list));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] Social model)
        {
            var list = await _socialService.GetAllAsync();

            if (!ModelState.IsValid)
                return View((model, list));

            await _socialService.CreateAsync(model);

            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _socialService.GetByIdUpdate(id);
            var list = await _socialService.GetAllAsync();

            return View((dto, list));
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] Social model)
        {
            var list = await _socialService.GetAllAsync();

            if (!ModelState.IsValid)
                return View((model, list));

            await _socialService.Update(model);

            return RedirectToAction("Update");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                await _socialService.Remove(id);
                return RedirectToAction("List");
            }

            return RedirectToAction("ErrorPage", "Home", new { area = "" });
        }
    }
}
