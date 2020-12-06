using RockContent.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RockContent.DataAccessLayer.Entities;
using RockContent.DataAccessLayer.DbContexts;

namespace RockContent.DataAccessLayer.Respositories
{
    public class PostLikesRepository<TEntity>: GenericRepository<PostLikes>, IPostLikesRepository 
    {
        public PostLikesRepository(RockContentDbContext dbContext) : base(dbContext)
        {

        }
    }
}
