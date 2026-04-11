namespace CoureTech.Application.DTOs;

public class PhoneLookupResponse
{
    public string Number { get; set; } = string.Empty;
    public CountryDto Country { get; set; } = null!;
}

public class CountryDto
{
    public string CountryCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CountryIso { get; set; } = string.Empty;
    public IEnumerable<CountryDetailDto> CountryDetails { get; set; } = [];
}

public class CountryDetailDto
{
    public string Operator { get; set; } = string.Empty;
    public string OperatorCode { get; set; } = string.Empty;
}
