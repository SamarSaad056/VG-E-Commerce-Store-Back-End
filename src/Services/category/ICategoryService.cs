namespace FusionTech.src.Services.category
{
    public interface ICategoryService
    {
        Task<CategoryBasicDto> CreateOneAsync(CategoryCreateDto createDto);
        Task<List<CategoryBasicDto>> GetAllAsync(PaginationOptions paginationOptions);
        Task<(List<CategoryFullDetailedDto> Categories, int TotalCount)> GetAllDetailedAsync(
            SearchParameters searchParameters
        );
        Task<CategoryDetailedDto> GetByIdAsync(Guid id);
        Task<List<CategoryDetailedDto>> GetCategoryDetailsByNameAsync(string CategoryName);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto);
        Task<int> CountCategoryAsync();
    }
}