using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrganicApp.Core.Entities;
using OrganicApp.Service.FluentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Extensions
{
    public static class ValidationExtension
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Product>, ProductValidation>();
            services.AddScoped<IValidator<ProductDetail>, ProductDetailValidation>();

            services.AddScoped<IValidator<Blog>, BlogValidation>();
            services.AddScoped<IValidator<BlogDetail>, BlogDetailValidator>();

            services.AddScoped<IValidator<Owner>, OwnerValidation>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();
            services.AddScoped<IValidator<Comment>, CommentValidation>();
            services.AddScoped<IValidator<Advert>, AdvertValidation>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();
        }
    }
}
