using System.Globalization;

namespace Domain.Validators;

/// <summary>
/// Проверка на существующий ISO код страны
/// </summary>
/// <returns></returns>
public static class ValidCountryCode
{
    /// <summary>
    /// Проверка на существующий ISO код страны
    /// </summary>
    /// <param name="countryCode"></param>
    /// <returns></returns>
    public static bool IsValidCountryCode(string countryCode)
    {
        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Select(c => new RegionInfo(c.LCID).TwoLetterISORegionName)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        return regions.Contains(countryCode.ToUpperInvariant());
    }
}