﻿using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LanguageApp.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LanguageAppDbContext _languageAppDbContext;

        public CategoryRepository(LanguageAppDbContext languageAppDbContext)
        {
            _languageAppDbContext = languageAppDbContext;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return await (from category in _languageAppDbContext.Categories
                          select new CategoryDto
                          {
                              Id = category.Id,
                              Name = category.Name
                          }).ToListAsync();
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await (from category in _languageAppDbContext.Categories
                          where id == category.Id
                          select new CategoryDto
                          {
                              Id = category.Id,
                              Name = category.Name
                          }).SingleOrDefaultAsync();
        }
    }
}
