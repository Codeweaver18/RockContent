using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.DataAccessLayer.Entities
{
    public class PostLikes:BaseEntity
    {
        public string PostId { get; set; }
        public string  UserIp { get; set; }
        public bool IsLike { get; set; }
        public string BrowserAgent { get; set; }
    }
}
