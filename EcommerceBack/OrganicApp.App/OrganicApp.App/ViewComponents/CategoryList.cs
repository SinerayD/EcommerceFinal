﻿using Microsoft.AspNetCore.Mvc;
using OrganicApp.Service.Services.Interface;
using System.ComponentModel;

namespace OrganicApp.UI.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryserivce;
        public CategoryList(ICategoryService categoryserivce)
        {
            _categoryserivce = categoryserivce;
        }


        public IViewComponentResult Invoke()
        {
            var list = _categoryserivce.GetCategories();

            return View(list);
        }
    }
}
