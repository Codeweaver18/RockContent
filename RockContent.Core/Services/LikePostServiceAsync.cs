using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RockContent.DataAccessLayer.Interfaces;
using RockContent.DataAccessLayer.Respositories;
using RockContent.Core.Request;
using RockContent.Core.Response;
using RockContent.Core.Interfaces;

namespace RockContent.Core.Services
{
    public class LikePostServiceAsync: ILikePostServiceAsync
    {
        private readonly IPostLikesRepository  _repo;
        public LikePostServiceAsync(IPostLikesRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Method Implementing Checks:: Confirming if the UserIp has LIked the Post Previously
        /// </summary>
        /// <param name="PostId"></param>
        /// <param name="UserIP"></param>
        /// <returns></returns>
        private async Task<bool> CheckDuplicateTaskAsync(string PostId, string UserIP)
        {
            var response = false;
            try
            {
                var result =await _repo.GetLikesByUserIpAndPostIdAsync(UserIP, PostId);
                if (result!=null && result.Count>0)
                {
                    response = true;
                    //Logged this 

                }
            }
            catch (Exception ex)
            {
                //Log Error
                throw ex;
            }

            return response;
        }
        /// <summary>
        /// Get total Number of Likes for a particular Post based on Id
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        public async Task <TotalLikedPostResponse> GetAllLikesCountByPostIdAsync (string PostId)
        {
            var response = new TotalLikedPostResponse();
            try
            {
                var result = await _repo.GetAllLikesCountByPostIdAsync(PostId);
                if (result<1)
                {
                    response.responseDescription = "This Post Has no Likes or does not Exist, Kindly double check post Id";
                    response.responseMessage = "Could Not Fetch Post's Likes Count";
                    response.responseCode = "01";
                    return response;
                }

                response.TotalNumberOfLikes = result.ToString();
                response.responseDescription = "Total Post Likes Fetched successfully";
            }
            catch (Exception ex)
            {
                //Log this
                throw ex;
            }

            return response;
        }

        /// <summary>
        /// Posting th
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PostLikeResponse> LikepostAsync(LikePostReq request)
        {
            var response = new PostLikeResponse();
            try
            {
                //Checking against Duplicate or previous like by same UserAgent;
                var isLiked = await CheckDuplicateTaskAsync(request.PostId, request.UserIp);

                if (!isLiked)
                {
                    //Persist like to the database;
                    var result = await _repo.Create(new DataAccessLayer.Entities.PostLikes { BrowserAgent = request.BrowserAgent, PostId = request.PostId, IsLike = request.IsLike, UserIp=request.UserIp });
                    if (result!=null && result.Id>0)
                    {
                        response.LikedPostId = result.PostId;
                        response.LikesId = result.Id.ToString();

                    }
                }


                if (isLiked)
                {
                    //returning response message for like post
                    response.LikesId = null;
                    response.LikedPostId = null;
                    response.responseCode = "01";
                    response.responseMessage = "Duplicate Likes Found";
                    response.responseDescription = "OOPs, You cant like this Post twice";
                }

                //log information here
            }
            catch (Exception ex)
            {
                //Log This
                throw ex;
            }

            return response;
        }

        Task<bool> ILikePostServiceAsync.CheckDuplicateTaskAsync(string PostId, string UserIP)
        {
            throw new NotImplementedException();
        }
    }

}
