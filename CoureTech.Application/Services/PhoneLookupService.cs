using CoureTech.Application.DTOs;
using CoureTech.Application.Interfaces;
using CoureTech.Domain.Interfaces;

namespace CoureTech.Application.Services;

public class PhoneLookupService : IPhoneLookupService
{
    private readonly ICountryRepository _countryRepository;

    public PhoneLookupService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<PhoneLookupResponse?> LookupAsync(string phoneNumber)
    {
        var country = await _countryRepository.FindByPhoneNumberAsync(phoneNumber);

        if (country is null)
            return null;

        return new PhoneLookupResponse
        {
            Number = phoneNumber,
            Country = new CountryDto
            {
                CountryCode = country.CountryCode,
                Name = country.Name,
                CountryIso = country.CountryIso,
                CountryDetails = country.CountryDetails
                    .Select(d => new CountryDetailDto
                    {
                        Operator = d.Operator,
                        OperatorCode = d.OperatorCode
                    })
            }
        };
    }
}
