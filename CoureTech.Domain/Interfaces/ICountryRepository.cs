using CoureTech.Domain.Entities;

namespace CoureTech.Domain.Interfaces;

/// <summary>
/// Repository contract for country data.
/// Defined in the Domain layer so the Application layer depends only on this abstraction.
/// </summary>
public interface ICountryRepository
{
    /// <summary>
    /// Returns the country whose code is a prefix of <paramref name="phoneNumber"/>,
    /// together with its operators, or <c>null</c> when no match is found.
    /// Longer (more-specific) country codes take precedence over shorter ones.
    /// </summary>
    Task<Country?> FindByPhoneNumberAsync(string phoneNumber);
}
