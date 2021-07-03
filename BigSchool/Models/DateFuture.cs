using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class DateFuture : ValidationAttribute
    {
        public override bool IsValid(object value)
      
        {
          return(DateTime) value > DateTime.Now;
        }
    }
}