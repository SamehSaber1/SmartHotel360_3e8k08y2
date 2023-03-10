using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartHotel.Clients.Core.Validations
{
    public class ValidUrlRule : IValidationRule<string>
    {
        public ValidUrlRule()
        {
            ValidationMessage = "Should be an URL";
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            var ctx = new ValidationContext(this);
            var results = new List<ValidationResult>();

            return Validator.TryValidateValue(value, ctx, results, new[] { new DataTypeAttribute(DataType.Url) })
                            && results.TrueForAll(r => r == ValidationResult.Success);
        }
    }
}
