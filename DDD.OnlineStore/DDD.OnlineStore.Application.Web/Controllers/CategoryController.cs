using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class CategoryController : EditorControllerBase<Category, CategoryRepository>
    {
        public CategoryController(CategoryRepository categoryRepository) : base(categoryRepository)
        {

        }
    }
}
