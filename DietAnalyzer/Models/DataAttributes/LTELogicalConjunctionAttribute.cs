using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.DataAttributes
{
    /// <summary>
    /// 
    /// Less Than (or Equal to) Logical Conjunction Attribute
    /// A custom attribute with the following condition: 
    /// IF ANY of the reference properties is FALSE, then the tested property must be FALSE
    /// ELSE no check is performed
    /// 
    /// Example: 
    /// [LTELogicalConjunction("propB", "propC")] 
    /// public bool propA { get; set; } 
    /// 
    /// propA = true, propB = true, propC = false   // returns Error
    /// propA = true, propB = true, propC = true    // returns Success
    /// propA = false                               // always returns Success (nothing to check)
    /// 
    /// </summary>
    public class LTELogicalConjunctionAttribute : ValidationAttribute
    {
        private string[] includedProperties;
        public LTELogicalConjunctionAttribute(params string[] includedProperties)
        {
            if (includedProperties == null) throw new ArgumentException("Comparison property not found");
            this.includedProperties = includedProperties;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorReport = "";
            var valueTested = value == null ? false : (bool)value;
            var performCheck = false;
            //
            if(!valueTested) return ValidationResult.Success;
            foreach (string s in includedProperties)
            {
                var attribute = validationContext.ObjectType.GetProperty(s);
                if (attribute == null) throw new ArgumentException("Property with this name not found");
                if (attribute.GetValue(validationContext.ObjectInstance) != null 
                    && !(bool)attribute.GetValue(validationContext.ObjectInstance))
                {
                    performCheck = true;
                    errorReport = s;
                    break;
                } 
            }
            if (performCheck) 
                return new ValidationResult($"There is a logical conflict between this value and {errorReport}");
            return ValidationResult.Success;
        }
    }
}
