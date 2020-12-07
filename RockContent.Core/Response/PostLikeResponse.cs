using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Core.Response
{
   public class PostLikeResponse:BaseResponse
    {
        public string LikedPostId { get; set; }
        public string LikesId { get; set; }
    }
}
