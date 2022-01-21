using System;
using System.ComponentModel.DataAnnotations;

namespace DietAnalyzer.Models.DataAttributes
{
    /// <summary>
    /// 
    /// Less Than (or Equal to) Logical Conjunction Attribute
    /// A custom attribute with the following condition: 
    /// IF the tested property is FALSE, then the condition is always fulfilled 
    /// IF the tested property is TRUE, 
    ///     then the condition is fulfilled only if all reference properties are also TRUE
    /// 
    /// Example: 
    /// [LTELogicalConjunction("propB", "propC")] 
    /// public bool propA { get; set; } 
    /// 
    /// propA = true, propB = true, propC = false   // returns Error
    /// propA = true, propB = true, propC = true    // returns Success
    /// propA = false, ...                          // always returns Success (nothing to check)
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
            bool valueTested;
            bool performCheck = false;
            try
            {
                valueTested = value == null ? false : (bool)value;
            }
            catch (InvalidCastException)
            {
                return new ValidationResult($"Not a proper value: {value}");
            }
            if (!valueTested) return ValidationResult.Success;
            foreach (string s in includedProperties)
            {
                var attribute = validationContext.ObjectType.GetProperty(s);
                if (attribute == null)
                    throw new ArgumentException($"Property with this name not found: {s}");
                if (attribute.GetValue(validationContext.ObjectInstance) != null)
                {
                    try
                    {
                        if (!(bool)attribute.GetValue(validationContext.ObjectInstance))
                        {
                            performCheck = true;
                            errorReport = s;
                            break;
                        }
                    }
                    catch (InvalidCastException)
                    {
                        return new ValidationResult($"Not a proper value: " +
                           $"{attribute.GetValue(validationContext.ObjectInstance)}");
                    }
                }
            }
            if (performCheck)
                return new ValidationResult($"This field is inconsistent with {errorReport}.");
            return ValidationResult.Success;
        }
    }
}
