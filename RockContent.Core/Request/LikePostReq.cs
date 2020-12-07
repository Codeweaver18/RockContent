using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Core.Request
{
    public class LikePostReq
    {
        public string PostId { get; set; }
        public string UserIp { get; set; }
        public bool IsLike { get; set; }
        public string BrowserAgent { get; set; }
    }
}
