using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RockContent.Testing.Service_Testing
{
   public class PostLikeServicesTesting
    {


        [Test]
        public void return_likes_number_for_PostID_return_2()
        {
            var PostId = 22;
            var PostLikeCount = 2;

        }


        [Test]
        public void Check_Against_Duplicate_likes_Return_True()
        {
            var IsDuplicate = true;
            var PostId = 22;
            Assert.IsTrue(IsDuplicate);
        }
    

}

}
