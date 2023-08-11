using WareHouse.Domain.Entities;

namespace WareHouse.Application.Common.Interfaces;

public interface ITokenService
{
    string BuildToken(User user);
    bool ValidateToken(string key, string issuer, string audience, string token);
}
