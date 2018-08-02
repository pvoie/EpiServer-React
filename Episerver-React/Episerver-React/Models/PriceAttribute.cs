using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Episerver_React.Models
{
    [AttributeUsage(AttributeTargets.All)]
    public class PriceAttribute:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int && (int)value > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Price must be greater than 0");
            }

            
        }


    }
}