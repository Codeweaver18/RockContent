using RockContent.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RockContent.DataAccessLayer.Entities;
using RockContent.DataAccessLayer.DbContexts;
using System.Threading.Tasks;
using System.Linq;

namespace RockContent.DataAccessLayer.Respositories
{
    public class PostLikesRepository<TEntity>: GenericRepository<PostLikes>, IPostLikesRepository 
    {
        private RockContentDbContext _dbContext;

        public PostLikesRepository(RockContentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PostLikes> GetAllLikes(int Limit = 10)
        {
            var response = _dbContext.PostLikes.Select(x => x).Take(Limit).ToList();
            return response;
        }

        public  PostLikes GetLikesByUserIp(string IpAddress)
        {
            var response =  _dbContext.PostLikes.Where(x => x.UserIp == IpAddress).Select(x=>x).FirstOrDefault();
            return response;
        }
    }
}
