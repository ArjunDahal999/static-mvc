using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories(); 
            return View( categories);
        }

        public IActionResult Edit(int id)
        {
            if(id != null) { 
            var category = CategoriesRepository.GetCategoryById(id);
            return View(category);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit( Category category)
        {
            if(ModelState.IsValid)
            {
            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public IActionResult Delete(int categoryId)
        {
         
           CategoriesRepository.DeleteCategoryById(categoryId);
           return RedirectToAction(nameof(Index));
        }
    }
}