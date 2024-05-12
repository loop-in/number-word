using System.Text.RegularExpressions;

namespace NumberToWord.Api.Applications.Utils;

public class FormatValidator : IFormatValidator
{
    public bool IsMoney(string value)
    {
        // Validation:
        // Make sure the format is XXXX.XX, where X is from 0 to 9
        // Will not start with zero
        return Regex.IsMatch(value, @"^(?!0\d)\d+(\.\d{1,2})?$");
    }
}
