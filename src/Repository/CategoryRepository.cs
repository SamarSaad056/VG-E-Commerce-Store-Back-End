namespace FusionTech.src.Repository
{
    public class CategoryRepository
    {
        protected DbSet<Category> _category;
        protected DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _category = databaseContext.Set<Category>();
        }

        public async Task<Category> CreateOneAsync(Category newCategory)
        {
            await _category.AddAsync(newCategory);
            await _databaseContext.SaveChangesAsync();
            return newCategory;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _category.ToListAsync();
        }

        public async Task<List<Category>> GetAllDetailedAsync(SearchParameters searchParameters)
       {
           IQueryable<Category> query = _category
               .Include(c => c.VideoGameInfos)
               .ThenInclude(vi => vi.VideoGameVersions);

           if (!string.IsNullOrEmpty(searchParameters.Search))
           {
               var searchTerm = searchParameters.Search.ToLower(); 

               query = query.Where(c =>
                   c.VideoGameInfos.Any(vi =>
                             vi.GameName.ToLower().Contains(searchTerm) // Convert GameName to lower case for case-insensitive search
                   )
               );
           }

           // Apply price range filtering
           if (searchParameters.MinPrice > 0)
           {
               query = query.Where(c =>
                   c.VideoGameInfos.Any(vi =>
                       vi.VideoGameVersions.Any(v => v.Price >= searchParameters.MinPrice)
                   )
               );
           }

           if (searchParameters.MaxPrice < 10000) // Assuming 10000 is the default maximum price in your parameter class
           {
               query = query.Where(c =>
                   c.VideoGameInfos.Any(vi =>
                       vi.VideoGameVersions.Any(v => v.Price <= searchParameters.MaxPrice)
                   )
               );
           }       



           // Apply sorting based on SortBy and Descending parameters
           switch (searchParameters.SortBy)
           {
               case SortingTypes.ByTitle:
                   query = searchParameters.Descending
                       ? query.OrderByDescending(c => c.VideoGameInfos.FirstOrDefault().GameName)
                       : query.OrderBy(c => c.VideoGameInfos.FirstOrDefault().GameName);
                   break;

               case SortingTypes.ByPrice:
                   query = searchParameters.Descending
                       ? query.OrderByDescending(c => c.VideoGameInfos.FirstOrDefault().VideoGameVersions.Min(v => v.Price))
                       : query.OrderBy(c => c.VideoGameInfos.FirstOrDefault().VideoGameVersions.Min(v => v.Price));
                   break;

               case SortingTypes.ByRating:
                   query = searchParameters.Descending
                       ? query.OrderByDescending(c => c.VideoGameInfos.FirstOrDefault().TotalRating)
                       : query.OrderBy(c => c.VideoGameInfos.FirstOrDefault().TotalRating);
                   break;

               case SortingTypes.None:
               default:
            
                   query = query.OrderBy(c => c.CategoryId); 
                   break;
           }

           // Apply pagination (
           var categories = await query
               .Skip(searchParameters.Offset)
               .Take(searchParameters.Limit)
               .ToListAsync();


           return categories;
       }

        public async Task<int> CountAsync()
        {
            return await _category.CountAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _category
                .Include(c => c.VideoGameInfos)
                .ThenInclude(vi => vi.VideoGameVersions)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<List<Category>> GetCategoryDetailsByNameAsync(string CategoryName)
        {
            return await _category
                .Include(c => c.VideoGameInfos)
                .ThenInclude(vi => vi.VideoGameVersions)
                .Where(c => c.CategoryName.ToLower() == CategoryName.ToLower())
                .ToListAsync();
        }

        public async Task<bool> DeleteOneAsync(Category category)
        {
            _category.Remove(category);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOneAsync(Category updateCategory)
        {
            _category.Update(updateCategory);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> PatchOneAsync(Guid id, Category updatedFields)
        {
            var existingCategory = await GetByIdAsync(id);

            if (existingCategory == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(updatedFields.CategoryName))
            {
                existingCategory.CategoryName = updatedFields.CategoryName;
            }

            await _databaseContext.SaveChangesAsync();

            return existingCategory;
        }
    }
}

      