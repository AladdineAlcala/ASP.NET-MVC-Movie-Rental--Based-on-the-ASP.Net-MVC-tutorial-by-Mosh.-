using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Validation.Movie_only
{
    public class Is_Unique_MovieName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var movie = (Movie)validationContext.ObjectInstance;
            //try
            //{
            //    if (movie.Name[0].ToString() == " ")
            //        return new ValidationResult("fist ma space xa");
            //}
            //catch (Exception e) {
            //    return new ValidationResult("fist ma space xa");
            //}

            //return ValidationResult.Success;
           // return new ValidationResult("Server Side Validation");
            return ValidationResult.Success;
        }
    }
}