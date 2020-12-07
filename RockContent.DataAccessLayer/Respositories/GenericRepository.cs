using Microsoft.EntityFrameworkCore;
using RockContent.DataAccessLayer.DbContexts;
using RockContent.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace RockContent.DataAccessLayer.Respositories
{

    /// <summary>
    /// Generic Repository for Basic CRUD operations:: This can be further implemented by other repositories
    /// </summary>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private RockContentDbContext _dbContext;
        public GenericRepository(RockContentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        
        public async Task<int> SaveShangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }

}
