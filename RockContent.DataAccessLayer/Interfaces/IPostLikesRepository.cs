using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RockContent.DataAccessLayer.Entities;

namespace RockContent.DataAccessLayer.Interfaces
{
   public interface IPostLikesRepository:IGenericRepository<PostLikes>
    {

        Task<PostLikes> GetLikesByUserIpAsync(string IpAddress);
        Task<List<PostLikes>> GetAllLikesAsync(int Limit=10);
        Task<List<PostLikes>> GetLikesByUserIpAndPostIdAsync(string IpAddress, string PostId);
        Task<int> GetAllLikesCountByPostIdAsync(string postId); 
    }
}
