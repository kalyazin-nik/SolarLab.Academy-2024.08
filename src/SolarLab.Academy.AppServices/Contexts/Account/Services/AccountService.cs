using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.Contracts.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SolarLab.Academy.AppServices.Contexts.Account.Services;

/// <summary>
/// Сервис по работе с аккаунтами пользователей.
/// </summary>
/// <param name="userRepository">Репозиторий по работе с пользователями.</param>
/// <param name="configuration">Конфигурация приложения.</param>
/// <param name="httpContextAccessor">Доступ к контексту Http.</param>
public class AccountService(IUserRepository userRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : IAccountService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    /// <inheritdoc />
    public async Task<UserDto?> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
        var claims = _httpContextAccessor.HttpContext.User.Claims;
        var claimId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(claimId))
        {
            return null;
        }

        return await _userRepository.GetByIdAsync(Guid.Parse(claimId), cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string> LoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken)
    {
        var existUser = await _userRepository.GetByLoginAsync(dto, cancellationToken) ?? throw new Exception("Пользлователь не найден!");
        if (existUser.Password != CryptoHelper.GetBase64Hash(dto.Password))
        {
            throw new Exception("Неверный пароль!");
        }

        var secretKey = _configuration["Jwt:Key"]!;
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, existUser.Id.ToString()),
            new(ClaimTypes.Name, existUser.Name)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            )
        );

        var result = new JwtSecurityTokenHandler().WriteToken(token);
        return result.ToString();
    }

    /// <inheritdoc />
    public async Task<UserDto> RegisterAsync(UserRegisterRequestDto dto, CancellationToken cancellationToken)
    {
        return await _userRepository.RegisterAsync(dto, cancellationToken);
    }
}
