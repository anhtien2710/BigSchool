<<<<<<< HEAD
﻿using BigSchool.Models;
=======
﻿
using BigSchool.Models;
>>>>>>> 2304f3498f000046c9f9a6d29b18559992819ec7
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();

            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendances.Any(x => x.Attendee == userID && x.CourseId == attendanceDto.Id))
            {
<<<<<<< HEAD
                context.Attendances.Remove(context.Attendances.SingleOrDefault(p =>p.Attendee == userID && p.CourseId == attendanceDto.Id));
                context.SaveChanges();
                return Ok("cancel");
               // return BadRequest("The attendance already exists!");
=======
                return BadRequest("The attendance already exists!");
>>>>>>> 2304f3498f000046c9f9a6d29b18559992819ec7
            }
            var attendance = new Attendance() { CourseId = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> 2304f3498f000046c9f9a6d29b18559992819ec7
