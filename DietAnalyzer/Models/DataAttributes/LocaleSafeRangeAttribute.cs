using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.DataAttributes
{
    /// <summary>
    /// 
    /// The same as the built-in RangeAttribute, but will work with both commas and dots as decimal signs
    /// Another solution would be to enforce culture in the current thread, see:
    /// https://stackoverflow.com/questions/29437989/range-validation-where-value-is-with-comma-and-not-with-dot
    /// But a custom attribute seems easier and more robust to me 
    /// 
    /// Note: I am not sure why the standard RangeAttribute breaks for commas
    /// Especially since my solution seems very simple and yet it still handles commas correctly
    /// But this version works and RangeAttribute doesn't, so I'm going to just use this one
    /// 
    /// </summary>
    public class LocaleSafeRangeAttribute : ValidationAttribute
    {
        protected double min;
        protected double max;
        protected string errorMsg;
        public LocaleSafeRangeAttribute(double minimum, double maximum, string errorMessage = null) 
        {
            min = minimum;
            max = maximum;
            errorMsg = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            float valueTested;
            try
            {
                valueTested = value == null ? 0.0f : (float)value;
            }
            catch (InvalidCastException)
            {
                return new ValidationResult($"Not a proper value: {value}");
            }
            if (valueTested < min || valueTested > max)
            {
                if (errorMsg != null)
                    return new ValidationResult(errorMsg);
                else return new ValidationResult($"This value must be between {min:G2} and {max:G2}");
            }
            return ValidationResult.Success;
        }

    }
}
