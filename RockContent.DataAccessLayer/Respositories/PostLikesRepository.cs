using RockContent.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RockContent.DataAccessLayer.Entities;
using RockContent.DataAccessLayer.DbContexts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RockContent.DataAccessLayer.Respositories
{
    public class PostLikesRepository<TEntity>: GenericRepository<PostLikes>, IPostLikesRepository 
    {
        private RockContentDbContext _dbContext;

        public PostLikesRepository(RockContentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PostLikes>> GetAllLikesAsync(int Limit = 10)
        {
            var response = await _dbContext.PostLikes.Where(x=>x.IsLike==true).Select(x => x).Take(Limit).ToListAsync();
            return response;
        }

        public async Task<int> GetAllLikesCountByPostIdAsync(string postId)
        {
            var response = 0;
            var result = await _dbContext.PostLikes.Where(x => x.PostId == postId).Select(x => x).CountAsync();
            response = result;
            return response;
        }


        public async Task<PostLikes> GetLikesByUserIpAsync(string IpAddress)
        {
            var response = await _dbContext.PostLikes.Where(x => x.UserIp == IpAddress).Select(x=>x).FirstOrDefaultAsync();
            return response;
        }


        public async Task<List<PostLikes>> GetLikesByUserIpAndPostIdAsync(string IpAddress, string PostId)
        {
            var response =await _dbContext.PostLikes.Where(x => x.UserIp == IpAddress && x.PostId==PostId).Select(x => x).ToListAsync();
            return response;
        }
    }
}
