namespace GeoLocationFetcher.Validations;

public static class InputValidator
{
    public static bool TryValidateLocation(string? input, out string validationError)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            validationError = "Location cannot be empty.";
            return false;
        }

        var trimmed = input.Trim();
        if (trimmed.Length < 2)
        {
            validationError = "Location must be at least 2 characters.";
            return false;
        }

        if (trimmed.Length > 120)
        {
            validationError = "Location is too long. Maximum length is 120 characters.";
            return false;
        }

        validationError = string.Empty;
        return true;
    }
}
