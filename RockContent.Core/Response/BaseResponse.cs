using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Core.Response
{
    public class BaseResponse
    {
        public string responseCode { get; set; } = "00";
        public string responseMessage { get; set; } = "Success";
        public string responseDescription { get; set; } = "Post Liked Successfully";
    }
}
