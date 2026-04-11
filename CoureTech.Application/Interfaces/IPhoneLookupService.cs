using CoureTech.Application.DTOs;

namespace CoureTech.Application.Interfaces;

/// <summary>
/// Question 2 – resolves a phone number to its country and operator details.
/// </summary>
public interface IPhoneLookupService
{
    Task<PhoneLookupResponse?> LookupAsync(string phoneNumber);
}
