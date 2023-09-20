using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganicApp.Service.Services.Interface;
using System.Data;

namespace OrganicApp.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = ("SuperAdmin,Admin"))]
    public class subscribeController : Controller
    {
        private readonly ISubscribeService _subscribeservice;

        public subscribeController(ISubscribeService subscribeservice)
        {
            _subscribeservice = subscribeservice;
        }


        public async Task<IActionResult> List()
        {
            var categories = await _subscribeservice.GetAllAsync();

            return View(categories);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _subscribeservice.RemoveAsync(id);

            return RedirectToAction("List");
        }
    }
}
