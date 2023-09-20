using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicApp.Core.Entities;
using OrganicApp.Service.Services;
using OrganicApp.Service.Services.Interface;
using System.Threading.Tasks;

namespace OrganicApp.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = ("SuperAdmin,Admin"))]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> List()
        {
            var settings = await _settingService.GetAllAsync();

            return View(settings);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var list = await _settingService.GetAllAsync();

            return View((new Setting(), list));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] Setting model)
        {
            var list = await _settingService.GetAllAsync();
            if (!ModelState.IsValid) return View((model, list));
            if (!model.file.ContentType.Contains("image/")) return View((model, list));

            await _settingService.CreateAsync(model);

            return RedirectToAction("Create");
        }


        public async Task<IActionResult> UpdateAsync(int id)
        {
            var dto = await _settingService.GetByIdUpdateAsync(id);
            var list = await _settingService.GetAllAsync();

            return View((dto, list));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([Bind(Prefix = "Item1")] Setting model)
        {
            var list = await _settingService.GetAllAsync();
            if (!ModelState.IsValid) return View((model, list));

            await _settingService.UpdateAsync(model);
            if (!model.file.ContentType.Contains("image/")) return View((model, list));

            return RedirectToAction("Update");
        }

        public async Task<IActionResult> DeletAsynce(int id)
        {
            if (id != 0)
            {
                await _settingService.RemoveAsync(id);
                return RedirectToAction("List");
            }

            return RedirectToAction("ErrorPage", "Home", new { area = "" });
        }
    }
}
