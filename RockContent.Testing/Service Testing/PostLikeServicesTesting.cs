using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RockContent.API.Controllers;
using RockContent.Core.Interfaces;
using RockContent.Core.Services;
using RockContent.DataAccessLayer.DbContexts;
using RockContent.DataAccessLayer.Entities;
using RockContent.DataAccessLayer.Interfaces;
using RockContent.DataAccessLayer.Respositories;
using Microsoft.Extensions.Configuration;

namespace RockContent.Testing.Service_Testing
{
    public class PostLikeServicesTesting
    {
        private  ILikePostServiceAsync _PostLikesService;

        public PostLikeServicesTesting()
        {

            var services = new ServiceCollection();
            services.AddTransient<ILikePostServiceAsync, LikePostServiceAsync>();
            services.AddTransient<IPostLikesRepository, PostLikesRepository<PostLikes>>();
            var serviceProvider = services.BuildServiceProvider();

            _PostLikesService = serviceProvider.GetService<ILikePostServiceAsync>();
        }


        [SetUp]
        public void SetUp()
        {
        }

        /// <summary>
        /// This Test Checks for total number of liks for a particular PostID:234;
        /// </summary>
        [Test]
        public void return_likes_number_for_PostID_return_1()
        {
            var PostId = 234;
            var PostLikeCount = 1;
            var results = _PostLikesService.GetAllLikesCountByPostIdAsync(PostId.ToString());
            Assert.AreEqual(PostLikeCount.ToString(), results.Result.TotalNumberOfLikes);
        }


        /// <summary>
        /// Check against duplicate likes for PostId:234 coming fom userIp
        /// </summary>
        [Test]
        public void Check_Against_Duplicate_likes_Return_True()
        {
            var IsDuplicate = true;
            var PostId = 234;
            var UserIp = "::1";
            var result = _PostLikesService.CheckDuplicateTaskAsync(PostId.ToString(), UserIp);
            Assert.IsTrue(IsDuplicate);
        }
    

}

}
