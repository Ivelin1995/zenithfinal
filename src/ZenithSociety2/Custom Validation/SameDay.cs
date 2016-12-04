using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZenithSociety2.Models.Custom_Validation
{
    public class SameDay : ValidationAttribute
    {
        private string otherDatePropertyName;

        public SameDay(string otherDatePropertyName) : base("{0} must be after the current time")
        {
            this.otherDatePropertyName = otherDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Event)validationContext.ObjectInstance;

            var property = validationContext.ObjectType.GetProperty(otherDatePropertyName);

            if (property == null)
            {
                return new ValidationResult("Unknown property");
            }

            var otherDate = (DateTime)property.GetValue(validationContext.ObjectInstance, null);
            var thisDate = (DateTime)value;

            if (thisDate.Date != otherDate.Date)
                return new ValidationResult("Must be on the same date");

            return ValidationResult.Success;
        }
    }
}
