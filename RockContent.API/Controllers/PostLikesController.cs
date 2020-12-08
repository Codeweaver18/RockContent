using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockContent.Core.Interfaces;
using RockContent.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockContent.API.Controllers
{
    [ApiController]
    [Route("api/PostLikes")]
    public class PostLikesController : ControllerBase
    {
        private readonly ILikePostServiceAsync _PostLikesService;
        private readonly ILogger<PostLikesController> _logger;

        public PostLikesController(ILikePostServiceAsync postLikeService, ILogger<PostLikesController> logger)
        {
            _PostLikesService = postLikeService;
            _logger = logger;
        }


        [HttpGet("GetLikesByPostId/{postID}")]
        public async Task<IActionResult> GetLikesByPostId(string postID)
        {

            var response = new  TotalLikedPostResponse();
            try
            {
                var result = await _PostLikesService.GetAllLikesCountByPostIdAsync(postID);

                _logger.LogInformation(result.ToString());
                response = result;
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }

            return StatusCode(500, response);
        }

        [HttpGet("LikepostAsync/{PostID}/{IsLike}")]
        public async Task<IActionResult> LikepostAsync(string PostID, bool IsLike)
        {
            var response = new PostLikeResponse();
            try
            {
                var result = await _PostLikesService.LikepostAsync(new Core.Request.LikePostReq
                {
                    BrowserAgent = Request.Headers["User-Agent"].ToString(),
                    UserIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    IsLike = IsLike,
                    PostId = PostID
                });

                _logger.LogInformation(result.ToString());
                response = result;
                return Ok(response);
            }
            catch (Exception ex)
            {


                _logger.LogError(ex.Message);
            }

            return StatusCode(500, response);
        }
    }
}
