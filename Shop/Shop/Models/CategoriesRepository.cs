namespace Shop.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category() { CategoryId = 1, Name = "Beverage", Description = "Drink Beverage" },
            new Category() { CategoryId = 2, Name = "Snack", Description = "Eat Snacks" },
            new Category() { CategoryId = 3, Name = "Electronics", Description = "Buy Electronic gadgets" }
        };

        public static void AddCategory ( Category category)
        {
            var maxId = _categories.Max(c => c.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }
    
        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int id)
        {
            var isCategory = _categories.FirstOrDefault(x => x.CategoryId == id);
            if(isCategory != null)
            {
                return new Category
                {
                    CategoryId = isCategory.CategoryId,
                    Name = isCategory.Name,
                    Description = isCategory.Description,
                };
            }
            return null;
        }

        public static void DeleteCategoryById(int id)
        {
            var isCategory = _categories.FirstOrDefault(x => x.CategoryId == id);
           _categories.Remove(isCategory);
                 
        }

        public static void UpdateCategory(int categoryId, Category category)
        {

            if( categoryId!= category.CategoryId )
            {
                return;
            }
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if ( categoryToUpdate != null )
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

    }
}
