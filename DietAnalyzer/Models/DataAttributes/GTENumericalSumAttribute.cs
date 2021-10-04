using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.DataAttributes
{

    /// <summary>
    /// 
    /// Greater Than (or Equal to) Numerical Sum Attribute
    /// A custom attribute with the following condition: 
    /// the tested quantity must be greater than or equal to the sum of reference quantities
    /// 
    /// Example: 
    /// [GTENumericalSum("propB", "propC")] 
    /// public float propA { get; set; } 
    /// 
    /// propA = 4.0, propB = 1.0, propC = 6.0 returns Error
    /// propA = 4.0, propB = 1.0, propC = 3.0 returns Success
    /// propA = 4.0, propB = 1.0, propC = 1.5 returns Success
    /// 
    /// </summary>
    public class GTENumericalSumAttribute : ValidationAttribute
    {
        private string[] includedProperties;
        public GTENumericalSumAttribute(params string[] includedProperties) 
        {
            if(includedProperties == null) throw new ArgumentException("Comparison property not found");
            this.includedProperties = includedProperties;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorReport = "";
            var valueTested = (float)value;
            var sumOfAttributeValues = 0.0;
            for(int i = 0; i < includedProperties.Length; i++)
            {
                var attribute = validationContext.ObjectType.GetProperty(includedProperties[i]);
                if (attribute == null) throw new ArgumentException("Property with this name not found");
                sumOfAttributeValues += (float)attribute.GetValue(validationContext.ObjectInstance);
                if(i < includedProperties.Length - 1) errorReport = errorReport + includedProperties[i] + ", ";
            }
            if (valueTested < sumOfAttributeValues) 
                return new ValidationResult($"This value cannot be smaller than the sum of: {errorReport}");
            return ValidationResult.Success;
        }

    }
}
