using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RockContent.DataAccessLayer.Entities;

namespace RockContent.DataAccessLayer.Interfaces
{
   public interface IPostLikesRepository:IGenericRepository<PostLikes>
    {

        PostLikes GetLikesByUserIp(string IpAddress);
        List<PostLikes> GetAllLikes(int Limit=10);

    }
}
