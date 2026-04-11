using Microsoft.EntityFrameworkCore;
using CoureTech.Domain.Entities;
using CoureTech.Domain.Interfaces;
using CoureTech.Infrastructure.Data;

namespace CoureTech.Infrastructure.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _db;

    public CountryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Country?> FindByPhoneNumberAsync(string phoneNumber)
    {
        var countries = await _db.Countries
            .Include(c => c.CountryDetails)
            .ToListAsync();

        return countries
            .OrderByDescending(c => c.CountryCode.Length)
            .FirstOrDefault(c => phoneNumber.StartsWith(c.CountryCode));
    }
}
