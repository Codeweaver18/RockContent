using RockContent.Core.Request;
using RockContent.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RockContent.Core.Interfaces
{
  public interface ILikePostServiceAsync
    {
        Task<TotalLikedPostResponse> GetAllLikesCountByPostIdAsync(string PostId);
        Task<bool> CheckDuplicateTaskAsync(string PostId, string UserIP);
        Task<PostLikeResponse> LikepostAsync(LikePostReq request);
    }
}
