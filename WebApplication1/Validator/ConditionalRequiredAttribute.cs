using System.ComponentModel.DataAnnotations;

namespace UploadUI.Validator
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConditionalRequiredAttribute : ValidationAttribute
    {
        private readonly string _dependentPropertyName;

        public ConditionalRequiredAttribute(string dependentPropertyName)
        {
            _dependentPropertyName = dependentPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentProperty = validationContext.ObjectType.GetProperty(_dependentPropertyName);

            if (dependentProperty == null)
            {
                return new ValidationResult($"Unknown property: {_dependentPropertyName}");
            }

            var dependentValue = (bool)dependentProperty.GetValue(validationContext.ObjectInstance);

            if (dependentValue && value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required.");
            }

            return ValidationResult.Success;
        }
    }
}
