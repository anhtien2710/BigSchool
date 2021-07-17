using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        BigSchoolContext context = new BigSchoolContext();

        [HttpPost]
        public IHttpActionResult Follow(Following follow)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return BadRequest("Please login first!");
            }

            if (userId == follow.FolloweeId)
            {
                return BadRequest("Can not follow myself!");
            }

            Following find = context.Followings.FirstOrDefault(p => p.FollowerId == userId && p.FolloweeId == follow.FolloweeId);

            if (find != null)
            {
                context.Followings.Remove(context.Followings.SingleOrDefault(p => p.FollowerId == userId && p.FolloweeId == follow.FolloweeId));
                context.SaveChanges();
                return Ok("cancel");
            }

            follow.FollowerId = userId;
            context.Followings.Add(follow);
            context.SaveChanges();
            return Ok();
        }
    }
}
